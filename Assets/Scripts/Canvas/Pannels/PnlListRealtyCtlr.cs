using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// Classe responsável por controlar o painel de imóveis
/// </summary>
public class PnlListRealtyCtlr : MonoBehaviour
{
    public GameObject goItemRealty;
    public Transform transformContentRealty;
    public List<GameObject> realtyItems;
    public InputField txtInputSearch; 
    private List<Realty> listRealtyDB = new List<Realty>();
    private bool isSearch = false;
    private void OnEnable()
    {
        StartCoroutine(DatabaseManager.Instance.GetRealtyList((List<Realty> listRealty) =>
        {
            listRealtyDB = new List<Realty>(listRealty);
            Task taskRealty = InsertRealtysInList();
        }));
    }
    public async Task InsertRealtysInList()
    {
        ClearItensInContent();
        foreach (Realty imovel in listRealtyDB)
        {
            GameObject goItem = Instantiate(goItemRealty, transformContentRealty);
            ItemRealtyCtlr itemRealty = goItem.GetComponent<ItemRealtyCtlr>();
            if (txtInputSearch.text == "")
            {
                itemRealty.Init(imovel);
                realtyItems.Add(goItem);
            }
            else if (imovel.name.ToLower().Contains(txtInputSearch.text.ToLower()))
            {
                itemRealty.Init(imovel);
                realtyItems.Add(goItem);
            }
            else
            {
                Destroy(goItem);
            }
            await Task.Delay(300);
        }
        await Task.Yield();
    }
    public void SearchRealty()
    {
        if (txtInputSearch.text != "")
        {
            isSearch = true;
            InsertRealtysInList();
        }
    }
    public void ChangeInputTextSearch()
    {
        if(txtInputSearch.text == "" && isSearch == true)
        {
            isSearch = false;
            InsertRealtysInList();
        }
    }
    private void ClearItensInContent()
    {
        foreach(GameObject item in realtyItems)
        {
            Destroy(item);
        }
        realtyItems.Clear();
    }
    private void OnDisable()
    {
        ClearItensInContent();
    }
}
