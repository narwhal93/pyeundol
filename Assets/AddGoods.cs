using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddGoods : MonoBehaviour
{
    [SerializeField]
    int _lineNum;

    [SerializeField]
    GameObject BottomMenu;

    [SerializeField]
    GameObject AddMenu;

    public void AddGoodsToHere()
    {
        if (StateManager.Instance._isAdd == true)
        {
            Goods temp = new Goods();
            switch (StateManager.Instance._currentScreen)
            {
                case StateManager.Screen.DrinkRoom1:
                    {
                        temp.Init(0, _lineNum, DataManager.Instance.InputString.text);
                        break;
                    }
                case StateManager.Screen.DrinkRoom2:
                    {
                        temp.Init(1, _lineNum, DataManager.Instance.InputString.text);
                        break;
                    }
                case StateManager.Screen.DrinkRoom3:
                    {
                        temp.Init(2, _lineNum, DataManager.Instance.InputString.text);
                        break;
                    }
                case StateManager.Screen.BackRoom:
                    {
                        temp.Init(3, _lineNum, DataManager.Instance.InputString.text);
                        break;
                    }
                case StateManager.Screen.Beer:
                    {
                        temp.Init(4, _lineNum, DataManager.Instance.InputString.text);
                        break;
                    }
                case StateManager.Screen.Ramen:
                    {
                        temp.Init(5, _lineNum, DataManager.Instance.InputString.text);
                        break;
                    }
                case StateManager.Screen.MaeDaeRoom:
                    {
                        temp.Init(6, _lineNum, DataManager.Instance.InputString.text);
                        break;
                    }
                case StateManager.Screen.LeftWareHouse:
                    {
                        temp.Init(7, _lineNum, DataManager.Instance.InputString.text);
                        break;
                    }
                case StateManager.Screen.RightWareHouse:
                    {
                        temp.Init(8, _lineNum, DataManager.Instance.InputString.text);
                        break;
                    }
            }


            ShowRoom.Instance.GoodsReset();
            ShowRoom.Instance.Init();

            BottomMenu.SetActive(true);
            AddMenu.SetActive(false);
            DataManager.Instance.InputString.text = "";
            StateManager.Instance._isAdd = false;
        }
    }
}
