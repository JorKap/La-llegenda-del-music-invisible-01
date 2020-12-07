using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrossFadeScene : MonoBehaviour
{

    public string sceneToLoad = "";
    public Animator transition;
    public float transitionTime = 1f;


    public void LoadSelectedScene(string scene)
    {
        StartCoroutine(LoadScene(scene));
    }

    IEnumerator LoadScene(string scene)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadSceneAsync(scene);

    }
}
