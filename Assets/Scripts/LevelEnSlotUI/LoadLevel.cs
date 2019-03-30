using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour {
    public string LevelName;

    //voor wanneer de player een NextLevelObject aanraakt
    private void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene(LevelName);
        Time.timeScale = 1;
    }

    //voor wanneer je met een button naar een ander level wilt
    public void ButtonNextLevel()
    {

        SceneManager.LoadScene(LevelName);
        Time.timeScale = 1;
    }
}
