using System;
using System.Collections;
using System.Collections.Generic;
using Lean.Transition;
using UnityEngine;

public class MainAnimator : MonoBehaviour
{
    public GameObject[] Objects;

    private void Start()
    {
        Animate();
    }

    public void Animate()
    {
        foreach (var o in Objects)
        {
            o.transform.localScaleTransition(new Vector3(.3f, .3f, .3f), 0);
        }
        foreach (var o in Objects)
        {
            o.transform.localScaleTransition(new Vector3(1.1f, 1.1f, 1.1f), .2f);
        }

        StartCoroutine(WaitNBack());
    }

    IEnumerator WaitNBack()
    {
        yield return new WaitForSeconds(.2f);
        foreach (var o in Objects)
        {
            o.transform.localScaleTransition(Vector3.one, .1f);
        }
    }
}
