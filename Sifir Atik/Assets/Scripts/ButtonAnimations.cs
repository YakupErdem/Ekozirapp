using System.Collections;
using System.Collections.Generic;
using Lean.Transition;
using UnityEngine;

public class ButtonAnimations : MonoBehaviour
{
    public GameObject[] buttons;
    public float animationTime;
    void Start()
    {
        foreach (var button in buttons)
        {
            button.transform.localScale = Vector3.zero;
        }
        StartCoroutine(ButtonAnimation());
    }

    private IEnumerator ButtonAnimation()
    {
        foreach (var button in buttons)
        {
            button.transform.localScaleTransition(new Vector3(1.2f,1.2f,1.2f), animationTime);
            yield return new WaitForSeconds(.2f);
            button.transform.localScaleTransition(Vector3.one, .1f);
            yield return new WaitForSeconds(.1f);
        }
    }
}
