using System.Collections;
using System.Collections.Generic;
using Lean.Transition;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class SeasonMenuManager : MonoBehaviour
{
    public GameObject menu;

    public bool isOpen;
    public GameObject seasonIcons;
    
    public GameObject barClosed, barOpened;
    public Sprite opened, closed;
    public GameObject whiteBar;

    public void Interact()
    {
        Debug.Log("Menu is " + (isOpen ? "Closed" : "Opened"));
        //
        if (!isOpen)menu.transform.positionTransition_x(1f, .2f);
        else menu.transform.positionTransition_x(0, .2f);
        //
        if (isOpen)
        {
            Invoke("SetBarClosed", .15f);
            barOpened.transform.localPositionTransition_x(-125.04f, .2f);
            whiteBar.transform.localPositionTransition_x(-109.79f, .2f);
        }
        else
        {
            whiteBar.SetActive(true);
            barClosed.SetActive(false);
            barOpened.transform.localPositionTransition_x(40, .2f);
            whiteBar.transform.localPositionTransition_x(87.88f, .2f);
            Invoke("OpenSeasonIcons", 0);
        }
        //
        isOpen = !isOpen;
    }


    private void SetBarClosed()
    {
        seasonIcons.SetActive(false);
        barClosed.SetActive(true);
        whiteBar.SetActive(false);
    } 

    private void OpenSeasonIcons() => seasonIcons.SetActive(true);
}
