using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubbles : MonoBehaviour
{

    Rigidbody2D myRigidbody;
	Transform myTransform;
    [SerializeField] float speed = 5f;
	
    private GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
	    myTransform = GetComponent<Transform>();
        Player = GameObject.FindGameObjectWithTag("Player");
        if (Player.transform.position.x < myTransform.position.x){
            myRigidbody.velocity = new Vector2(speed,0);
        } else {
            myRigidbody.velocity = new Vector2(-speed,0);
        }
        StartCoroutine(Despawn());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Despawn(){
        yield return new WaitForSeconds(despawnTime);
        Destroy (gameObject);
    }
}
