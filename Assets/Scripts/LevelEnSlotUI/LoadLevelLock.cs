using SimpleJSON;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LoadLevelLock : MonoBehaviour {

    private int LevelsUnlocked;
    private int Score;
    GameObject Button1; 
    GameObject Button2;
    GameObject Button3;
    // Use this for initialization
    void Start () {
        Button1 = GameObject.Find("Level1");
        Button2 = GameObject.Find("Level2");
        Button3 = GameObject.Find("Level3");
    }

    public void Load(int SlotNr)
    {
        string path = Application.persistentDataPath + "/Saves/SaveFileSlot" + SlotNr + ".json";
        string JsonString = File.ReadAllText(path);
        JSONObject PlayerSafe = (JSONObject)JSON.Parse(JsonString);
        //Pakt de gegevens uit de file
        LevelsUnlocked = PlayerSafe["LevelsUnlocked"];
        Score = PlayerSafe["Score"];
    }

    public void SelectSlot(int SlotNr)
    {
        Button1.SetActive(false);
        Button2.SetActive(false);
        Button3.SetActive(false);
        Load(SlotNr);
        SaveLevel.SlotNrStatic = SlotNr;
        if(LevelsUnlocked == 1)
        {
            Button1.SetActive(true);
        }
        if (LevelsUnlocked == 2)
        {
            Button1.SetActive(true);
            Button2.SetActive(true);
        }
        if (LevelsUnlocked == 3)
        {
            Button1.SetActive(true);
            Button2.SetActive(true);
            Button3.SetActive(true);
        }
    }
}
