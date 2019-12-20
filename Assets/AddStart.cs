using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddStart : MonoBehaviour
{
    [SerializeField]
    GameObject BottomMenu;

    [SerializeField]
    GameObject AddMenu;

    [SerializeField]
    Text Explaination;

    public void AddStarting()
    {
        if (DataManager.Instance.InputString.text != "")
        {
            BottomMenu.SetActive(false);
            AddMenu.SetActive(true);
            StateManager.Instance._isAdd = true;
            Explaination.text = "추가할 장소를 고르세요";
        }
    }

    public void MoveStarting()
    {
         BottomMenu.SetActive(false);
         AddMenu.SetActive(true);
         StateManager.Instance._isMove = true;
         Explaination.text = "이동할 장소를 고르세요";

    }

    public void DeleteStarting()
    {
         BottomMenu.SetActive(false);
         AddMenu.SetActive(true);
         StateManager.Instance._isDelete = true;
         Explaination.text = "삭제할 물건을 고르세요";
    }

    public void QuitAddition()
    {
        BottomMenu.SetActive(true);
        AddMenu.SetActive(false);
        StateManager.Instance._isAdd = false;
        StateManager.Instance._isMove = false;
        StateManager.Instance._isDelete = false;
    }

}