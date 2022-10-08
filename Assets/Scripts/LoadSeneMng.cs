using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class LoadSeneMng
{
    public static void LoadSceneIndex(int index)
    {
        SceneManager.LoadScene(index);
    }

    public static void LoadSceneMenu()
    {
        SceneManager.LoadScene(0);
    }
}
