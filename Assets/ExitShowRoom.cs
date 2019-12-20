using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitShowRoom : MonoBehaviour
{
    public void GoToMain()
    {
        StateManager.Instance.ChangeScreen(StateManager.Screen.Main);
    }
}
