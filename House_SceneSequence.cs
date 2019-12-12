using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class House_SceneSequence : MonoBehaviour
{
	public GameObject DialogueCam;
    public Camera mainCamera;
    public FirstPersonController playerScript;
    public GameObject FPSController;
	public GameObject cameraDarken;
	public Animator cameraFade;
	public GameObject Erkebit;
	public GameObject Spawner;
	public GameObject Bed;
	public GameObject Grandpa;
    
    // Start is called before the first frame update
    void Start()
    {
     cameraFade = GetComponent<Animator>();   
    }
	
	void StopErkebit(){
		Erkebit.SetActive(false);
		FPSController.transform.position = Spawner.transform.position;
		playerScript.enabled = true;
	}
	void StopFade(){
		cameraDarken.SetActive(false);
		
	}
	void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            
            
                StartCoroutine(HouseSequence());
				Destroy(other);
				
                
            
        }
	}
	IEnumerator HouseSequence()
    {

        mainCamera.enabled = false;
        playerScript.enabled = false;
        DialogueCam.SetActive(true);
		
        //DialogueCam.transform.position = FPSController.transform.position;
        
        yield return new WaitForSeconds(83.32f);
		
		cameraDarken.SetActive(true);
        cameraFade.Play("camera-darken");
		yield return new WaitForSeconds(5.32f);
		cameraDarken.SetActive(false);
		DialogueCam.SetActive(false);
		//StartCoroutine(WaitForAnimation( cameraFade ));
		//cameraDarken.SetActive(false);
        //mainCamera.enabled = true;
        //playerScript.enabled = true;
        mainCamera.enabled = true;
		FPSController.transform.position = Bed.transform.position;
		
		Erkebit.SetActive(true);
		FPSController.transform.position = Spawner.transform.position;
		yield return new WaitForSeconds(7.32f);
		Erkebit.SetActive(false);
		
		playerScript.enabled = true;
		Destroy(Grandpa);
		
		
        
        
        
    }
	/*private IEnumerator WaitForAnimation ( Animator anim )
{
    do
    {
        yield return new WaitForSeconds(5.0f);
    } while (anim.GetCurrentAnimatorStateInfo(0).IsName("camera-darken") );
}
*/
    // Update is called once per frame
    void Update()
    {
        
    }
}
