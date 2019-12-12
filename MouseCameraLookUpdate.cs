﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCameraLookUpdate : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;
       
    }

    // Update is called once per frame
    void Update()
    {

        transform.position = Camera.main.ScreenToViewportPoint(Input.mousePosition);
    }
}
