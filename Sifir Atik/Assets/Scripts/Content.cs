using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Content : MonoBehaviour
{
    public ContentProp content;
    public OpenContent.ContentProps ContentProps;

    [System.Serializable]
    public struct ContentProp
    {
        public Sprite image;
        public string contentName;
        public Season contentSeason;
        public ContentsManager.FoodType type;
    }

    public enum Season
    {
        Summer,
        Spring,
        Autumn,
        Winter
    }

    [Serializable]
    public struct ContentLoadProp
    {
        public Sprite image;
        public string name;
    }
    
    public void LoadContent(ContentLoadProp c)
    {
        GetComponent<Image>().sprite = c.image;
        GetComponentInChildren<Text>().text = c.name;
    }
}
