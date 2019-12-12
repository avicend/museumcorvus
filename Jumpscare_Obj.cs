using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumpscare_Obj : MonoBehaviour
{
    public AudioClip scary_Sound;
    public AudioSource soundSource;
    public Animator anim;
    public bool alreadyPlayed = false;

    public GameObject scary_Daughter;

   
     void Start()
    {
        
        anim = GetComponent<Animator>();
        soundSource.clip = scary_Sound;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && !alreadyPlayed)
        {
            scary_Daughter.SetActive(true);
            soundSource.PlayOneShot(scary_Sound);
            alreadyPlayed = true;
			
            StartCoroutine(scare_effect());
            
        }
    }

    IEnumerator scare_effect()
    {
        yield return new WaitForSeconds(1f);
        scary_Daughter.SetActive(false);
    }
}
