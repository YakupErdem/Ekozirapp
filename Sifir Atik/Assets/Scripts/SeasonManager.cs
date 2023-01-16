using System;
using System.Collections;
using System.Collections.Generic;
using Lean.Transition;
using UnityEngine;
using UnityEngine.UI;

public class SeasonManager : MonoBehaviour
{
    public Dropdown dropDown;
    public MonthSeason[] monthSeasons;
    
    [System.Serializable]
    public struct MonthSeason
    {
        public List<string> names;
        public Content.Season season;
    }

    private void Start()
    {
        dropDown.ClearOptions();
        foreach (var m in monthSeasons)
        {
            if (m.season == Content.Season.Spring)
            {
                dropDown.AddOptions(m.names);
            }
        }
    }

    public void ChangeSeason(string season)
    {
        FindObjectOfType<MainAnimator>().Animate();
        FindObjectOfType<SeasonMenuManager>().Interact();
        Debug.Log("Season changed to " + season);
        switch (season)
        {
            case "Summer":
                FindObjectOfType<ContentSearch>().selectedSeason = AddOption(Content.Season.Summer);
                break;
            case "Autumn":
                FindObjectOfType<ContentSearch>().selectedSeason = AddOption(Content.Season.Autumn);
                break;
            case "Spring":
                FindObjectOfType<ContentSearch>().selectedSeason = AddOption(Content.Season.Spring);
                break;
            case "Winter":
                FindObjectOfType<ContentSearch>().selectedSeason = AddOption(Content.Season.Winter);
                break;
        }
        FindObjectOfType<ContentSearch>().Suggest();
        Content.Season AddOption (Content.Season s)
        {
            FindObjectOfType<ContentsManager>().LoadContents(s);
            //
            dropDown.ClearOptions();
            foreach (var m in monthSeasons)
            {
                if (m.season == s)
                {
                    dropDown.AddOptions(m.names);
                }
            }
            return s;
        }
    }

    public void ButtonAnimation(GameObject button) => StartCoroutine(ButtonAnimationTimer(button));
    
    IEnumerator ButtonAnimationTimer(GameObject b)
    {
        b.transform.localScaleTransition(new Vector3(.75f, .75f, .75f), .05f);
        yield return new WaitForSeconds(.05f);
        b.transform.localScaleTransition(new Vector3(1.1f, 1.1f, 1.1f), .05f);
        yield return new WaitForSeconds(.05f);
        b.transform.localScaleTransition(Vector3.one, .05f);
    }
}
