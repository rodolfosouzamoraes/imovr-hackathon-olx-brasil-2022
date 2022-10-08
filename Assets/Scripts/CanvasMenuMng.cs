using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasMenuMng : MonoBehaviour
{
    public static CanvasMenuMng Instance;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            return;
        }
        Destroy(this);
    }
    public PnlListRoomCtlr pnlListRoom;
    public GameObject[] pannelsMenu;

    public int indexSceneVR = 1;
    public void ShowSceneVR()
    {
        LoadSeneMng.LoadSceneIndex(indexSceneVR);
    }

    public void ShowPannelMenu()
    {
        OpenPannel(0);
    }
    public void ShowPannelListRealty()
    {
        OpenPannel(1);
    }
    public void ShowPannelListRoom(string idRealty)
    {
        OpenPannel(2);
        pnlListRoom.Init(idRealty);
    }

    private void OpenPannel(int index)
    {
        foreach(var pannel in pannelsMenu)
        {
            pannel.SetActive(false);
        }

        pannelsMenu[index].SetActive(true);
    }
}
