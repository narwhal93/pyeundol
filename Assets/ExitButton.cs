using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitButton : MonoBehaviour
{
    public void ExitShowRoom()
    {
        StateManager.Instance.ChangeScreen(StateManager.Screen.Main);
    }
}
