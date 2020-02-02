using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubbles : MonoBehaviour
{

    Rigidbody2D myRigidbody;
    Transform myTransform;
    [SerializeField] float speed = 2f;
    int despawnTime = 2;

    private GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        IEnumerator Despawn()
        {
            yield return new WaitForSeconds(despawnTime);
            Destroy(gameObject);
        }

        myRigidbody = GetComponent<Rigidbody2D>();
        myTransform = GetComponent<Transform>();
        float angle = FindObjectOfType<playerController>().angle;
        myRigidbody.AddForce((Quaternion.AngleAxis(angle, Vector3.forward) * Vector3.right).normalized * speed, ForceMode2D.Impulse);
        StartCoroutine(Despawn());
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
}
