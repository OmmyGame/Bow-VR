using System;
using System.Collections;
using System.Collections.Generic;
using Ommy.Audio;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private void Awake() 
    {
        Instance=this;
    }
    private void Start() {
        AudioManager.Instance.StartGame();
    }
    public static Action OnDie;
    public void LoadScene(string sceneName,float dely=0, bool restarting=false)
    {
        // Check if the scene is already loaded
        if (!restarting&&SceneManager.GetSceneByName(sceneName).isLoaded)
        {
            // If the scene is already loaded, just activate it
            SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneName));
        }
        else
        {
            // If the scene is not loaded, load it asynchronously
            StartCoroutine(LoadSceneAsync(sceneName,dely));
        }
    }

    private IEnumerator LoadSceneAsync(string sceneName, float dely)
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(dely);
        // Create an asynchronous operation to load the scene
        AsyncOperation asyncOp = SceneManager.LoadSceneAsync(sceneName);

        // Wait for the scene to load
        while (!asyncOp.isDone)
        {
            // You can display a loading screen or animation here
            yield return null;
        }

        // Activate the loaded scene
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneName));
    }

}
