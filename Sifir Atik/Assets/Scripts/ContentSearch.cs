using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContentSearch : MonoBehaviour
{
    public Content.Season selectedSeason;
    public InputField inputField;
    public List<Content> contents;
    public SeasonSuggests[] seasonSuggests;
    public Dropdown filterDropdown;
    public GameObject[] suggestPages; 
    private Filter _filter = Filter.None;

    [Serializable]
    public struct SeasonSuggests
    {
        public Content.Season season;
        public ContentsManager.SeasonFood[] seasonFood;
    }
    

    public bool a;

    private enum Filter
    {
        None,
        Vegetable,
        Fruit
    }

    private void Start()
    {
        selectedSeason = Content.Season.Spring;
        Suggest();
        Search();
    }

    private void Update()
    {
        if (a)
        {
            a = !a;
            Search();
        }
    }

    public void Suggest()
    {
        foreach (var s in seasonSuggests)
        {
            if (s.season == selectedSeason)
            {
                for (int i = 0; i < 3; i++)
                {
                    Debug.Log("Changing Suggested Pages");
                    //
                    suggestPages[i].GetComponent<Image>().color = Color.gray;
                    suggestPages[i].GetComponent<Image>().sprite = s.seasonFood[i].image;
                    suggestPages[i].GetComponentInChildren<Text>().text = s.seasonFood[i].name;
                }
            }
        }
    }

    public void Search()
    {
        foreach (var c in contents)
        {
            if (c.content.contentName.ToUpper().StartsWith(inputField.text.ToUpper()) &&
                c.content.contentSeason == selectedSeason)
            {
                if (_filter != Filter.None)
                {
                    c.gameObject.SetActive(c.content.type.ToString() == _filter.ToString());
                }
                else c.gameObject.SetActive(true);
            }
            else c.gameObject.SetActive(false);
        }
    }

    public void ChangeFilter()
    {
        Debug.Log(filterDropdown.GetComponentInChildren<Text>().text);
        switch (filterDropdown.GetComponentInChildren<Text>().text)
        {
            case "All":
                //Filter(false);
                _filter = Filter.None;
                break;
            case "Vegetable":
                _filter = Filter.Vegetable;
                //Filter(ContentsManager.FoodType.Vegetable);
                break;
            case "Fruit":
                _filter = Filter.Fruit;
                //Filter(ContentsManager.FoodType.Fruit);
                break;
        }
        Search();
    }

    /*public void Filter(ContentsManager.FoodType filter)
    {
        Debug.Log("Adding filter to "+ filter.ToString());
        
        foreach (var c in contents)
        {
            if (c.content.contentName.ToUpper().StartsWith(inputField.text.ToUpper()) &&
                c.content.contentSeason == selectedSeason)
            {
                foreach (var food in FindObjectOfType<ContentsManager>().foods)
                {
                    if (food.name == c.content.contentName)
                    {
                        c.gameObject.SetActive(food.foodType == filter);
                    }
                }

                c.gameObject.SetActive(true);
            }
            else c.gameObject.SetActive(false);
        }
    }*/

    /*public void Filter(bool b)
    {
        if (!b)
        {
            foreach (var c in contents)
            {
                if (c.content.contentName.ToUpper().StartsWith(inputField.text.ToUpper()) &&
                    c.content.contentSeason == selectedSeason)
                {
                    c.gameObject.SetActive(true);
                }
                else c.gameObject.SetActive(false);
            }
        }
    }*/
}