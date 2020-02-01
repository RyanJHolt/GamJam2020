using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{

    [SerializeField] float horizontalSpeed = 5f;
    [SerializeField] float verticalSpeed = 5f;
    [SerializeField] float dashSpeed = 5f;
    [SerializeField] int dashRefreshTime = 2;
    [SerializeField] Vector2 hitPunch = new Vector2(5f, 5f);

    Rigidbody2D myRigidbody;
    Transform myTransform;
    BoxCollider2D myBoxCollider;

    float horizontalDirection = 0f;
    float verticalDirection = 0f;
    bool dashing = false;
    bool allowMovement = true;

    private float xScale;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myTransform = GetComponent<Transform>();
        myBoxCollider = GetComponent<BoxCollider2D>();

        xScale = myRigidbody.transform.localScale.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        movement();
        dash();
        spriteFLip();
        spriteRotation();
    }

    void movement() {
        if (!allowMovement)
            return;

        horizontalDirection = Mathf.Sign(myRigidbody.velocity.x);
        verticalDirection = Mathf.Sign(myRigidbody.velocity.y);

        float hMovement = Input.GetAxisRaw("Horizontal");
        float vMovement = Input.GetAxisRaw("Vertical");

        myRigidbody.velocity = myRigidbody.velocity + new Vector2(hMovement * horizontalSpeed, vMovement * verticalSpeed);
    }

    void spriteFLip()
    {
        if(horizontalDirection == 1)
        {
            myRigidbody.transform.localScale = new Vector3(xScale, myRigidbody.transform.localScale.y, myRigidbody.transform.localScale.z);
        } else
        {
            myRigidbody.transform.localScale = new Vector3(-xScale, myRigidbody.transform.localScale.y, myRigidbody.transform.localScale.z);
        }
    }

    void spriteRotation()
    {
        bool isMovingEnough = Mathf.Abs(myRigidbody.velocity.y) > 0.2;

        if (isMovingEnough)
        {
            if (horizontalDirection == 1)
            {
                transform.localEulerAngles = new Vector3(0, 0, 45 * verticalDirection);
            }
            else
            {
                transform.localEulerAngles = new Vector3(0, 0, 45 * -verticalDirection);
            }
        } else
        {
            transform.localEulerAngles = new Vector3(0, 0, 0);
        }
    }

    void dash()
    {
        if (Input.GetAxisRaw("Jump") > 0 && !dashing) {
            myRigidbody.velocity = myRigidbody.velocity + new Vector2(dashSpeed * horizontalDirection, myRigidbody.velocity.y);
            dashing = true;
            StartCoroutine(resetDash());
        }
    }

    IEnumerator resetDash() {
        yield return new WaitForSeconds(dashRefreshTime);
        dashing = false;
    }

    void deathAnimation()
    {
        myBoxCollider.isTrigger = true;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
       {
            deathAnimation();
            FindObjectOfType<GameSession>().takeLives(1);
            Debug.Log("Hit");
        }
    }
}
