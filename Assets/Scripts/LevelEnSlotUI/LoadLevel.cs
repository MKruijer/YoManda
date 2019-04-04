﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour {
    public string LevelName;

    //voor wanneer de player een NextLevelObject aanraakt
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == GameObject.Find("Player").name)
        {
            SceneManager.LoadScene(LevelName);
            Time.timeScale = 1;
            GameObject.Find("Player").GetComponent<PlayerMovement>().heeftCoin = 0;
        }
    }

    //voor wanneer je met een button naar een ander level wilt
    public void ButtonNextLevel()
    {

        SceneManager.LoadScene(LevelName);
        Time.timeScale = 1;
        GameObject.Find("Player").GetComponent<PlayerMovement>().heeftCoin = 0;
    }
}
