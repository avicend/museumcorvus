using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CayNinesiScene : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
        {
            
                
                    if (other.gameObject.CompareTag("Player"))
                    {
                        SceneManager.UnloadSceneAsync("MultiLevel_House");
                        SceneManager.LoadSceneAsync("CayNinesiScene", LoadSceneMode.Single);
                    }
                
            
        }
}
