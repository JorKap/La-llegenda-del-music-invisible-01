using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public GameObject loadingScreen;
    public Slider slider;
    public Text progressText;
    private TotesCondicionsScriptable condicionsScriptable;
    //private CollidersEnableScriptable collidersEnableScriptable;
    private StateComponentsScriptable stateComponents;

    // private SaveLoad loadSavedData;

    private void Start()
    {
        //loadSavedData = FindObjectOfType<SaveLoad>();
    }
    
    public void DeleteGameProgressData()
    {
        condicionsScriptable = Resources.Load<TotesCondicionsScriptable>("TotesCondicions");
       stateComponents = Resources.Load<StateComponentsScriptable>("StateComponents");
        //collidersEnableScriptable = Resources.Load<CollidersEnableScriptable>("CollidersEnable");
        foreach (Condicio condicio in condicionsScriptable.condicions)
        {
            condicio.estat = false;
        }
        //foreach (StateComponents stateComponents in stateComponents.stateComponents)
        //{
        //    stateComponents.state = true;
        //}

       // collidersEnableScriptable.colliders.Clear();
        PlayerPrefs.DeleteAll();
        //PlayerPrefs.SetString("name", "StartPosition");

    }
    public void LoadLevel(int sceneIndex)
    {
        StartCoroutine(LoadAsynchronously(sceneIndex));
       // loadSavedData.LoadGame();
    }

    IEnumerator LoadAsynchronously(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        loadingScreen.SetActive(true);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            Debug.Log(progress);
            slider.value = progress;
            progressText.text = progress * 100f + "%";

            yield return null;

        }

    }
}
