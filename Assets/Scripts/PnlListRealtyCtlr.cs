using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PnlListRealtyCtlr : MonoBehaviour
{
    public GameObject goItemRealty;
    public Transform transformContentRealty;
    public List<GameObject> realtyItems;
    private List<Imovel> listRealtyDB = new List<Imovel>();
    private void OnEnable()
    {
        
        StartCoroutine(DatabaseManager.Instance.GetRealtyList((List<Imovel> listRealty) =>
        {
            listRealtyDB = new List<Imovel>(listRealty);
            ClearItensInContent();
            foreach (Imovel imovel in listRealtyDB)
            {
                GameObject goItem = Instantiate(goItemRealty, transformContentRealty);
                ItemRealtyCtlr itemRealty = goItem.GetComponent<ItemRealtyCtlr>();
                itemRealty.Init(imovel);
                realtyItems.Add(goItem);
            }
        }));

        
    }

    private void ClearItensInContent()
    {
        foreach(GameObject item in realtyItems)
        {
            Destroy(item);
        }
        realtyItems.Clear();
    }
}
