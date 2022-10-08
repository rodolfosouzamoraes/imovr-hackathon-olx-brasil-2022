using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Comodo
{
    public string idImovel;
    public string idComodo;
    public string nome;
    public string foto;
    public string foto360;
    public string descricao;
    public int larguraFoto360;
    public int alturaFoto360;

    public Comodo()
    {

    }

    public Comodo(string idReatly, string idRoom, string name, string urlPicture, string urlPicture360, string description, int widthPicture360, int heightPicture360)
    {
        idImovel = idReatly;
        idComodo = idRoom;
        nome = name;
        foto = urlPicture;
        foto360 = urlPicture360;
        descricao = description;
        larguraFoto360 = widthPicture360;
        alturaFoto360 = heightPicture360;
    }
}
