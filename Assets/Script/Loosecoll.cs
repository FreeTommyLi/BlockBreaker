using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loosecoll : MonoBehaviour {

    private SceneLoader sceneLoader;

    public void OnTriggerEnter2D(Collider2D trigger)
    {
        sceneLoader = GameObject.FindObjectOfType<SceneLoader>();
        sceneLoader.LoadNextScene("Lose Game");
    }
}
