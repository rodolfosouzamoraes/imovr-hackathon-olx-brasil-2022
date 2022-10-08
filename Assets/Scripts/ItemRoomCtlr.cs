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
    private Texture2D textureRoom360;
    public void OnPointerClick(PointerEventData eventData)
    {
        StartCoroutine(CreateImageRoom360AndUpdateEnviroment(room.foto360, room.larguraFoto360, room.alturaFoto360));
        
    }

    public void Init(Comodo roomItem)
    {
        room = roomItem;
        txtName.text = room.nome;
        txtDescription.text = room.descricao;
        StartCoroutine(SetImageRoom(room.foto));
    }

    private IEnumerator SetImageRoom(string url)
    {
        Texture2D texture = new Texture2D(370, 370);

        WWW www = new WWW(url);
        yield return www;

        www.LoadImageIntoTexture(texture);
        www.Dispose();
        www = null;
        imgPicture.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
    }

    private IEnumerator CreateImageRoom360AndUpdateEnviroment(string url, int width, int height)
    {
        textureRoom360 = new Texture2D(width, height);

        WWW www = new WWW(url);
        yield return www;

        www.LoadImageIntoTexture(textureRoom360);
        www.Dispose();
        www = null;

        CustomizeSkyboxToRoomCtlr.Instance.UpdateImage360(textureRoom360);
        CanvasMenuMng.Instance.ShowPannelEnviroment();
    }
}
