using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ExitButton : MonoBehaviour
{
    public void OnExitButtonCallback()
    {
        GameManager.Instance.GetCurrentGameState().ExitButtonPressed();
    }
}
