using SimpleJSON;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class Bonus_level_unlock : MonoBehaviour
{
    public GameObject knoppie;
    // Update is called once per frame
    public void Check()
    {
        knoppie.SetActive(false);


        string pathLoad = Application.persistentDataPath + "/Saves/SaveFileSlot" + 1 + ".json";
        string JsonStringLoad = File.ReadAllText(pathLoad);
        JSONObject PlayerSafeLoad = (JSONObject)JSON.Parse(JsonStringLoad);
        if (0 < PlayerSafeLoad["score"])
        {
            knoppie.SetActive(true);
        }

        string pathLoad2 = Application.persistentDataPath + "/Saves/SaveFileSlot" + 2 + ".json";
        string JsonStringLoad2 = File.ReadAllText(pathLoad2);
        JSONObject PlayerSafeLoad2 = (JSONObject)JSON.Parse(JsonStringLoad2);
        if (0 < PlayerSafeLoad2["score"])
        {
            knoppie.SetActive(true);
        }
    }
}
