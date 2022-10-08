using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class User
{
    public string nome;
    public string email;
    public User()
    {

    }

    public User(string username, string email)
    {
        this.nome = username;
        this.email = email;
    }
}
