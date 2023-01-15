using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using Lean.Transition;
using UnityEngine;
using UnityEngine.UI;

public class SuggestManager : MonoBehaviour
{
    public Mask[] mask;
    public GameObject tab;
    public GameObject mainSuggestObject;
    public float delay, transDelay, multipValue;
    public bool a;
    private int phase = 1;
    private bool left = true;

    private void Start()
    {
        Debug.Log(tab.transform.position);
    }

    private void Update()
    {
        if (a)
        {
            a = !a;
            StartCoroutine(Animation());
        }
    }

    private float barMultiply;
    IEnumerator Animation()
    {
        yield return new WaitForSeconds(delay);
        //barMultiply = FindObjectOfType<SeasonMenuManager>().isOpen ? .6f : 0f;
        if (left)
        {
            switch (phase)
            {
                case 1:
                    mainSuggestObject.transform.localPositionTransition_x(-3.71875f * multipValue, transDelay);
                    //tab.transform.localPositionTransition_x(-0.4927083f + barMultiply, transDelay);
                    tab.transform.localPositionTransition_x(-94.6f, transDelay);
                    /*mask[0].enabled = false;
                    mask[1].enabled = true;*/
                    phase++;
                    break;
                case 2:
                    mainSuggestObject.transform.localPositionTransition_x(-3.71875f * 2 * multipValue, transDelay);
                    //tab.transform.localPositionTransition_x(-0.3957812f + barMultiply, transDelay);
                    tab.transform.localPositionTransition_x(-75.2f, transDelay);
                    /*mask[1].enabled = false;
                    mask[2].enabled = true;*/
                    phase++;
                    left = false;
                    break;
            }
        }
        else
        {
            switch (phase)
            {
                case 3:
                    mainSuggestObject.transform.localPositionTransition_x(0, transDelay / 2);
                    //tab.transform.localPositionTransition_x(-0.5925521f + barMultiply, transDelay);
                    tab.transform.localPositionTransition_x(-113.77f, transDelay / 2);
                    /*mainSuggestObject.transform.localPositionTransition_x(-3.71875f * multipValue, transDelay);
                    //tab.transform.localPositionTransition_x(-0.4927083f + barMultiply, transDelay);
                    tab.transform.localPositionTransition_x(-94.6f, transDelay);*/
                    /*mask[2].enabled = false;
                    mask[1].enabled = true;*/
                    phase -= 2;
                    left = true;
                    break;
                case 2:
                    mainSuggestObject.transform.localPositionTransition_x(0, transDelay);
                    //tab.transform.localPositionTransition_x(-0.5925521f + barMultiply, transDelay);
                    tab.transform.localPositionTransition_x(-113.77f, transDelay);
                    /*mask[1].enabled = false;
                    mask[0].enabled = true;*/
                    phase--;
                    left = true;
                    break;
            }
        }
        StartCoroutine(Animation());
    }

    private void ColorTab()
    {
        
    }
}
