using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
	[SerializeField]private float direction = 1;
	[SerializeField] private float speed = 3f;
	[SerializeField] private float detectRange = 15f;

	[Range(10, 400)] public int turnTime;
	Rigidbody2D myRigidbody;
	Transform myTransform;
	private int localTime;
	private float xScale;
	private float baseY;
	private float xStore;
	bool dead = false;
	private GameObject Player;
	[SerializeField] GameObject bubble;

	// Start is called before the first frame update
	void Start()
	{
		myRigidbody = GetComponent<Rigidbody2D>();
		myTransform = GetComponent<Transform>();

		startFlip();

		localTime = 0;
		xScale = transform.localScale.x;
		baseY = myTransform.position.y;

		Player = GameObject.FindGameObjectWithTag("Player");
	}

	// Update is called once per frame
	void FixedUpdate()
	{
		if(dead){return;}
		float Range = Vector2.Distance(myTransform.position, Player.transform.position);
		if(Range <= detectRange){
			EnemyTracking();
		} else
		{
			move();
		}
		bob();
		localTime++;
	}

	void move()
	{
		Vector2 newVelocity = new Vector2(speed * direction, myRigidbody.velocity.y);
		myRigidbody.velocity = newVelocity;
		if (localTime >= turnTime)
		{
			turn();
		}
	}

	void bob()
	{
		float newY = Mathf.Sin(localTime / 4);
		myTransform.position = new Vector3(myTransform.position.x, myTransform.position.y + newY / 15, myTransform.position.z);
	}

	void turn()
	{
		spriteFlip();
		direction *= -1;
		localTime = 0;
	}

	void spriteFlip()
	{
		myRigidbody.transform.localScale = new Vector3(myTransform.localScale.x  * -1, myRigidbody.transform.localScale.y, myRigidbody.transform.localScale.z);
	}

	void startFlip()
	{
		myRigidbody.transform.localScale = new Vector3(myTransform.localScale.x * direction, myRigidbody.transform.localScale.y, myRigidbody.transform.localScale.z);
	}

	void EnemyTracking() {
		Vector2 playerDirection = new Vector2(Player.transform.position.x - myTransform.position.x, Player.transform.position.y - myTransform.position.y).normalized;
		Debug.Log(playerDirection.x + " " +  playerDirection.y);
	}
	
	 private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet")
        {
			Debug.Log("test");
			dead = true;
            deathAnimation();
            Instantiate (bubble, gameObject.transform.position, gameObject.transform.rotation);
        }
    }

	void deathAnimation()
    {
        myRigidbody.velocity = new Vector2(0,2);
        myRigidbody.transform.localScale = new Vector3(myRigidbody.transform.localScale.x,- myRigidbody.transform.localScale.y, myRigidbody.transform.localScale.z);
    }

}
