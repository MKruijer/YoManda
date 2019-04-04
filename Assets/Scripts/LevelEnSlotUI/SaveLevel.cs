using SimpleJSON;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveLevel : MonoBehaviour {
    public int score;
    public int LevelUnlocked;
    public static int SlotNrStatic;

    private void Start()
    {
        if (!System.IO.File.Exists(Application.persistentDataPath + "/Saves"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/Saves");
        }
        //creeër de save directory en files
        if (!System.IO.File.Exists(Application.persistentDataPath + "/Saves/SaveFileSlot2.json"))
        {
            TestSave(2);
        }
        if (!System.IO.File.Exists(Application.persistentDataPath + "/Saves/SaveFileSlot1.json"))
        {
            TestSave(1);
        }
         
    }

    public void Save(int SlotNr, int LevelsUnlocked)
    {
        //checkt of de save file niet een hoger level opheeft geslagen
        string pathLoad = Application.persistentDataPath + "/Saves/SaveFileSlot" + SlotNr + ".json";
        string JsonStringLoad = File.ReadAllText(pathLoad);
        JSONObject PlayerSafeLoad = (JSONObject)JSON.Parse(JsonStringLoad);
        JSONObject PlayerSafe = new JSONObject();
        if (LevelsUnlocked > PlayerSafeLoad["LevelsUnlocked"])
        {
            //opslaan van level
            PlayerSafe.Add("LevelsUnlocked", LevelsUnlocked);
        }
        else
        {
            PlayerSafe.Add("LevelsUnlocked", PlayerSafeLoad["LevelsUnlocked"]);
        }
        if (score > PlayerSafeLoad["score"])
            {
                PlayerSafe.Add("score", score);
            }
            else
            {
                PlayerSafe.Add("score", PlayerSafeLoad["score"]);
            }

            //path
            string path = Application.persistentDataPath + "/Saves/SaveFileSlot" + SlotNr + ".json";
            File.WriteAllText(path, PlayerSafe.ToString());
        
    }
    //TestSave is voor het deleten en maken van de saves
   public void TestSave(int SlotNr)
    {
            //opslaan van gegevens
            JSONObject PlayerSafe = new JSONObject();
            PlayerSafe.Add("LevelsUnlocked", 1);
            PlayerSafe.Add("score", score);

            //path
            string path = Application.persistentDataPath + "/Saves/SaveFileSlot" + SlotNr + ".json";
            File.WriteAllText(path, PlayerSafe.ToString());
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.name == GameObject.Find("Player").name)
        {
            Save(SlotNrStatic, LevelUnlocked);
        }
    }
}
