using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContentsManager : MonoBehaviour
{
    public SeasonFood[] foods;
    public GameObject contentTemplate;
    public Transform contentParent;

    public bool a;
    public Content.Season testSeason;

    [Serializable]
    public struct SeasonFood
    {
        public OpenContent.ContentProps ContentProps;
        public Content.Season Season;
        public string name;
        public Sprite image;
        public FoodType foodType;
    }

    public enum FoodType
    {
        Vegetable,
        Fruit
    }

    private void Update()
    {
        if (a)
        {
            a = !a;
            LoadContents(testSeason);
        }
    }

    public void LoadContents(Content.Season s)
    {
        foreach (var content in FindObjectsOfType<Content>())
        {
            FindObjectOfType<ContentSearch>().contents.Clear();
            Destroy(content.gameObject);
        }
        foreach (var f in foods)     
        {
            if (f.Season == s)
            {
                var content = Instantiate(contentTemplate, contentParent);
                //
                Content.ContentLoadProp contentLoadProp;
                contentLoadProp.image = f.image;
                contentLoadProp.name = f.name;
                //
                content.GetComponent<Content>().content.contentSeason = f.Season;
                content.GetComponent<Content>().content.contentName = f.name;
                content.GetComponent<Content>().content.type = f.foodType;
                content.GetComponent<Content>().content.image = f.image;
                content.GetComponent<Content>().ContentProps = f.ContentProps;
                content.GetComponent<Content>().LoadContent(contentLoadProp);
                //
                FindObjectOfType<ContentSearch>().contents.Add(content.GetComponent<Content>());
            }
        }
    }
}
