using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System;

public class Timer : MonoBehaviour 
{

    private static Timer instance;
    public static Timer Instance;    

    public Image LoadingImage;
  
    public TextMeshProUGUI TimeLeft;
   


    private int RemainingTime;
    public int Sec;

    private int startTime = 00;

    private int TOTAL_SEC = 0;
    private int TotalSec = 0;
    float FillAmount;
    [SerializeField]
    private ScoreManager scoreManager;

    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(this);
        else
            Instance = this;

     
    }

   public void Start()
    {
        TimeLeft.text = Sec.ToString();

        if(Sec>0)
            TotalSec = Sec;
        TOTAL_SEC = TotalSec;

        StartCoroutine(second());
        StartCoroutine(timespent());

    }

    public void Update()
    {
        if (Sec <= 0)
        {
            TimeLeft.text = "Time's Up";
            SceneManager.LoadScene(2);
          StopCoroutine(second());

        }

        if (Sec == TotalSec)
        {
            StopCoroutine(timespent());

        }
    }

    IEnumerator second()
    {
        yield return new WaitForSeconds(1f);
        if (Sec > 0)
            Sec--;

        TimeLeft.text = Sec.ToString();
        scoreManager.ScoreUpdate(Sec);
        UpdateLoadingUI(Sec);
        StartCoroutine(second());

    }

    public void ReduceTimer(int val)
    {
        Sec -= val;
    }

    IEnumerator timespent()
    {
        yield return new WaitForSeconds(1f);
            if (startTime < 30)
            startTime++;     
       
        StartCoroutine (timespent());
;    }

    public void UpdateLoadingUI(float secs)
    {
        float fill = (float)secs / TOTAL_SEC;
       LoadingImage.fillAmount = fill;
    }


  
    

}
