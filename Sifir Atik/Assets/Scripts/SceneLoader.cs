using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public GameObject sceneChanger;
    public Transform parent;

    private void Start()
    {
        var sc = Instantiate(sceneChanger, parent);
        sc.GetComponent<Animator>().SetTrigger("Open");
        Destroy(sc, .8f);
    }

    public void ChangeScene(string sceneName)
    {
        var sc = Instantiate(sceneChanger, parent);
        sc.GetComponent<Animator>().SetTrigger("Close");
        StartCoroutine(WaitNChangeScene(sceneName));
    }

    private IEnumerator WaitNChangeScene(string sceneName)
    {
        yield return new WaitForSeconds(.8f);
        SceneManager.LoadScene(sceneName);
    }
}
