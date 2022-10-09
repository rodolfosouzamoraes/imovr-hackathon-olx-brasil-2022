using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PnlListRealtyCtlr : MonoBehaviour
{
    public GameObject goItemRealty;
    public Transform transformContentRealty;
    public List<GameObject> realtyItems;
    public InputField txtInputSearch; 
    private List<Imovel> listRealtyDB = new List<Imovel>();
    private bool isSearch = false;
    private void OnEnable()
    {
        StartCoroutine(DatabaseManager.Instance.GetRealtyList((List<Imovel> listRealty) =>
        {
            listRealtyDB = new List<Imovel>(listRealty);
            StartCoroutine(InsertRealtysInList());
        }));
    }

    public IEnumerator InsertRealtysInList()
    {
        ClearItensInContent();
        foreach (Imovel imovel in listRealtyDB)
        {
            GameObject goItem = Instantiate(goItemRealty, transformContentRealty);
            ItemRealtyCtlr itemRealty = goItem.GetComponent<ItemRealtyCtlr>();
            if (txtInputSearch.text == "")
            {
                itemRealty.Init(imovel);
                realtyItems.Add(goItem);
            }
            else if (imovel.nome.Contains(txtInputSearch.text))
            {
                itemRealty.Init(imovel);
                realtyItems.Add(goItem);
            }
            else
            {
                Destroy(goItem);
            }
            yield return new WaitForSeconds(0.3f);
        }
    }
    public void SearchRealty()
    {
        if (txtInputSearch.text != "")
        {
            isSearch = true;
            StartCoroutine(InsertRealtysInList());
        }
    }

    public void ChangeInputTextSearch()
    {
        if(txtInputSearch.text == "" && isSearch == true)
        {
            isSearch = false;
            StartCoroutine(InsertRealtysInList());
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
