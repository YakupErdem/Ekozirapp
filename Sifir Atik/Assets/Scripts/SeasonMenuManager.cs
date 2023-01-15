using System.Collections;
using System.Collections.Generic;
using Lean.Transition;
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
        if (!isOpen)menu.transform.positionTransition_x(0.3f, .1f);
        else menu.transform.positionTransition_x(0, .1f);
        //
        if (isOpen)
        {
            Invoke("SetBarClosed", .2f);
            barOpened.transform.localPositionTransition_x(-160.07f, .2f);
            whiteBar.transform.localPositionTransition_x(-109.79f, .2f);
        }
        else
        {
            whiteBar.SetActive(true);
            barClosed.SetActive(false);
            barOpened.transform.localPositionTransition_x(0, .2f);
            whiteBar.transform.localPositionTransition_x(60.74f, .2f);
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
