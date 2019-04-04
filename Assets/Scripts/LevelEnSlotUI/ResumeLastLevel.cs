using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using SimpleJSON;
using System.Linq;
using UnityEngine.SceneManagement;

public class ResumeLastLevel : MonoBehaviour {

    public static int SlotNrStatic;
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
        int score = PlayerSafe["score"];
        //laad de scene
        SceneManager.LoadScene(LevelsUnlocked);
        Time.timeScale = 1;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.name == GameObject.Find("Player").name)
        {
            //opslaan van gegevens
            JSONObject PlayerSafe = new JSONObject();
            PlayerSafe.Add("LevelsUnlocked", 7);
            PlayerSafe.Add("score", 10);

            //path
            string path = Application.persistentDataPath + "/Saves/SaveFileSlot" + SlotNrStatic + ".json";
            File.WriteAllText(path, PlayerSafe.ToString());
        }
    }
}
