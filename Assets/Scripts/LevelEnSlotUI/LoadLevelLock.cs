using SimpleJSON;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LoadLevelLock : MonoBehaviour {

    private int LevelsUnlocked;
    private int Score;
    GameObject Button2;
    GameObject Button3;
    GameObject Button4;
    GameObject Button5;
    GameObject Button6;
    // Use this for initialization
    void Start () {
        Button2 = GameObject.Find("Level2");
        Button3 = GameObject.Find("Level3");
        Button4 = GameObject.Find("Level4");
        Button5 = GameObject.Find("Level5");
        Button6 = GameObject.Find("Level6");
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
        Load(SlotNr);
        SaveLevel.SlotNrStatic = SlotNr;
        if(LevelsUnlocked == 1)
        {
            Button2.SetActive(false);
            Button3.SetActive(false);
            Button4.SetActive(false);
            Button5.SetActive(false);
            Button6.SetActive(false);
        }
        if (LevelsUnlocked == 2)
        {
            Button3.SetActive(false);
            Button4.SetActive(false);
            Button5.SetActive(false);
            Button6.SetActive(false);
        }
        if (LevelsUnlocked == 3)
        {
            Button4.SetActive(false);
            Button5.SetActive(false);
            Button6.SetActive(false);
        }
        if (LevelsUnlocked == 4)
        {
            Button5.SetActive(false);
            Button6.SetActive(false);
        }
        if (LevelsUnlocked == 5)
        {
            Button6.SetActive(false);
        }
    }
}
