using Firebase.Database;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DatabaseManager : MonoBehaviour
{
    public List<Imovel> listRealty = new List<Imovel>();
    private DatabaseReference dbReference;
    void Start()
    {
        dbReference = FirebaseDatabase.DefaultInstance.RootReference;
    }

    /*
    private void CreateUser(string name, string email)
    {
        User newUser = new User(name, email);
        string json = JsonUtility.ToJson(newUser);

        dbReference.Child("usuarios").Child(userID).SetRawJsonValueAsync(json);
    }*/

    public IEnumerator GetRealty()
    {
        listRealty.Clear();
        var usersData = dbReference.Child("imoveis").GetValueAsync();
        yield return new WaitUntil(predicate: () => usersData.IsCompleted);
        if (usersData != null)
        {
            DataSnapshot snapshot = usersData.Result;
            foreach (DataSnapshot nodeData1 in snapshot.Children)
            {
                string idUser = nodeData1.Key;
                foreach(DataSnapshot nodeData2 in nodeData1.Children)
                {
                    string idRealty = nodeData2.Key;
                    Imovel reatly = new Imovel(
                        idUser,
                        idRealty,
                        nodeData2.Child("nome").Value.ToString(),
                        nodeData2.Child("descricao").Value.ToString(),
                        nodeData2.Child("foto").Value.ToString(),
                        double.Parse(nodeData2.Child("preco").Value.ToString())
                        );
                    listRealty.Add(reatly);
                }
                
            }
        }
    }
}
