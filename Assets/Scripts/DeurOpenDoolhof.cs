using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeurOpenDoolhof : MonoBehaviour
{

    GameObject player;
    public int DeurMoetOpen = 0;
    public float DeurYOpen;
    public float DeurYDicht;
    public string DeurYRichting;
    public float snelheid = 10;
    public GameObject DeurZelfe;
    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (DeurMoetOpen == 1)
        {
            DeurOpen(DeurYOpen);
        }
        if (DeurMoetOpen == 0)
        {
            DeurDicht(DeurYDicht);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //if (GameObject.Find("Player").GetComponent<PlayerMovement>().heeftCoin == 1)
        {
            DeurMoetOpen = 1;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        DeurMoetOpen = 0;
    }

    public void DeurOpen(float DeurYOpen)
    {
        if (DeurZelfe.transform.position.y < DeurYOpen && DeurYRichting == "Plus")
        {
            Vector3 tempPlekkie = DeurZelfe.transform.position;
            tempPlekkie.y = tempPlekkie.y + snelheid;
            DeurZelfe.transform.localPosition = Vector3.Lerp(DeurZelfe.transform.localPosition, tempPlekkie, Time.deltaTime);
        }

        if (DeurZelfe.transform.position.y > DeurYOpen && DeurYRichting == "Min")
        {
            Vector3 tempPlekkie = DeurZelfe.transform.position;
            tempPlekkie.y = tempPlekkie.y - snelheid;
            DeurZelfe.transform.position = Vector3.Lerp(DeurZelfe.transform.localPosition, tempPlekkie , Time.deltaTime);
            //transform.position = tempPlekkie;
        }
    }

    public void DeurDicht(float DeurYDicht)
    {
        if (DeurZelfe.transform.position.y < DeurYDicht && DeurYRichting == "Min")
        {
            Vector3 tempPlekkie = DeurZelfe.transform.position;
            tempPlekkie.y = tempPlekkie.y + snelheid;
            DeurZelfe.transform.localPosition = Vector3.Lerp(DeurZelfe.transform.localPosition, tempPlekkie, Time.deltaTime);
        }

        if (DeurZelfe.transform.position.y > DeurYDicht && DeurYRichting == "Plus")
        {
            Vector3 tempPlekkie = DeurZelfe.transform.position;
            tempPlekkie.y = tempPlekkie.y - snelheid;
            DeurZelfe.transform.localPosition = Vector3.Lerp(DeurZelfe.transform.localPosition, tempPlekkie, Time.deltaTime);
        }
    }
}
