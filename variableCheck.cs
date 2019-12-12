using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class variableCheck : MonoBehaviour
{
    public float variable_quiz;
    public GameObject quizPhobia;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        variable_quiz=quizPhobia.GetComponent<phobiaQuiz>().personPoint;
    }
}
