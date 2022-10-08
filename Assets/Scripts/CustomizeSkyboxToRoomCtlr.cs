using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class CustomizeSkyboxToRoomCtlr : MonoBehaviour
{
    public static CustomizeSkyboxToRoomCtlr Instance;
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            return;
        }
        Destroy(gameObject);
    }
    public Renderer renderer;
    public void UpdateImage360(Texture2D roomTexture)
    {
        renderer.material.SetTexture("_MainTex", roomTexture);
    }
}
