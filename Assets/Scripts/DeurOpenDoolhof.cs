using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeurOpenDoolhof : MonoBehaviour
{
    private int DeurMoetOpen = 0;
    public float DeurCoordsOpen;
    public string AxisParent;
    private float Position;
    public float SnelheidInvoer;
    private float snelheid;
    private string richtingOpen;
    public float RequiresUnlocker;
    
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //  Selecteerd de juiste axis en geeft de positie.
        if (AxisParent == "X")
        {
            Position = gameObject.transform.GetChild(0).transform.localPosition.x;
            snelheid = SnelheidInvoer / gameObject.transform.localScale.x;
        }
        if (AxisParent == "Y")
        {
            Position = gameObject.transform.GetChild(0).transform.localPosition.y;
            snelheid = SnelheidInvoer / gameObject.transform.localScale.x;
        }
        if (AxisParent == "Z")
        {
            Position = gameObject.transform.GetChild(0).transform.localPosition.z;
            snelheid = SnelheidInvoer / gameObject.transform.localScale.x;
        }
        //  Activeren van de beweging functie
        if (DeurMoetOpen == 1 && DeurCoordsOpen > 0)
        {
            DeurPlus(DeurCoordsOpen, Position, AxisParent, snelheid);
        }
        if (DeurMoetOpen == 1 && DeurCoordsOpen < 0)
        {
            DeurMin(DeurCoordsOpen, Position, AxisParent, snelheid);
        }
        if (DeurMoetOpen == 0 && DeurCoordsOpen < 0)
        {
            DeurPlus(0, Position, AxisParent, snelheid);
        }
        if (DeurMoetOpen == 0 && DeurCoordsOpen > 0)
        {
            DeurMin(0, Position, AxisParent, snelheid);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (RequiresUnlocker > 0)
        {
            if (GameObject.Find("Player").GetComponent<PlayerMovement>().heeftCoin >= RequiresUnlocker)
            {
                DeurMoetOpen = 1;
            }
        }
        if(RequiresUnlocker == 0)
        {
            DeurMoetOpen = 1;
        }  
    }

    private void OnTriggerExit(Collider other)
    {
        DeurMoetOpen = 0;
    }

    public void DeurPlus(float DeurCoordsDoel, float Position, string Axis, float snelheid)
    {
        if (Position < DeurCoordsDoel)
        {
            Vector3 tempPlekkie = gameObject.transform.GetChild(0).transform.localPosition;
            if (Axis == "X")
            {
                tempPlekkie.x = tempPlekkie.x + snelheid;
            }
            if (Axis == "Y")
            {
                tempPlekkie.y = tempPlekkie.y + snelheid;
            }
            if (Axis == "Z")
            {
                tempPlekkie.z = tempPlekkie.z + snelheid;
            }
            gameObject.transform.GetChild(0).transform.localPosition = Vector3.Lerp(gameObject.transform.GetChild(0).transform.localPosition, tempPlekkie, Time.deltaTime);
        }
    }

    public void DeurMin(float DeurCoordsDoel, float Position, string Axis, float snelheid)
    {
        
        if (Position > DeurCoordsDoel)
        {
            Vector3 tempPlekkie = gameObject.transform.GetChild(0).transform.localPosition;
            if (Axis == "X")
            {
                tempPlekkie.x = tempPlekkie.x - snelheid;
            }
            if (Axis == "Y")
            {
                tempPlekkie.y = tempPlekkie.y - snelheid;
            }
            if (Axis == "Z")
            {
                tempPlekkie.z = tempPlekkie.z - snelheid;
            }
            gameObject.transform.GetChild(0).transform.localPosition = Vector3.Lerp(gameObject.transform.GetChild(0).transform.localPosition, tempPlekkie, Time.deltaTime);
        }
    }
}
