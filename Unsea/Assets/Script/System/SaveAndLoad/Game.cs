﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    int CurrentLevel;
    private GameManager GM;


    private void Start()
    {
        CurrentLevel = SceneManager.GetActiveScene().buildIndex;
        GM = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if (Input.GetKeyDown(KeyCode.Y))
        {
            ResetCheckpoint();
        }

    }

    public void ResetAll()
    {//Resetevery every thing that playerPrefs saved
        PlayerPrefs.DeleteAll();
        DeleteAllProgress();
    }

    public void ResetHightScore()
    {//ResetHightScore
        PlayerPrefs.DeleteKey("HightScore" + CurrentLevel.ToString());
    }
    public void ResetCheckpoint()
    {
        PlayerPrefs.DeleteKey("saveMainPoint" + CurrentLevel.ToString());
        PlayerPrefs.DeleteKey("SavedScore" + CurrentLevel.ToString());
        PlayerPrefs.DeleteKey("TimeWhenHitCheckpoint" + CurrentLevel.ToString());
        PlayerPrefs.DeleteKey("hasCrabArmor" + CurrentLevel.ToString());
        GM.resetCheckPoint();
        DeleteAllProgress();
    }
    public void ResetBestTimer()
    {
        PlayerPrefs.DeleteKey("BestTime" + CurrentLevel.ToString());

    }
    public void Save()
    {
        GameEvents.OnSaveInitiated();
    }

    public void DeleteAllProgress()
    {
        SaveLoad.SeriouslyDeleteAllSaveFiles();
    }
}
