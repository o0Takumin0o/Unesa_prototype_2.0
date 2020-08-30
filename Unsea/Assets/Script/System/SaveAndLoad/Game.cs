﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    public int CurrentLevel;
    private void Start()
    {
        CurrentLevel = SceneManager.GetActiveScene().buildIndex;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void ResetAll()
    {//Resetevery every thing that playerPrefs saved
        PlayerPrefs.DeleteAll();
    }

    public void ResetHightScore()
    {//ResetHightScore
        PlayerPrefs.DeleteKey("HightScore");
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