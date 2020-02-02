using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    Rigidbody2D myRigidbody;
    BoxCollider2D myBoxCollider;
    //public PlayerController Player;
    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponentInChildren<Rigidbody2D>();
        myBoxCollider = GetComponentInChildren<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //private void OnTriggerEnter2D(Collider2D collision) {
    //    if (collision.tag == "Enemy") {
    //        Player.hurt();
    //    }
    //}
}
