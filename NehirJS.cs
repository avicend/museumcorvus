using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NehirJS : MonoBehaviour
{

    public GameObject trigger;
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("collided");
            trigger.SetActive(true);

        }

    }


}
