using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    [SerializeField] Vector2 hitPunch = new Vector2(5f, 5f);

    [Header("Movement")]
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float turnSpeed = 5f;

    [Header("Dash")]
    [SerializeField] float dashMultiplier = 3f;
    [SerializeField] float dashDuration = 0.2f;
    [SerializeField] float dashRefreshTime = 2f;
    [SerializeField] AudioClip dashSfx;

    Rigidbody2D myRigidbody;
    private Vector3 rbScale;
    BoxCollider2D myBoxCollider;
    [Header("Do not change")]
    [SerializeField] GameObject myLightWrapper;
    GameSession session;

    AudioSource audioSource;

    public float hMovement = 0f, vMovement = 0f;
    public float horizontalDirection = 1f, verticalDirection = 0f;
    public float angle = 0f;
    public bool canDash = true, dashing = false;
    bool allowMovement = true;
    bool dead = false;

    private bool movingLeft = false;

    private float angleDelta = 0f;
    Vector2 spawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponentInChildren<Rigidbody2D>();
        rbScale = myRigidbody.transform.localScale;
        session = GetComponent<GameSession>();
        myBoxCollider = GetComponentInChildren<BoxCollider2D>();
        spawnPoint = new Vector2(myRigidbody.transform.position.x, myRigidbody.transform.position.y);
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (dead)
        {
            return;
        }
        movement();
        dash();
        spriteFlip();
        spriteRotation();
    }

    void movement()
    {
        if (!allowMovement)
            return;

        if (dashing)
        {
            Vector2 direction = (Quaternion.AngleAxis(angle, Vector3.forward) * Vector3.right).normalized * moveSpeed * dashMultiplier / Time.deltaTime;
            myRigidbody.AddForce(direction);
        }
        else
        {
            hMovement = Input.GetAxisRaw("Horizontal");
            vMovement = Input.GetAxisRaw("Vertical");

            horizontalDirection = hMovement == 0 ? 0 : Mathf.Sign(hMovement);
            verticalDirection = vMovement == 0 ? 0 : Mathf.Sign(vMovement);

            Vector2 direction = new Vector2(hMovement, vMovement).normalized * moveSpeed / Time.deltaTime;
            if (hMovement != 0 || vMovement != 0)
            {
                angle = Mathf.SmoothDampAngle(
                    angle,
                    Mathf.Atan2(verticalDirection, horizontalDirection) * Mathf.Rad2Deg,
                    ref angleDelta, 1 / (5 * turnSpeed)
                ) % 360;
                if (angle < -180) angle += 360;
            }
            movingLeft = (angle < -90 || angle > 90);

            myRigidbody.AddForce(direction);
        }

    }

    void spriteFlip()
    {
        if (!movingLeft)
        {
            myRigidbody.transform.localScale = rbScale;
            myLightWrapper.transform.localEulerAngles = new Vector3(0, 0, 0);
        }
        else
        {
            myRigidbody.transform.localScale = Vector3.Scale(rbScale, new Vector3(1, -1, 1));
            myLightWrapper.transform.localEulerAngles = new Vector3(0, 0, 180);
        }
    }

    void spriteRotation()
    {
        myRigidbody.transform.localEulerAngles = new Vector3(0, 0, angle);
    }

    void dash()
    {
        IEnumerator endDash()
        {
            yield return new WaitForSeconds(dashDuration);
            dashing = false;
            Debug.Log("End dash");
            yield return new WaitForSeconds(dashRefreshTime);
            canDash = true;
            Debug.Log("Dash recharged");
        }

        if (canDash && Input.GetAxisRaw("Jump") > 0)
        {
            audioSource.PlayOneShot(dashSfx);
            Debug.Log("Dashing");
            dashing = true;
            canDash = false;
            StartCoroutine(endDash());
        }
    }

    void deathAnimation()
    {
        //SoundManagerScript.PlaySound("Die");
        myRigidbody.velocity = new Vector2(0, 2);
        myRigidbody.transform.localScale = new Vector3(myRigidbody.transform.localScale.x, -myRigidbody.transform.localScale.y, myRigidbody.transform.localScale.z);
    }

    public void hurt()
    {
        IEnumerator Respawn()
        {
            yield return new WaitForSeconds(3);
            myRigidbody.transform.position = spawnPoint;
            dead = false;
        }

        if(!dead){
        deathAnimation();
        FindObjectOfType<GameSession>().takeLives(1);
        dead = true;
        if (FindObjectOfType<GameSession>().getPlayerLives() > 0)
        {
            StartCoroutine(Respawn());
        }
        Debug.Log("Hit");
        }
    }



}