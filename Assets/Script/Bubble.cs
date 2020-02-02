using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    Transform myTransform;
    Rigidbody2D myRigidbody;
    // Start is called before the first frame update
    void Start()
    {
        myTransform = GetComponent<Transform>();
        myRigidbody = GetComponent<Rigidbody2D>();
        myRigidbody.velocity = new Vector2(0,2);
        StartCoroutine(Despawn());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator Despawn(){
        yield return new WaitForSeconds(10);
        Destroy (gameObject);
    }
}
