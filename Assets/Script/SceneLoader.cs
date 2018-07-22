using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

    

    public void LoadNextScene(string sceneName)
    {
       
        SceneManager.LoadScene(sceneName);
    }

    public void LoadNextScene() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitButton()
    {
        Application.Quit();
    }

    public void BrickDestroy() {
        if (Brick.totalBreakableBrick <= 0) {
            Debug.Log("win");
            LoadNextScene();
        }
    }
}
