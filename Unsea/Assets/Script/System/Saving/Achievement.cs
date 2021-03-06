﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Achievement : MonoBehaviour
{
    SubCollector subCollector;
    PlayerCtrl playerCtrl;
    Timer timer;
    
    int collectAllPoint;
    [HideInInspector] // hide this from inspecter
    public int FinishInTime;
    [HideInInspector]
    public int WinLevel;

    public GameObject FinishLevel_Icon;
    public GameObject WinInTime_Icon;
    public GameObject GetAllPoint_Icon;
    int CurrentLevel;
    

    // Start is called before the first frame update
    void Start()
    {
        subCollector = GameObject.Find("CollectorManager").GetComponent<SubCollector>();
        playerCtrl = GameObject.Find("Player").GetComponent<PlayerCtrl>();
        timer = GameObject.Find("TimeManager").GetComponent<Timer>();
        CurrentLevel = SceneManager.GetActiveScene().buildIndex;
        //game = GameObject.Find("Game").GetComponent<Game>();
        
        
        GetAllPoint_Icon.SetActive(false);
        WinInTime_Icon.SetActive(false);
        FinishLevel_Icon.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        FinishInTime = PlayerPrefs.GetInt("FinishInTime" + CurrentLevel.ToString());
        collectAllPoint = PlayerPrefs.GetInt("collectAllPoint" + CurrentLevel.ToString());
        WinLevel = PlayerPrefs.GetInt("WinLevel" + CurrentLevel.ToString());
        //Debug.Log("CurrentLevel = " + CurrentLevel);

        finishLevel();
        if (playerCtrl.LevelEnd == true|| FinishInTime == 1)
        {
            EndBeforeTimer();
        }
        AllPointGet();

    }
    void AllPointGet()
    {
        if(subCollector.HightScore == 10|| collectAllPoint == 1)
        {
            GetAllPoint_Icon.SetActive(true);
            PlayerPrefs.SetInt("collectAllPoint" + CurrentLevel.ToString(), 1);
            Debug.Log("AllPointGet");
            if (playerCtrl.LevelEnd == true )
            {
                PlayerPrefs.Save();
            }            
        }
    }
    void EndBeforeTimer()
    {
        if(timer.WinBeforeTimeOut == true || FinishInTime == 1)
        {
           WinInTime_Icon.SetActive(true);
           PlayerPrefs.SetInt("FinishInTime" + CurrentLevel.ToString(), 1);
           Debug.Log("FinishInTime");

           PlayerPrefs.Save();    
        }
    }
    void finishLevel()
    {
        if(playerCtrl.LevelEnd == true || WinLevel ==1)
        {
            FinishLevel_Icon.SetActive(true);
            PlayerPrefs.SetInt("WinLevel" + CurrentLevel.ToString(), 1);
            Debug.Log("finishLevel");
            PlayerPrefs.Save();
        }
    }
}
