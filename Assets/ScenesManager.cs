﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    public static ScenesManager Instance;

    public static class Scenes
    {
        public static string InitialMenu = "Menu";
        public static string FirstCutscene = "InitialDialogue";
        public static string MainScene = "MainScene";
    }
    private void Start()
    {
        Instance = this;
        DontDestroyOnLoad(this);
    }

    public void ChangeScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
    
}
