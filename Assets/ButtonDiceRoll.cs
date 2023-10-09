using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonDiceRoll : MonoBehaviour
{
    //public GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnRollDiceButtonCallback()
    {
        //.RollDiceButtonPressed();
        GameManager.Instance.RollDiceButtonPressed();
    }
}
