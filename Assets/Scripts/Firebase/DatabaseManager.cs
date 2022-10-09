using Firebase.Database;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Classe responsável por gerenciar o banco de dados Firebase
/// </summary>
public class DatabaseManager : MonoBehaviour
{
    public static DatabaseManager Instance;
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            return;
        }
        Destroy(this);
    }
    private DatabaseReference dbReference;
    void Start()
    {
        dbReference = FirebaseDatabase.DefaultInstance.RootReference;
    }
    public IEnumerator GetRealtyList(Action<List<Realty>> onCallback)
    {
        List<Realty> listRealty = new List<Realty>();
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
                    Realty reatly = new Realty(
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
            onCallback.Invoke(listRealty);
        }
    }
    public IEnumerator GetRoomList(Action<List<Room>> onCallback, string idRealty)
    {
        List<Room> listRoom = new List<Room>();
        var usersData = dbReference.Child("comodos").Child(idRealty).GetValueAsync();
        yield return new WaitUntil(predicate: () => usersData.IsCompleted);
        if (usersData != null)
        {
            DataSnapshot snapshot = usersData.Result;
            foreach (DataSnapshot nodeData1 in snapshot.Children)
            {
                string idRoom = nodeData1.Key;
                Room reatly = new Room(
                    idRealty,
                    idRoom,
                    nodeData1.Child("nome").Value.ToString(),
                    nodeData1.Child("foto").Value.ToString(),
                    nodeData1.Child("foto360").Value.ToString(),
                    nodeData1.Child("descricao").Value.ToString(),
                    int.Parse(nodeData1.Child("largura360").Value.ToString()),
                    int.Parse(nodeData1.Child("altura360").Value.ToString())
                );
                listRoom.Add(reatly);

            }
            onCallback.Invoke(listRoom);
        }
    }
}
