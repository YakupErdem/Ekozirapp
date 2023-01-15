using System.Collections;
using System.Collections.Generic;
using Lean.Transition;
using UnityEngine;
using UnityEngine.Serialization;

public class RecipeMenuManager : MonoBehaviour
{
        public GameObject menu;

        public GameObject button;
        public Vector3 parent1, parent2;

        public float extra;
        
        public bool isOpen;
        public GameObject recipeParts;
        
        public GameObject barClosed, barOpened;
        public GameObject whiteBar;

        public Canvas c1, c2;
    
        public void Interact()
        {
            Debug.Log("Menu is " + (isOpen ? "Closed" : "Opened"));
            //
            if (!isOpen)menu.transform.positionTransition_x(0.3f, .1f);
            else menu.transform.positionTransition_x(0, .1f);
            //
            if (isOpen)
            {
                Invoke(nameof(ChangeLayer), .2f);
                //
                button.transform.localPosition = parent1;
                //
                Invoke(nameof(SetBarClosed), .2f);
                barOpened.transform.localPositionTransition_x(-160.07f, .2f);
                whiteBar.transform.localPositionTransition_x(-109.79f, .2f);
            }
            else
            {
                c1.sortingOrder = 1;
                c2.sortingOrder = 0;
                //
                button.transform.localPosition = parent2;
                //
                whiteBar.SetActive(true);
                barClosed.SetActive(false);
                barOpened.transform.localPositionTransition_x(0  + extra, .2f);
                whiteBar.transform.localPositionTransition_x(60.74f + extra, .2f);
                Invoke(nameof(OpenSeasonIcons), 0);
            }
            //
            isOpen = !isOpen;
        }
        
    
        private void SetBarClosed()
        {
            recipeParts.SetActive(false);
            barClosed.SetActive(true);
            whiteBar.SetActive(false);
        }

        private void ChangeLayer()
        {
            c1.sortingOrder = 0;
            c2.sortingOrder = 1;
        } 
        private void OpenSeasonIcons() => recipeParts.SetActive(true);
}
