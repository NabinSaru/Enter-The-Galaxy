﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneLoader: MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("StartGame", 3f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void StartGame()
    {
        SceneManager.LoadScene(1);
    }
}