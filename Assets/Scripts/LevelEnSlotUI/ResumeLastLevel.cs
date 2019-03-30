using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using SimpleJSON;
using System.Linq;
using UnityEngine.SceneManagement;

public class ResumeLastLevel : MonoBehaviour {

    public void LoadLastSave()
    {
        //sorteerd de saveslots en geeft de meest recent gewijzigde
        var file = new DirectoryInfo(Application.persistentDataPath +"/Saves")
                .GetFiles()
                .OrderByDescending(f => f.LastWriteTime)
                .FirstOrDefault();
        //transformeert de FileInfo naar een string
        string JsonString = File.ReadAllText(file.FullName);
        //halt de gegevens uit de file
        JSONObject PlayerSafe = (JSONObject)JSON.Parse(JsonString);
        int LevelsUnlocked = PlayerSafe["LevelsUnlocked"];
        int Score = PlayerSafe["Score"];
        //laad de scene
        SceneManager.LoadScene(LevelsUnlocked);
        Time.timeScale = 1;
    }
}
