using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SurveyData
{
    public int surveyPoints;

    public bool surveyBlood=false;
    public bool surveySpider = false;
    public bool surveyStorm = false;
    public bool surveyAmbiance = false;

    public SurveyData(phobiaQuiz quiz)
    {
        surveyPoints = quiz.personPoint;

        surveyBlood = quiz.blood;
        surveySpider = quiz.spider;
        surveyStorm = quiz.storm;
        surveyAmbiance = quiz.ambiance;
        
    }
}
