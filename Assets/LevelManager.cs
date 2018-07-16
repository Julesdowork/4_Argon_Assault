using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

	// Use this for initialization
	void Start () {
        Invoke("StartGame", 7f);
	}

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
}
