using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class phobiaQuiz : MonoBehaviour
{
    public int personPoint=0;
    public bool blood=false;
    public bool spider=false;
    public bool storm=false;
    public bool ambiance = false;

    private void Start()
    {
        Cursor.visible = false;
        
    }
    public void AddPoints()
    {
        personPoint += 10;
    }

    public void SpiderPoint()
    {
        personPoint += 50;
    }

    public void toggleBlood()
    {
        blood = true;
    }

    public void toggleSpider()
    {
        
        spider = true;
    }

    public void toggleStorm()
    {
        storm = true;
    }

    public void toggleAmbiance()
    {
        ambiance = true;
    }

    public void SaveSurvey()
    {
        SaveSystem.SaveSurvey(this);
        SceneManager.UnloadScene("PhobiaQuiz");
        SceneManager.LoadScene("MuseumPart", LoadSceneMode.Single);
    }

    public void LoadSurvey()
    {
        SurveyData data = SaveSystem.LoadSurvey();

        personPoint = data.surveyPoints;

        blood = data.surveyBlood;
        spider = data.surveySpider;
        storm = data.surveyStorm;
        ambiance = data.surveyAmbiance;
    }
}
