using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Choice : MonoBehaviour
{
    public GameObject Question;
    public GameObject canvasQuestion;

    public Button Choice01;
    public Button Choice02;
    public Button Choice03;


    public int ChoiceMode;

    public GameObject Candle1_f1;

    public GameObject Candle2_f1;

    public GameObject Candle3_f1;

    public GameObject Candle4_f1;
    
    private int question_counter = 0;

    void Start()
    {
        
        Choice01.onClick.AddListener(() => { AfterClick(Choice01); });
        Choice02.onClick.AddListener(() => { AfterClick(Choice02); });
        Choice03.onClick.AddListener(() => { AfterClick(Choice03); });
        Question.GetComponent<Text>().text = "Who are you running from? Ahhh I know from Al Karisi...Al Karisi only eat puppies, the cleanest ones. The most innocent ones... So you know why? So they will not sink into the darkness. HAHAHAHA you will never understand this you selfish creature!  I am here to question the demons like you and prove to him that you did not deserve to live.";
        Choice01.GetComponentInChildren<Text>().text = "What do you want from me?";
        Choice02.GetComponentInChildren<Text>().text = "Who are you?";
        Choice03.GetComponentInChildren<Text>().text = "I didn't do anything to anyone.";
        Choice01.tag = "Q_true";
        Choice02.tag = "Q_false";
        Choice03.tag = "Q_false";
    }



    public void AfterClick(Button sender)
    {


        if (question_counter == 0)
        {
            Question.GetComponent<Text>().text = "Don't worry, if you can answer my questions correctly, you're free to go, you impotent creature ... He kills the cleanest, chooses the ones in the whites and liberates them. And why would he do that?";
            Choice01.GetComponentInChildren<Text>().text = "To save the light";
            Choice02.GetComponentInChildren<Text>().text = "To put an end to the darkness";
            Choice03.GetComponentInChildren<Text>().text = "For himself";
            Choice01.tag = "Q_true";
            Choice02.tag = "Q_false";
            Choice03.tag = "Q_false";
            if (sender != null && !sender.CompareTag("Q_true"))
            {
                Candle1_f1.SetActive(false);
            }

        }

        else if (question_counter == 1)
        {
            Question.GetComponent<Text>().text = "No one can restrain me, I will be there whenever I want. I haven't had any shape whatsoever. In both worlds they are afraid of me, they can not approach. They both want to get rid of me as well. Now tell me, you know me from clay?";
            Choice01.GetComponentInChildren<Text>().text = "Love";
            Choice02.GetComponentInChildren<Text>().text = "Fire";
            Choice03.GetComponentInChildren<Text>().text = "Longing";
            Choice01.tag = "Q_true";
            Choice02.tag = "Q_false";
            Choice03.tag = "Q_false";
            if (sender != null && !sender.CompareTag("Q_true"))
            {
                Candle2_f1.SetActive(false);
            }
        }

        else if (question_counter == 2)
        {
            Question.GetComponent<Text>().text = "I will never stop at my place. No one can touch me or feel me. I can't see, but no one can escape from me. I can't hear, but no one can talk about me. I encompass the wrath of fear, I make them beg for mercy. I never forgive, but I don't hold a grudge. Who am I?";
            Choice01.GetComponentInChildren<Text>().text = "Darkness";
            Choice02.GetComponentInChildren<Text>().text = "Frost";
            Choice03.GetComponentInChildren<Text>().text = "Karakoncolos";
            Choice01.tag = "Q_true";
            Choice02.tag = "Q_false";
            Choice03.tag = "Q_false";
            if (sender != null && !sender.CompareTag("Q_true"))
            {
                Candle3_f1.SetActive(false);
            }
        }

        else if (question_counter == 3)
        {
            
            if (sender != null && !sender.CompareTag("Q_true"))
            {
                Candle4_f1.SetActive(false);
            }
            canvasQuestion.SetActive(false);
			
			SceneManager.UnloadScene("Karacong");
			SceneManager.LoadScene("MuseumPart Ending",LoadSceneMode.Single);
        }       
        question_counter++;
		
		
			
		

    }
    public void ChoiceOption01()
    {
        // Question.GetComponent<Text>().text = "First Choice";
        ChoiceMode = 1;
    }
    public void ChoiceOption02()
    {
        //Question.GetComponent<Text>().text = "Second Choice";
        ChoiceMode = 2;
    }
    public void ChoiceOption03()
    {
        // Question.GetComponent<Text>().text = "Third Choice";
        ChoiceMode = 3;
    }



}
