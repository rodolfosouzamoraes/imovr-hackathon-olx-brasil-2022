using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectManagers : MonoBehaviour
{
    public static GameObjectManagers Instance;
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            return;
        }
        Destroy(gameObject);
    }

    public static Texture2D roomTexture;
}
