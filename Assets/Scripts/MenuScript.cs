using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MenuScript : MonoBehaviour
{
    public GameObject LoadingScreen;

    public Slider LoadingBarFill;

    public void exitGame()
    {
        Application.Quit();
    }

    
    public void playGame(int sceneId)
    {
        StartCoroutine(LoadSceneAsync(sceneId));
    }

    IEnumerator LoadSceneAsync(int sceneId)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneId);

        LoadingScreen.SetActive(true);

        while(!operation.isDone)
        {
            float progressValue = Mathf.Clamp01(operation.progress / 0.9f);

            LoadingBarFill.value = progressValue;

            yield return null;            
        }
        
    }


    public void sgHarcore(bool isHard)
    {
        SaveGame.setHardcore(!isHard);
    }


}
