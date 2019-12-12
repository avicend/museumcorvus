using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class lastscene : MonoBehaviour
{
   
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" )
        {
            SceneManager.UnloadSceneAsync("MuseumPart Ending");
			SceneManager.LoadSceneAsync("Main Menu",LoadSceneMode.Single);
            
        }
    }
}
