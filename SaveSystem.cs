using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveSystem
{
    public static void SaveSurvey(phobiaQuiz quiz)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/survey.fun";

        FileStream stream = new FileStream(path, FileMode.Create);

        SurveyData data = new SurveyData(quiz);

        formatter.Serialize(stream,data);
        stream.Close();
    }

    public static SurveyData LoadSurvey()
    {
        string path = Application.persistentDataPath + "/survey.fun";

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();

            FileStream stream = new FileStream(path, FileMode.Open);

            SurveyData data =formatter.Deserialize(stream) as SurveyData;

            stream.Close();

            return data;

        }
        else
        {
            Debug.LogError("Save file not found in" + path);
            return null;
        }
    }

}
