using UnityEngine;
/// <summary>
/// Classe responsável por gerenciar o Canvas do Menu
/// </summary>
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

    private Realty realtyNow;

    public void ShowPannelMenu()
    {
        OpenPannel(0);
    }
    public void ShowPannelListRealty()
    {
        OpenPannel(1);
    }
    /// <summary>
    /// Define qual imóvel foi selecionado pelo usuário
    /// </summary>
    /// <param name="realty">O imóvel</param>
    public void DefineRealty(Realty realty)
    {
        realtyNow = realty;
    }
    public void ShowPannelListRoom()
    {
        if(realtyNow != null)
        {
            OpenPannel(2);
            pnlListRoom.Init(realtyNow.idRealty, realtyNow.name);
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
