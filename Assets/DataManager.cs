using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Threading.Tasks;
using System;

public class DataManager : SingletonMonoBehaviour<DataManager>
{
    [SerializeField]
    public Text InputString;

    public List<List<Goods>>[] _dataSet;

    protected override void OnAwake()
    {
        _dataSet = new List<List<Goods>>[9];
        for (int i = 0; i < 9; i++)
        {
            _dataSet[i] = new List<List<Goods>>();
            for (int j = 0; j < 4; j++)
            {
                _dataSet[i].Add(new List<Goods>());
            }
        }
        LoadData();
    }

    protected override void OnStart()
    {
       
    }

    public async void LoadData()
    {
        //tempData
        Goods temp = new Goods();
        temp.Init(0,0, "게토레");
        try
        {
            await LoadGoodsData();
        }
        catch (Exception ex)
        {
            Debug.Log(ex);
        }
    }

    static async Task LoadGoodsData()
    {
        Debug.Log("StartGetCharInfo");
        var client = new MongoClient("mongodb+srv://narwhal:turtle13@cluster0-6hneg.mongodb.net/test?retryWrites=true&w=majority");
        var database = client.GetDatabase("pyeundol");

        IMongoCollection<BsonDocument> collec = database.GetCollection<BsonDocument>("GoodsData");

        using (IAsyncCursor<BsonDocument> cursor = await collec.FindAsync(new BsonDocument()))
        {
            while (await cursor.MoveNextAsync())
            {
                IEnumerable<BsonDocument> batch = cursor.Current;
                foreach (BsonDocument document in batch)
                {
                    Debug.Log(document);
                    for (int i = 0; i < document["Goods"].AsBsonArray.Count; i++)
                    {
                        Goods temp = new Goods();
                        temp.Init(document["Goods"][i]["CurrentPlace"].AsInt32, document["Goods"][i]["CurrentLine"].AsInt32, document["Goods"][i]["Name"].AsString);
                        temp._homePlace = document["Goods"][i]["HomePlace"].AsInt32;
                        temp._homeLine = document["Goods"][i]["HomeLine"].AsInt32;
                    }
                }
            }
        }
    }
}
