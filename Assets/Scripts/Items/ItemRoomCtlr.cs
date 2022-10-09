using System;
using System.Collections;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
/// <summary>
/// Classe responsável por parametrizar os itens que aparecem na lista cômodos
/// </summary>
public class ItemRoomCtlr : MonoBehaviour, IPointerClickHandler
{
    public Text txtName;
    public Text txtDescription;
    public Image imgPicture;
    public Sprite sptError;

    public Room room;
    private Texture2D textureRoom360;
    public void OnPointerClick(PointerEventData eventData)
    {
        StartCoroutine(CreateImageRoom360AndUpdateEnviroment(room.urlPicture360, room.widthPicture360, room.heightPicture360));
    }
    public void Init(Room roomItem)
    {
        room = roomItem;
        txtName.text = room.name;
        txtDescription.text = room.description;
        Task t = SetImageRoom(room.urlPicture);
    }
    private async Task SetImageRoom(string url)
    {
        try
        {
            Texture2D texture = new Texture2D(370, 370);
            WWW www = new WWW(url);
            while (www.progress != 1)
            {
                await Task.Yield();
            }            
            if (www.isDone)
            {
                www.LoadImageIntoTexture(texture);
                imgPicture.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
            }
            else
            {
                imgPicture.sprite = sptError;
            }
            www.Dispose();
            www = null;
        }
        catch (Exception e)
        {
            Debug.Log($"ERROR:{e}");
            imgPicture.sprite = sptError;
        } 
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
