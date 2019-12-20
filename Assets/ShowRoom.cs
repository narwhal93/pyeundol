using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowRoom : SingletonMonoBehaviour<ShowRoom>
{
    [SerializeField]
    Sprite _thisIsNotMyHome;

    [SerializeField]
    Sprite _thisIsMyHome;

    [SerializeField]
    GameObject[] _line;

    [SerializeField]
    Text[] _lineText;

    [SerializeField]
    GridLayoutGroup[] _grids;

    [SerializeField]
    GameObject _goodsLoads;
    [SerializeField]
    GameObject _goodsPrefab;

    public int _selected;
    public GameObject _selectedObject;
    

    Stack<GameObject> _unUsedGoods;
    Stack<GameObject> _usingGoods;

    protected override void OnAwake()
    {
        base.OnAwake();

        _unUsedGoods = new Stack<GameObject>();
        _usingGoods = new Stack<GameObject>();

        for (int i = 0; i < 100; i++)
        {
            GameObject temp = Instantiate(_goodsPrefab) as GameObject;
            temp.transform.SetParent(_goodsLoads.transform);
            temp.transform.localScale = new Vector3(1f, 1f, 1f);
            _unUsedGoods.Push(temp);
            temp.SetActive(false);
        }

    }

    public void Init()
    {
        switch (StateManager.Instance._currentScreen)
        {
            case StateManager.Screen.DrinkRoom1:
                {
                    GetGoods(0);
                    break;
                }
            case StateManager.Screen.DrinkRoom2:
                {
                    GetGoods(1);
                    break;
                }
            case StateManager.Screen.DrinkRoom3:
                {
                    GetGoods(2);
                    break;
                }
            case StateManager.Screen.BackRoom:
                {
                    GetGoods(3);
                    break;
                }
            case StateManager.Screen.Beer:
                {
                    GetGoods(4);
                    ChangeName("맨 왼쪽", "그 다음", "", "", "");
                    _line[2].SetActive(false);
                    _line[3].SetActive(false);
                    _line[4].SetActive(false);
                    break;
                }
            case StateManager.Screen.Ramen:
                {
                    GetGoods(5);
                    ChangeName("맨 왼쪽", "왼쪽에서 2번째", "왼쪽에서 3번째", "왼쪽에서 4번쨰", "왼쪽에서 5번째");
                    break;
                }
            case StateManager.Screen.MaeDaeRoom:
                {
                    GetGoods(6);
                    ChangeName("왼쪽", "오른쪽", "", "", "");
                    _line[2].SetActive(false);
                    _line[3].SetActive(false);
                    _line[4].SetActive(false);
                    break;
                }
            case StateManager.Screen.LeftWareHouse:
                {
                    GetGoods(7);
                    ChangeName("맨 윗줄", "두번째 줄", "세번째 줄", "네번재 줄", "");
                    _line[4].SetActive(false);
                    break;
                }
            case StateManager.Screen.RightWareHouse:
                {
                    GetGoods(8);
                    ChangeName("맨 윗줄", "두번째 줄", "세번째 줄", "네번재 줄", "");
                    _line[4].SetActive(false);
                    break;
                }
        }
    }

    void GetGoods(int placeNum)
    {
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < DataManager.Instance._dataSet[placeNum][i].Count; j++)
            {
                GameObject temp = _unUsedGoods.Pop();
                temp.SetActive(true);
                temp.transform.SetParent(_grids[i].transform);
                temp.GetComponent<number>()._num = 10*i + j;
                temp.GetComponentInChildren<Text>().text = DataManager.Instance._dataSet[placeNum][i][j]._name;
                _usingGoods.Push(temp);
                if (DataManager.Instance._dataSet[placeNum][i][j]._homePlace != placeNum) temp.GetComponent<Image>().sprite = _thisIsNotMyHome;
            }
        }
    }

    void ChangeName(string lineText0, string lineText1, string lineText2, string lineText3, string lineText4)
    {
        _lineText[0].text = lineText0;
        _lineText[1].text = lineText1;
        _lineText[2].text = lineText2;
        _lineText[3].text = lineText3;
        _lineText[4].text = lineText4;
    }

    public void Close()
    {
        for (int i = 0; i < _line.Length; i++) _line[i].gameObject.SetActive(true);
        ChangeName("맨 윗줄", "두번째 줄", "세번째 줄", "네번재 줄", "바닥");
        GoodsReset();
    }

    public void GoodsReset()
    {
        while (_usingGoods.Count > 0)
        {
            GameObject temp = _usingGoods.Pop();
            temp.GetComponent<number>()._num = 0;
            temp.GetComponent<Image>().sprite = _thisIsMyHome;
            temp.transform.SetParent(_goodsLoads.transform);
            _unUsedGoods.Push(temp);
        }
    }

    public void GoodsSelected()
    {
        
    }
}
