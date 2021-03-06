﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadFish : MonoBehaviour
{
    [SerializeField]private float direction = 1;
	[SerializeField] private float speed = 3f;
	[SerializeField] private int bobHeight;
	[Range(10, 400)] public int turnTime;
	Transform myTransform;
    Rigidbody2D myRigidbody;
	private int localTime;
	[SerializeField] private int bobStore;
	[SerializeField] private int bobRate;
	private float xScale;
	private float baseY;
	private float xStore;

	// Start is called before the first frame update
	void Start()
	{
		myTransform = GetComponent<Transform>();
        myRigidbody = GetComponent<Rigidbody2D>();

		startFlip();

		localTime = 0;
		xScale = transform.localScale.x;
		baseY = myTransform.position.y;
		bobStore = bobRate;
		bobHeight = 12;
	}

	// Update is called once per frame
	void FixedUpdate()
	{
		move();
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
		if (bobRate == 0)
		{
			bobRate = bobStore;
		}
		if(bobRate == bobStore){
		float newY = Mathf.Sin(localTime / bobHeight);
		Vector2 newVelocity = new Vector2((speed * direction), 0f);
		myTransform.position = new Vector3(myTransform.position.x, myTransform.position.y + newY / 15, myTransform.position.z);
		}
		bobRate--;
	}

	void turn()
	{
		spriteFlip();
		direction *= -1;
		localTime = 0;
	}

	void spriteFlip()
	{	if (myRigidbody.velocity.x > 0){
		    myRigidbody.transform.localScale = new Vector3(- Mathf.Abs(myTransform.localScale.x) , myRigidbody.transform.localScale.y, myRigidbody.transform.localScale.z);
		} else {
			myRigidbody.transform.localScale = new Vector3(Mathf.Abs(myTransform.localScale.x), myRigidbody.transform.localScale.y, myRigidbody.transform.localScale.z);
		}
	}

	void startFlip()
	{
		myRigidbody.transform.localScale = new Vector3(myTransform.localScale.x * direction, myRigidbody.transform.localScale.y, myRigidbody.transform.localScale.z);
	}
}
