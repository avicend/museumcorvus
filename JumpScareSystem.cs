using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class JumpScareSystem : MonoBehaviour {

public GameObject ScareObject;
public string ScareObjectAnim;
public string JumscareAnim;
public AudioClip ScareSound;
    AudioSource audio;


	void Start(){
		
        ScareObject.GetComponent<Animation>().Stop(ScareObjectAnim);//stop looping (walk, run or any) animation on scare object
	}

	public void OnTriggerEnter (Collider other){
	    if (other.gameObject.tag == "Player") {
				
            ScareObject.GetComponent<Animation>().Play(ScareObjectAnim);//play stopped scare object animation
           
            gameObject.GetComponent<Animation>().Play(JumscareAnim);//play jumpscare animation
            

            audio.clip = ScareSound;                    //set scare sound
				audio.Play();                                           //play scare sound
				other.enabled = false;                      //disable collider for repeat scare
				
				StartCoroutine(ScaredWait());            //wait for destroy and sanity
		}
	}
	
	IEnumerator ScaredWait(){
		yield return new WaitForSeconds(3.0f);
		
		Destroy(this);
	}
}
