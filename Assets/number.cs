using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class number : MonoBehaviour
{
    [SerializeField]
    Sprite _thisIsSelected;

    public int _num;

    public void Selected()
    {
        ShowRoom.Instance._selected = _num;
        this.GetComponent<Image>().sprite = _thisIsSelected;
    }
}
