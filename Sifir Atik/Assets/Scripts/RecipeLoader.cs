using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecipeLoader : MonoBehaviour
{
    public Image foodImage;
    public Text label;
    public Transform parentTransform;
    public GameObject templatePrefab;

    public Sprite testImage;
    public string testLabel;
    public List<string> testRecipe;
    private void Start()
    {
        //LoadRecipe(testImage, testLabel, testRecipe);
        LoadRecipe(MainRecipeVariables.FoodImage, MainRecipeVariables.Label, MainRecipeVariables.Ingredients);
    }

    public void LoadRecipe(Sprite image, string foodLabel, List<string> recipeList)
    {
        foodImage.sprite = image;
        label.text = foodLabel;
        foreach (var recipe in recipeList)
        {
            var ing = Instantiate(templatePrefab, parentTransform);
            ing.GetComponentInChildren<Text>().text = recipe;
        }
    }
}
