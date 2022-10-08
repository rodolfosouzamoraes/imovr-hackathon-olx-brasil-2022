using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PnlListRoomCtlr : MonoBehaviour
{
    public GameObject goItemRoom;
    public Transform transformContentRoom;
    public List<GameObject> roomItems;
    private List<Comodo> listRoomDB = new List<Comodo>();

    public void Init(string idRealty)
    {
        StartCoroutine(DatabaseManager.Instance.GetRoomList((List<Comodo> listRoom) =>
        {
            listRoomDB = new List<Comodo>(listRoom);
            ClearItensInContent();
            foreach (Comodo room in listRoomDB)
            {
                GameObject goItem = Instantiate(goItemRoom, transformContentRoom);
                ItemRoomCtlr itemRealty = goItem.GetComponent<ItemRoomCtlr>();
                itemRealty.Init(room);
                roomItems.Add(goItem);
            }
        }, idRealty));
    }
    private void ClearItensInContent()
    {
        foreach (GameObject item in roomItems)
        {
            Destroy(item);
        }
        roomItems.Clear();
    }
}
