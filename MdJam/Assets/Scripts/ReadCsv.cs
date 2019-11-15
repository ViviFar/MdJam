using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;

[SerializeField]
public class QuestionsData
{

    public string[] data_question;

    public QuestionsData()
    {
        data_question = new string[6];
    }
}

public class ReadCSV : MonoBehaviour
{

    #region Singleton
    private static ReadCSV instance = null;
    public static ReadCSV Instance
    {
        get
        {
            return instance;
        }
    }
    #endregion
    public TextAsset cvsFile;
    [SerializeField]
    public List<QuestionsData> QuestionsPatient = new List<QuestionsData>();
    public List<QuestionsData> QuestionsMerePatient = new List<QuestionsData>();



    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else Destroy(this);

        ReadCSVFile(Application.dataPath + " /Resources/questions_math.csv", State.QuestionPatient);
        ReadCSVFile(Application.dataPath + " /Resources/questions_histoire_2R.csv", State.QuestionMerePatient);
    }


    // Start is called before the first frame update
    void Start()
    {

    }

    public void ReadCSVFile(string path, State pourQui)
    {
        if(pourQui !=  State.QuestionMerePatient || pourQui != State.QuestionPatient)
        {
            Debug.LogError("ReadCsv n'est pas appele au bon moment");
            return;
        }

        StreamReader StrReader = new StreamReader(path);

        bool enOfFile = false;
        while (!enOfFile)
        {
            string data_string = StrReader.ReadLine();

            if (data_string == null)
            {
                enOfFile = true;
                return;
            }



            string[] datas = data_string.Split(',');

            QuestionsData temp_questions = new QuestionsData();


            for (int i = 0; i < datas.Length; i++)
            {

                temp_questions.data_question[i] = datas[i];

            }

            switch (pourQui)
            {
                case State.QuestionPatient:
                    QuestionsPatient.Add(temp_questions);
                    break;
                case State.QuestionMerePatient:
                    QuestionsMerePatient.Add(temp_questions);
                    break;
                default:
                    break;
            }
            Debug.Log(QuestionsPatient[0].data_question[1]);
        }


    }
}
