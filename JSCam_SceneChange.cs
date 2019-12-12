using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.SceneManagement;

public class JSCam_SceneChange : MonoBehaviour
{
	public GameObject NehirCam;
    public Camera mainCamera;
    public FirstPersonController playerScript;
    public GameObject FPSController;
	
	
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            
            
                StartCoroutine(CaySequence());
                
        }
       
    }
	
	
	IEnumerator CaySequence()
    {

        mainCamera.enabled = false;
        playerScript.enabled = false;
        NehirCam.SetActive(true);
        NehirCam.transform.position = FPSController.transform.position;
        
        yield return new WaitForSeconds(5.32f);
		mainCamera.enabled = true;
        playerScript.enabled = true;
        NehirCam.SetActive(false);
		
		//SceneManager.UnloadSceneAsync("Demo1 Night");
        SceneManager.LoadSceneAsync("BurningVillage", LoadSceneMode.Single);
        
        


    }
}
