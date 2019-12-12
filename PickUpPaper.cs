using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpPaper : MonoBehaviour
{
    public GameObject item;
    public GameObject tempParent;
    public Transform guide;
    public float flySeconds = 0.3f;

    Vector3 originalPosition;
    Vector3 originalRotation;
    Vector3 targetRotation;
    bool carrying = false;
    float flyStartedTimeStamp;

    public Camera vrCAM;


    void Start()
    {
        item.GetComponent<Rigidbody>().useGravity = true;
    }

    void Update()
    {
       

            if (carrying)
            {
                item.GetComponent<Rigidbody>().useGravity = false;
                item.GetComponent<Rigidbody>().isKinematic = true;
                float t = Mathf.InverseLerp(flyStartedTimeStamp, flyStartedTimeStamp + flySeconds, Time.time);
                item.transform.position = Vector3.Lerp(originalPosition, guide.transform.position, t);
                item.transform.rotation = Quaternion.Euler(Vector3.Lerp(originalRotation, targetRotation, t));
            }
        
        RaycastHit hit;
        Ray rayDirection = new Ray(vrCAM.transform.position, vrCAM.transform.forward);

        if (Physics.Raycast(rayDirection, out hit, 5))
        {

            if (Input.GetKeyDown(KeyCode.F))
            {
                    if (!carrying)
                    {
                        originalPosition = item.transform.position;
                        originalRotation = item.transform.rotation.eulerAngles;
                        targetRotation = new Vector3();
                        flyStartedTimeStamp = Time.time;
                        item.transform.parent = tempParent.transform;
                        carrying = true;
                    }
            }

            else if (Input.GetKeyUp(KeyCode.F))
            {
                carrying = false;
                item.GetComponent<Rigidbody>().useGravity = true;
                item.GetComponent<Rigidbody>().isKinematic = false;
                item.transform.parent = null;
                item.transform.position = guide.transform.position;
            }
           
        }
    }
    
        


  
   
}
