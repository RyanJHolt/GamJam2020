using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
	[SerializeField]private float direction = 1;
	[SerializeField] private float speed = 3f;
	[SerializeField] private float detectRange = 10f;
	[SerializeField] private float Range;

	[Range(10, 400)] public int turnTime;
	Rigidbody2D myRigidbody;
	Transform myTransform;
	private int localTime;
	private float xScale;
	private float baseY;
	private float xStore;
	private GameObject Enemy;
	private GameObject Player;

	// Start is called before the first frame update
	void Start()
	{
		myRigidbody = GetComponent<Rigidbody2D>();
		myTransform = GetComponent<Transform>();

		startFlip();

		localTime = 0;
		xScale = transform.localScale.x;
		baseY = myTransform.position.y;

		Enemy = GameObject.FindGameObjectWithTag("Enemy");
		Player = GameObject.FindGameObjectWithTag("Player");

	}

	// Update is called once per frame
	void FixedUpdate()
	{
		Range = Vector2.Distance(Enemy.transform.position, Player.transform.position);
		if(Range <= detectRange){
			EnemyTracking();
			
		} else{
			bob();
			move();	
		}
		localTime++;
	}

	void move()
	{
		Vector2 newVelocity = new Vector2(speed * direction, 0);
		myRigidbody.velocity = newVelocity;
		if (localTime >= turnTime)
		{
			turn();
		}
	}

	void bob()
	{
		float newY = Mathf.Sin(localTime / 4);
		bool Up  = (Random.value > 0.5f);
		if(Up){
		myTransform.position = new Vector3(myTransform.position.x, myTransform.position.y + newY/15, myTransform.position.z);
		} else {
		myTransform.position = new Vector3(myTransform.position.x, myTransform.position.y - newY/15, myTransform.position.z);
		}
	}

	void turn()
	{
		spriteFlip();
		direction *= -1;
		localTime = 0;
	}

	void spriteFlip(){
		if (myRigidbody.velocity.x > 0){
			myRigidbody.transform.localScale = new Vector3(- Mathf.Abs(myTransform.localScale.x) , myRigidbody.transform.localScale.y, myRigidbody.transform.localScale.z);
		} else {
			myRigidbody.transform.localScale = new Vector3(Mathf.Abs(myTransform.localScale.x), myRigidbody.transform.localScale.y, myRigidbody.transform.localScale.z);
		}
	}

	void startFlip()
	{
		myRigidbody.transform.localScale = new Vector3(myTransform.localScale.x * direction, myRigidbody.transform.localScale.y, myRigidbody.transform.localScale.z);
	}

	void EnemyTracking() {
			Vector2 velocity = new Vector2((transform.position.x - Player.transform.position.x) * speed, (transform.position.y - Player.transform.position.y)* speed);
			GetComponent<Rigidbody2D>().velocity = -velocity;
			xStore = Mathf.Abs(myTransform.localScale.x);
			if(Player.transform.position.x > transform.position.x){
				myRigidbody.transform.localScale = new Vector3(xStore, myRigidbody.transform.localScale.y, myRigidbody.transform.localScale.z);
			} else if (Player.transform.position.x < transform.position.x){
				myRigidbody.transform.localScale = new Vector3(-xStore, myRigidbody.transform.localScale.y, myRigidbody.transform.localScale.z);
			}
    }
}
