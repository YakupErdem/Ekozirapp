using System;
using System.Collections;
using System.Collections.Generic;
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
}
