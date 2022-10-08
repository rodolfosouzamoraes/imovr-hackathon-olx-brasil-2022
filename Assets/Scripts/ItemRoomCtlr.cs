using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemRoomCtlr : MonoBehaviour, IPointerClickHandler
{
    public Text txtName;
    public Text txtDescription;
    public Image imgPicture;

    public Comodo room;
    public void OnPointerClick(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    public void Init(Comodo roomItem)
    {
        room = roomItem;
        txtName.text = room.nome;
        txtDescription.text = room.dimensao;
        StartCoroutine(SetImage(room.foto));
    }

    private IEnumerator SetImage(string url)
    {
        Texture2D texture = new Texture2D(370, 370);

        WWW www = new WWW(url);
        yield return www;

        www.LoadImageIntoTexture(texture);
        www.Dispose();
        www = null;
        imgPicture.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
    }


}
