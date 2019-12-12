using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRwalk : MonoBehaviour
{
    float distance = 5f;
    public GameObject fpsPlayer;

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown("w"))
            fpsPlayer.transform.position = transform.position + Camera.main.transform.forward * distance * Time.deltaTime;
        
        
    }
}
