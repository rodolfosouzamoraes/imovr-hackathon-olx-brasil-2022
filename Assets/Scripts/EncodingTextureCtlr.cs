using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class EncodingTextureCtlr : MonoBehaviour
{
    public static EncodingTextureCtlr Instance;
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            return;
        }
        Destroy(this);
    }

    public static void EncodingToJPG(Texture2D texture, string idImage)
    {
        Texture2D itemBGTex = texture;
        //itemBGTex.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        //itemBGTex.Apply();
        
        byte[] itemBGBytes = itemBGTex.EncodeToJPG();
        File.WriteAllBytes($"{idImage}-room.jpg", itemBGBytes);
    }
}
