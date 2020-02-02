using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    Rigidbody2D myRigidbody;
    BoxCollider2D myBoxCollider;
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

    void OnTriggerEnter2D(Collider2D collision) {
       if (collision.tag == "Enemy") {
           gameObject.GetComponentInParent<playerController>().hurt();
       }
    }
}
