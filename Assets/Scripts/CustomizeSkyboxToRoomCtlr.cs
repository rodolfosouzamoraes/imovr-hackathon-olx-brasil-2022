using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomizeSkyboxToRoomCtlr : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Renderer renderer = GetComponent<Renderer>();
        renderer.material.SetTexture("_MainTex", GameObjectManagers.roomTexture);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
