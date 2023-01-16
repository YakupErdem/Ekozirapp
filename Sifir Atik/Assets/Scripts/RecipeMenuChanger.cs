using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeMenuChanger : MonoBehaviour
{
    public GameObject recipe;
    public GameObject ingredient;
    public GameObject zeroWaste;

    public void ChangeMenu(int index)
    {
        FindObjectOfType<RecipeMenuManager>().Interact();
        switch (index)
        {
            case 1:
                recipe.SetActive(true);
                ingredient.SetActive(false);
                zeroWaste.SetActive(false);
                break;
            case 2:
                recipe.SetActive(false);
                ingredient.SetActive(true);
                zeroWaste.SetActive(false);
                break;
            case 3:
                recipe.SetActive(false);
                ingredient.SetActive(false);
                zeroWaste.SetActive(true);
                break;
        }
    }
}
