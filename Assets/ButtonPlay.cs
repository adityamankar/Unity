using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonPlay : MonoBehaviour
{
    public void OnRollDiceButtonCallback()
    {
        //Debug.Log("roll dice clicked and callback called");
        GameManager.Instance.GetCurrentGameState().RollDiceButtonPressed();
    }
}
