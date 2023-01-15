using System;
using System.Collections;
using System.Collections.Generic;
using Lean.Transition;
using UnityEngine;

public class OpenContent : MonoBehaviour
{
    [Serializable]
    public struct ContentProps
    {
        public List<string> Ingredients;
        public List<RecipeLoader2.RecipePart> Recipe;
        public List<RecipeLoader2.RecipePart> ZeroWaste;
        public bool isHavePhoto;
        public string noPhotoText;
        public MainRecipeVariables.ZeroWasteParts zeroWasteParts;
    }

    private bool _isOpened;
    public void OpenSelectedContent(GameObject c)
    {
        if (_isOpened) return;
        _isOpened = true;
        c.transform.localScaleTransition(new Vector3(0.93f, 0.93f, 0.93f), .3f);
        MainRecipeVariables.Label = c.GetComponent<Content>().content.contentName;
        MainRecipeVariables.FoodImage = c.GetComponent<Content>().content.image;
        MainRecipeVariables.Recipe = c.GetComponent<Content>().ContentProps.Recipe;
        MainRecipeVariables.Ingredients = c.GetComponent<Content>().ContentProps.Ingredients;
        MainRecipeVariables.ZeroWaste = c.GetComponent<Content>().ContentProps.ZeroWaste;
        MainRecipeVariables.mZeroWasteParts = c.GetComponent<Content>().ContentProps.zeroWasteParts;
        MainRecipeVariables.IsZeroWasteHavePhoto = c.GetComponent<Content>().ContentProps.isHavePhoto;
        MainRecipeVariables.ZeroWasteText = c.GetComponent<Content>().ContentProps.noPhotoText;
        FindObjectOfType<SceneLoader>().ChangeScene("recipe");
    }
}
