using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Goods
{
    public int _homePlace;
    public int _homeLine;

    public string _name;

    public void Init(int herePlace, int hereLine, string name)
    {
        _homePlace = herePlace;
        _homeLine = hereLine;

        _name = name;

        DataManager.Instance._dataSet[herePlace][hereLine].Add(this);
    }

    public void Destroy()
    {

    }
}

