
using System;
using System.Timers;
using TMPro;

using UnityEngine;


public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    private TMP_Text levelScore;
    [SerializeField]
    private TMP_Text finalScore;
    private static float LScore;

    public void Awake()
    {
        if(levelScore != null) UpdateScoreUI();
        if (finalScore != null) UpdateFinalSCore(finalScore);

    }

    // Set UI score in Game complete scene
    public void UpdateScoreUI()
    {
        if (levelScore != null)
        {
            levelScore.text = " Score: " + LScore.ToString();
        }
    }

    public void ScoreUpdate(float RemSeconds)
    {
        LScore = 10 * RemSeconds;
        UpdateScoreUI();

    }
    public float FinalScoreCalculation()
    {
        return Math.Max(0, Timer.Instance.Sec) * LScore;
    }

    public void UpdateFinalSCore(TMP_Text text)
    {
        text.text = "Final Score : "+FinalScoreCalculation();
    }
    

}
