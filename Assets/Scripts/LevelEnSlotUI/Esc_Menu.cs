using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Esc_Menu : MonoBehaviour {

    GameObject Canvasje;
    bool Esc_Menu_Aan = false;

    private void Start()
    {
        Canvasje = GameObject.Find("Canvas");
        Canvasje.GetComponent<Canvas>().enabled = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Esc_Menu_Aan)
            {
                Canvasje.GetComponent<Canvas>().enabled = false;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                Time.timeScale = 1;
                Esc_Menu_Aan = !Esc_Menu_Aan;
            }
            else if(!Esc_Menu_Aan)
            {
                Canvasje.GetComponent<Canvas>().enabled = true;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                Time.timeScale = 0;
                Esc_Menu_Aan = !Esc_Menu_Aan;
            }
        }
    }

    public void Resume()
    {
        Canvasje.GetComponent<Canvas>().enabled = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1;
    }

    public void Options()
    {
        Canvasje.GetComponent<Canvas>().enabled = !Canvasje.GetComponent<Canvas>().enabled;
        GameObject.Find("Option_Screen").GetComponent<Canvas>().enabled = !GameObject.Find("Option_Screen").GetComponent<Canvas>().enabled;
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("HomeScreen");
    }
}
