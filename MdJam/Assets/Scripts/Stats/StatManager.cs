using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatManager : MonoBehaviour
{
    #region Singleton
    private static StatManager instance;
    public static StatManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<StatManager>();
                if (instance == null)
                {
                    GameObject go = new GameObject();
                    go.name = "statManager";
                    instance = go.AddComponent<StatManager>();
                }
            }
            return instance;
        }
    }
    private void Awake()
    {
        if (instance)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }
    #endregion

    //stats de la partie du joueur
    #region statsMiniGamesPerso
    private int nbPatientsGardes = 0;
    public int NbPatientsGardes { get { return nbPatientsGardes; } }
    private int scoreQuestionAdulte =0;
    public int ScoreQuestionAdulte { get { return scoreQuestionAdulte; } }
    private int scoreQuestionEnfant =0;
    public int ScoreQuestionEnfant { get { return scoreQuestionEnfant; } }
    private bool patientAdulteGarde;
    private bool patientEnfantGarde;
    #endregion  

    //stats de toutes les games jouees
    #region statsMiniGamesGlobal
    private int nbtotalPremierChapitreJoues = 0;
    public int NbTotalPremierChapîtreJouees { get { return nbtotalPremierChapitreJoues; } }
    private int nbtotalSecondChapitreJoues = 0;
    public int NbTotalSecondChapîtreJouees { get { return nbtotalSecondChapitreJoues; } }
    private int nbtotalTroisiemeChapitreJoues = 0;
    public int NbtotalTroisiemeChapitreJoues { get { return nbtotalTroisiemeChapitreJoues; } }
    private int nbtotalQuatriemeChapitreJoues = 0;
    public int NbtotalQuatriemeChapitreJoues { get { return nbtotalQuatriemeChapitreJoues; } }
    private float patientsGardesMoy = 0;
    public float PatientsGardesMoy { get { return patientsGardesMoy; } }
    private float scoreQuestionMoyAdulte =0;
    public float ScoreQuestionMoyAdulte { get { return scoreQuestionMoyAdulte; } }
    private float scoreQuestionMoyEnfant =0;
    public float ScoreQuestionMoyEnfant { get { return scoreQuestionMoyEnfant; } }
    private int nbPatientAdulteGarde = 0;
    private int nbPatientEnfantGarde = 0;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void NewGameLaunched()
    {
        nbtotalPremierChapitreJoues++;
    }

    public void KeepPatient()
    {
        nbPatientsGardes++;
    }

    public void UpdatePatientMoy()
    {
        float res = (int) (patientsGardesMoy * (nbtotalPremierChapitreJoues-1));
        res += nbPatientsGardes;
        res = res/((float)nbtotalPremierChapitreJoues);
        patientsGardesMoy = res;
        nbPatientsGardes = 0;
    }

    public void UpdateScoreQuestionAdulte(int score)
    {
        nbtotalSecondChapitreJoues++;
        scoreQuestionAdulte = score;
        scoreQuestionMoyAdulte *= (nbtotalSecondChapitreJoues-1);
        scoreQuestionMoyAdulte += score;
        scoreQuestionMoyAdulte /= (float)nbtotalSecondChapitreJoues;
    }

    public void UpdateScoreQuestionEnfant(int score)
    {
        nbtotalTroisiemeChapitreJoues++;
        scoreQuestionEnfant = score;
        scoreQuestionMoyEnfant *= (nbtotalTroisiemeChapitreJoues - 1);
        scoreQuestionMoyEnfant += score;
        scoreQuestionMoyEnfant /= (float)nbtotalTroisiemeChapitreJoues;
    }

    public void SaveChild()
    {
        nbtotalQuatriemeChapitreJoues++;
        patientEnfantGarde = true;
        nbPatientEnfantGarde++;
    }

    public void ResetStats()
    {
        nbtotalPremierChapitreJoues = 0;
        nbtotalSecondChapitreJoues = 0;
        nbtotalTroisiemeChapitreJoues = 0;
        nbtotalQuatriemeChapitreJoues = 0;
        patientsGardesMoy = 0;
        scoreQuestionMoyAdulte = 0;
        scoreQuestionMoyEnfant = 0;
        nbPatientAdulteGarde = 0;
        nbPatientEnfantGarde = 0;
    }

}
