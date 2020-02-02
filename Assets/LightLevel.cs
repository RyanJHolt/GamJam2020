using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.LWRP;

// Assign this to the level's parent "Lights" object containing all the 2D Freeform Lights
public class LightLevel : MonoBehaviour {

    public Light2D[] lights;

    // Start is called before the first frame update
    void Start() {
        lights = GetComponentsInChildren<Light2D>();
    }

    // Update is called once per frame
    void Update() {

    }

    public void DimLights(float amount) {
        foreach (Light2D light in lights) {
            light.intensity -= amount;
        }
    }
}