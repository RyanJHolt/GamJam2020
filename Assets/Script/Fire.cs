using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public GameObject bubbleBullet;
    public int reload = 1;
    public bool reloaded;
    public bool reloading;
    // Start is called before the first frame update
    void Start()
    {
        reloaded = true;
    }

    private void fire()
    {
        if (true){
        Instantiate (bubbleBullet, gameObject.transform.position, gameObject.transform.rotation);
        reloaded = false; 
        reloading = false;
        } 
        
    }

    // Update is called once per frame
    void Update()
    {
        if (reloaded == false & reloading == false)
        {
            Reload();
        }
        if (Input.GetMouseButtonDown(0))
        {
            fire();
        }
    }

    IEnumerator Reload(){
        yield return new WaitForSeconds(reload);
        reloaded = true;
    }
}
