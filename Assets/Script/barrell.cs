using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barrell : MonoBehaviour
{

    GameSession session;
    // Start is called before the first frame update
    void Start()
    {
        session = FindObjectOfType<GameSession>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            session.addPlastic(6);
            GameObject.Destroy(gameObject);
        }
    }
}
