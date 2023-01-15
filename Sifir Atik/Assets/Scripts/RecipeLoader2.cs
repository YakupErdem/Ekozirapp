using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecipeLoader2 : MonoBehaviour
{
    public Image foodImage;
    public Text label;
    public Transform parentTransform;
    public GameObject templatePrefab;

    public Sprite testImage;
    public string testLabel;
    public List<RecipePart> testRecipe;

    public bool isZeroWaste;
    public GameObject page, pageNoPhoto;
    
    [Serializable]
    public struct RecipePart
    {
        public Sprite image;
        public string recipe;
    }
    
    private void Start()
    {
        if (isZeroWaste)
        {
            page.SetActive(true);
            pageNoPhoto.SetActive(false);
            //
            if (!MainRecipeVariables.IsZeroWasteHavePhoto)
            {
                page.SetActive(false);
                pageNoPhoto.SetActive(true);
                //
                pageNoPhoto.GetComponentInChildren<Text>().text = MainRecipeVariables.ZeroWasteText;
            }
        }
        //LoadRecipe(testImage, testLabel, testRecipe);
        LoadRecipe(MainRecipeVariables.FoodImage, MainRecipeVariables.Label,
            isZeroWaste ? MainRecipeVariables.ZeroWaste : MainRecipeVariables.Recipe);
    }

    public void LoadRecipe(Sprite image, string foodLabel, List<RecipePart> recipeList)
    {
        if (isZeroWaste)
        {
            foodImage.sprite = MainRecipeVariables.mZeroWasteParts.image;
            label.text = MainRecipeVariables.mZeroWasteParts.name;
        }
        else
        {
            foodImage.sprite = image;
            label.text = foodLabel;   
        }
        foreach (var recipe in recipeList)
        {
            var ing = Instantiate(templatePrefab, parentTransform);
            ing.GetComponentInChildren<Text>().text = recipe.recipe;
            ing.GetComponentInChildren<recipeImage>().GetComponent<Image>().sprite = recipe.image;
        }
    }
}
