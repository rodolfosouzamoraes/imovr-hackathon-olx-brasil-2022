using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Imovel
{
    public string idUsuario;
    public string idImovel;
    public string descricao;
    public string foto;
    public string nome;
    public double preco;

    public Imovel()
    {

    }

    public Imovel(string idUser, string idReatly, string name, string description, string urlPicture, double price)
    {
        idUsuario = idUser;
        idImovel = idReatly;
        nome = name;
        descricao = description;
        foto = urlPicture;
        preco = price;
    }
}
