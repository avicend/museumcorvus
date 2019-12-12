using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.SceneManagement;


public class MicrowaveOpen : MonoBehaviour
{
    public GameObject alternative_check;
    public GameObject alt_Blood;
    public GameObject alt_Spider;
    public bool erko = false;
    public bool kari = false;
    public bool kara = false;
    public bool nine = false;

    public int surveyResult = 0;

    public bool toggleBlood = false;
    public bool toggleSpider = false;
    public bool toggleStorm = false;
    public bool toggleAmbiance = false;

    public bool flag = false;

    public bool enterTwice = false;

    public AudioSource bellSoundSource;

    public GameObject cameraDarken;
    public Animator cameraFade;

    /*public AudioClip SoundToPlay;
    public float Volume;
    AudioSource audio;
    public bool alreadyPlayed = false;*/

    public FirstPersonController fpsScript;

    public GameObject door;
    private DoorScript doorScript;
    
	private bool animEndFlag;

    void Start()
    {
        doorScript = door.GetComponent<DoorScript>();
        cameraFade = GetComponent<Animator>();
		animEndFlag = false;

        phobiaQuiz results = new phobiaQuiz();

        results.LoadSurvey();

        surveyResult = results.personPoint;

        toggleBlood = results.blood;
        toggleSpider = results.spider;
        toggleStorm = results.storm;
        toggleAmbiance = results.ambiance;

        

        
    }
    void Update()
    {

        if (toggleBlood)
        {
            alt_Blood.SetActive(true);
        
        }

         if (toggleSpider)
        {
            alt_Spider.SetActive(true);
        }
        if (toggleStorm)
        {

        }
         if (toggleAmbiance)
        {

        }

    

        /*if (surveyResult <= 50)
        {
            alt_Blood.SetActive(true);
        }

        else if (surveyResult > 50)
        {
            alt_Spider.SetActive(true);
        }*/
        
        if (!flag)
        {

            if (erko && kara && kari && nine )
            {
                door.GetComponent<BoxCollider>().enabled = false;
                doorScript.ChangeDoorState();
                
                bellSoundSource.Play();
                flag = true;
            }
        }

         
    }


    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKey(KeyCode.F))
        {

            if (other.gameObject.tag == "ErkebitStatue")
            {
                erko = true;
            }
            if (other.gameObject.tag == "AlkarısıStatue")
            {
                kari = true;
            }
            if (other.gameObject.tag == "KarakoncolosStatue")
            {
                kara = true;
            }
            if (other.gameObject.tag == "ÇayninesiStatue")
            {
                nine = true;
            }



        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="SlowArea")
        {
            Debug.Log(other.name);
            fpsScript.amISlowed = true;

            if (!enterTwice)
            {
                doorScript.ChangeDoorState();
                enterTwice = true;
            }
			
			cameraDarken.SetActive(true);
        cameraFade.Play("camera-darken");
		StartCoroutine(WaitForAnimation( cameraFade ));
            animEndFlag = true;
			Debug.Log("Stop!");
			

        }
		else {
			if (other.tag=="SlowAreaEnd") {
				Debug.Log("Animation should have ended");
				Destroy(cameraFade);
				SceneManager.UnloadSceneAsync("MuseumPart");
                //SceneManager.LoadSceneAsync("Part 2", LoadSceneMode.Additive);
                SceneManager.LoadSceneAsync("Demo1 Night", LoadSceneMode.Single);
				
			}
			
		}
    }
	
	private IEnumerator WaitForAnimation ( Animator anim )
{
    do
    {
        yield return null;
    } while (anim.GetCurrentAnimatorStateInfo(0).IsName("camera-darken") );
}


    



}
