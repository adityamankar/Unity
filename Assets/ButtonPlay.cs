using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonPlay : MonoBehaviour
{
    //public GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
    }

    public void OnRollDiceButtonCallback()
    {
        //.RollDiceButtonPressed();
        Debug.Log("roll dice clicked and callback called");
        GameManager.Instance.RollDiceButtonPressed();
    }
}
