using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeurOpenDoolhof : MonoBehaviour
{

    GameObject player;
    public int DeurMoetOpen = 0;
    public int DeurYOpen;
    public int DeurYDicht;
    public string DeurYRichting;
    public float snelheid = 10;
    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("Player");
        if (GameObject.Find("Door_6") == gameObject)
        {
            DeurYRichting = "Min";
            DeurYOpen = -10;
            DeurYDicht = 1;
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (player.transform.position.z > -102 && player.transform.position.z < -96)
        {
            DeurMoetOpen = 1;
        }
        else
        {
            DeurMoetOpen = 0;
        }

        if (DeurMoetOpen == 1)
        {
            DeurOpen(DeurYOpen);
        }
        if (DeurMoetOpen == 0)
        {
            DeurDicht(DeurYDicht);
        }
    }

    public void DeurOpen(int DeurYOpen)
    {
        if (gameObject.transform.position.y < DeurYOpen && DeurYRichting == "Plus")
        {
            Vector3 tempPlekkie = transform.position;
            tempPlekkie.y++;
            transform.position = tempPlekkie;
        }

        if (gameObject.transform.position.y > DeurYOpen && DeurYRichting == "Min")
        {
            Vector3 tempPlekkie = transform.position;
            tempPlekkie.y = tempPlekkie.y - snelheid;
            transform.localPosition = Vector3.Lerp(transform.localPosition, tempPlekkie , Time.deltaTime);
            //transform.position = tempPlekkie;
        }
    }

    public void DeurDicht(int DeurYDicht)
    {
        if (gameObject.transform.position.y < DeurYDicht && DeurYRichting == "Min")
        {
            Vector3 tempPlekkie = transform.position;
            tempPlekkie.y = tempPlekkie.y + snelheid;
            transform.localPosition = Vector3.Lerp(transform.localPosition, tempPlekkie, Time.deltaTime);
        }

        if (gameObject.transform.position.y > DeurYDicht && DeurYRichting == "Plus")
        {
            Vector3 tempPlekkie = transform.position;
            tempPlekkie.y--;
            transform.position = tempPlekkie;
        }
    }
}
