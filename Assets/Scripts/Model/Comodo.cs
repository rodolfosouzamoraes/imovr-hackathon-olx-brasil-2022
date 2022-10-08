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
    public string dimensao;

    public Comodo()
    {

    }

    public Comodo(string idReatly, string idRoom, string name, string urlPicture, string urlPicture360, string dimension)
    {
        idImovel = idReatly;
        idComodo = idRoom;
        nome = name;
        foto = urlPicture;
        foto360 = urlPicture360;
        dimensao = dimension;
    }
}
