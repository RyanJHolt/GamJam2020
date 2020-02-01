// using System.Threading.Tasks.Dataflow;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{

    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float turnSpeed = 5f;
    [SerializeField] float dashSpeed = 5f;
    [SerializeField] int dashRefreshTime = 2;
    [SerializeField] Vector2 hitPunch = new Vector2(5f, 5f);

    Rigidbody2D myRigidbody;
    private Vector3 rbScale;
    BoxCollider2D myBoxCollider;
    GameSession session;

    public float horizontalDirection = 0f;
    public float verticalDirection = 0f;
    public float angle = 0f;
    bool dashing = false;
    bool allowMovement = true;

    private bool movingLeft = false;

    private float angleDelta = 0f;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponentInChildren<Rigidbody2D>();
        rbScale = myRigidbody.transform.localScale;
        session = GetComponent<GameSession>();
        myBoxCollider = GetComponentInChildren<BoxCollider2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        movement();
        dash();
        spriteFlip();
        spriteRotation();
    }

    void movement()
    {
        if (!allowMovement)
            return;

        float hMovement = Input.GetAxisRaw("Horizontal");
        float vMovement = Input.GetAxisRaw("Vertical");

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
        }
        movingLeft = (angle < -90 || angle > 90);

        myRigidbody.AddForce(direction);
    }

    void spriteFlip()
    {
        if (!movingLeft)
        {
            myRigidbody.transform.localScale = rbScale;
        }
        else
        {
            myRigidbody.transform.localScale = Vector3.Scale(rbScale, new Vector3(1, -1, 1));
        }
    }

    void spriteRotation()
    {
        myRigidbody.transform.localEulerAngles = new Vector3(0, 0, angle);
    }

    void dash()
    {
        if (Input.GetAxisRaw("Jump") > 0 && !dashing)
        {
            myRigidbody.velocity = myRigidbody.velocity + new Vector2(dashSpeed * horizontalDirection, myRigidbody.velocity.y);
            dashing = true;
            StartCoroutine(resetDash());
        }
    }

    IEnumerator resetDash()
    {
        yield return new WaitForSeconds(dashRefreshTime);
        dashing = false;
    }

    void deathAnimation()
    {
        myBoxCollider.isTrigger = true;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            deathAnimation();
            session.takeLives(1);
            Debug.Log("Hit");
        }
    }
}
