using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenShowRoom : MonoBehaviour
{

    [SerializeField]
    StateManager.Screen _screen;

    public void OpenScreen()
    {
        StateManager.Instance.ChangeScreen(_screen);
    }


}
