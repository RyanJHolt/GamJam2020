using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public GameObject bubbleBullet;
    public int reloadTime = 1;
    bool canFire;
    playerController controller;
    // Start is called before the first frame update
    void Start()
    {
        canFire = true;
        controller = GetComponentInParent<playerController>();
    }

    private void fire()
    {
        IEnumerator Reload()
        {
            yield return new WaitForSeconds(reloadTime);
            canFire = true;
        }

        if (canFire)
        {
            Instantiate(bubbleBullet, transform.position, transform.rotation);
            canFire = false;
            StartCoroutine(Reload());
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            fire();
        }
    }
}
