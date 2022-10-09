using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// Classe responsável por controlar o painel de cômodos
/// </summary>
public class PnlListRoomCtlr : MonoBehaviour
{
    public GameObject goItemRoom;
    public Transform transformContentRoom;
    public List<GameObject> roomItems;
    public Text txtTitle;
    private List<Room> listRoomDB = new List<Room>();

    public void Init(string idRealty, string name)
    {
        txtTitle.text = name;
        StartCoroutine(DatabaseManager.Instance.GetRoomList((List<Room> listRoom) =>
        {
            listRoomDB = new List<Room>(listRoom);
            ClearItensInContent();
            Task taskRoom = InsertRealtysInList();
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
    public async Task InsertRealtysInList()
    {
        foreach (Room room in listRoomDB)
        {
            GameObject goItem = Instantiate(goItemRoom, transformContentRoom);
            ItemRoomCtlr itemRealty = goItem.GetComponent<ItemRoomCtlr>();
            itemRealty.Init(room);
            roomItems.Add(goItem);
            await Task.Delay(300);
        }
    }
    private void OnDisable()
    {
        ClearItensInContent();
    }
}
