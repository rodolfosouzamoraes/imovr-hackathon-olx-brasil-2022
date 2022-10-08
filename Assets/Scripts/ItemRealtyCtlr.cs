using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemRealtyCtlr : MonoBehaviour, IPointerClickHandler
{
    public int idRealty;
    public void OnPointerClick(PointerEventData eventData)
    {
        CanvasMenuMng.Instance.ShowPannelListRoom();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
