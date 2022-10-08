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

    private Imovel realtyNow;
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
    public void DefineRealty(Imovel realty)
    {
        realtyNow = realty;
    }

    public void ShowPannelListRoom()
    {
        if(realtyNow != null)
        {
            OpenPannel(2);
            pnlListRoom.Init(realtyNow.idImovel, realtyNow.nome);
        }
        
    }
    public void ShowPannelEnviroment()
    {
        OpenPannel(3);
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
