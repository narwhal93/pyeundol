using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StateManager : SingletonMonoBehaviour<StateManager>
{
    [SerializeField]
    GameObject _mainPage;

    [SerializeField]
    GameObject _ShowRoom;

    [SerializeField]
    Text _Exit;

    public enum Screen
    {
        Main = 0,
        DrinkRoom1,
        DrinkRoom2,
        DrinkRoom3,
        BackRoom,
        Drink,
        CoffeeAndTea,
        DisplayStand1,
        DisplayStand2,
        DisplayStand3,
        OnePlusOne,
        Healthy,
        Beer,
        MilksAndFF,
        Ramen,
        MaeDae,
        MaeDaeRoom,
        RiceAndETC,
        LeftWareHouse,
        RightWareHouse
    }

    public bool _isAdd;
    public bool _isMove;
    public bool _isDelete;

    public Screen _currentScreen;

    protected override void OnAwake()
    {
        _isAdd = false;
        _currentScreen = Screen.Main;
    }

    public void ChangeScreen(Screen screen)
    {
        _currentScreen = screen;
        if (screen != Screen.Main)
        {
            _mainPage.SetActive(false);
            _ShowRoom.SetActive(true);
            ShowRoom.Instance.Init();
            _Exit.text = "나가기";
        }
        else
        {
            _mainPage.SetActive(true);
            ShowRoom.Instance.Close();
            _ShowRoom.SetActive(false);
            _Exit.text = "종료";
        }
    }

}
