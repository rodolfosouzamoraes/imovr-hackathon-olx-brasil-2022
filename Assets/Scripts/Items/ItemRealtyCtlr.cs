using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
/// <summary>
/// Classe responsável por parametrizar os itens que aparecem na lista de imóveis
/// </summary>
public class ItemRealtyCtlr : MonoBehaviour, IPointerClickHandler
{
    public Text txtName;
    public Text txtDescription;
    public Text txtPrice;
    public Image imgPicture;
    public Sprite sptError;

    private Realty realty;
    public void OnPointerClick(PointerEventData eventData)
    {
        CanvasMenuMng.Instance.DefineRealty(realty);
        CanvasMenuMng.Instance.ShowPannelListRoom();
    }
    /// <summary>
    /// Inicializa o item com as informações do imóvel
    /// </summary>
    /// <param name="realtyItem"></param>
    public void Init(Realty realtyItem)
    {
        realty = realtyItem;
        txtName.text = realty.name;
        txtDescription.text = realty.description;
        txtPrice.text = "R$"+realty.price.ToString();
        Task t = SetImageRealty(realty.urlPicture);
    }
    private async Task SetImageRealty(string url)
    {
        Texture2D texture = new Texture2D(370, 370);
        try
        {
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
        catch(Exception e)
        {
            Debug.Log($"ERROR:{e}");
            imgPicture.sprite = sptError;
        }
        
    }
}
