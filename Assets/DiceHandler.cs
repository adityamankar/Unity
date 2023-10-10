using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceHandler : MonoBehaviour
{
    public Dice[] Dices = new Dice[2];
    void Start()
    { 
    }

    public void RollDices()
    {
        foreach (Dice obj in Dices)
        {
            if (obj != null) // Check if the object is not null
            {
                Debug.Log("rolling dices");
                obj.SetDiceValue(Random.Range(1, 7));
                obj.ChangeColor();
            }
        }
    }

    public int GetGamplayResult()
    {
        int totalDiceValue = 0;
        foreach (Dice dice in Dices)
        {
            totalDiceValue += dice.GetDiceValue();
        }

        return totalDiceValue;
    }
}
