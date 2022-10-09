using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemRealtyCtlr : MonoBehaviour, IPointerClickHandler
{
    public Text txtName;
    public Text txtDescription;
    public Text txtPrice;
    public Image imgPicture;
    public Sprite sptError;

    private Imovel realty;
    public void OnPointerClick(PointerEventData eventData)
    {
        CanvasMenuMng.Instance.DefineRealty(realty);
        CanvasMenuMng.Instance.ShowPannelListRoom();
    }

    public void Init(Imovel realtyItem)
    {
        realty = realtyItem;
        txtName.text = realty.nome;
        txtDescription.text = realty.descricao;
        txtPrice.text = "R$"+realty.preco.ToString();
        Task t = SetImage(realty.foto);
    }

    private async Task SetImage(string url)
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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
