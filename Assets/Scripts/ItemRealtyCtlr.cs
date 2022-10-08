using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemRealtyCtlr : MonoBehaviour, IPointerClickHandler
{
    public Text txtName;
    public Text txtDescription;
    public Text txtPrice;
    public Image imgPicture;

    private Imovel realty;
    public void OnPointerClick(PointerEventData eventData)
    {
        CanvasMenuMng.Instance.ShowPannelListRoom();
    }

    public void Init(Imovel realtyItem)
    {
        realty = realtyItem;
        txtName.text = realty.nome;
        txtDescription.text = realty.descricao;
        txtPrice.text = "R$"+realty.preco.ToString();
        StartCoroutine(SetImage(realty.foto));
    }

    private IEnumerator SetImage(string url)
    {
        Texture2D texture = new Texture2D(370, 370);

        WWW www = new WWW(url);
        yield return www;

        // calling this function with StartCoroutine solves the problem
        Debug.Log("Why on earh is this never called?");

        www.LoadImageIntoTexture(texture);
        www.Dispose();
        www = null;
        imgPicture.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
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
