using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainRecipeVariables : MonoBehaviour
{
    public static Sprite FoodImage;
    public static string Label;
    
    public static List<string> Ingredients;
    public static List<RecipeLoader2.RecipePart> Recipe;
    public static List<RecipeLoader2.RecipePart> ZeroWaste;
    public static ZeroWasteParts mZeroWasteParts;
    public static bool IsZeroWasteHavePhoto;
    public static string ZeroWasteText;
    
    [Serializable]
    public struct ZeroWasteParts
    {
        public Sprite image;
        public string name;
    }
}
