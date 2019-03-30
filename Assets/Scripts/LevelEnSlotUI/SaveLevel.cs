using SimpleJSON;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveLevel : MonoBehaviour {
    public int Score;
    public int LevelUnlocked;
    public static int SlotNrStatic;

    private void Start()
    {
        //creeër de save directory en files
        if (!System.IO.File.Exists(Application.persistentDataPath + "/Saves/SaveFileSlot1.json"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/Saves");
            //hierdoor is slot1 als eerste als je resume doet
            Save(2, 1);
            Save(1, 1);
        }
    }

    public void Save(int SlotNr, int LevelsUnlocked)
    {
        //opslaan van gegevens
        JSONObject PlayerSafe = new JSONObject();
        PlayerSafe.Add("LevelsUnlocked", LevelsUnlocked);
        PlayerSafe.Add("Score", Score);

        //path
        string path = Application.persistentDataPath + "/Saves/SaveFileSlot" + SlotNr + ".json";
        File.WriteAllText(path, PlayerSafe.ToString());
    }

    public void TestSave (int SlotNr)
    {
        //opslaan van gegevens
        JSONObject PlayerSafe = new JSONObject();
        PlayerSafe.Add("LevelsUnlocked", LevelUnlocked);
        PlayerSafe.Add("Score", Score);

        //path
        string path = Application.persistentDataPath + "/Saves/SaveFileSlot" + SlotNr + ".json";
        File.WriteAllText(path, PlayerSafe.ToString());
    }

    private void OnTriggerEnter(Collider other)
    {
        Save(SlotNrStatic, LevelUnlocked);
    }
}
