using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceHandler : MonoBehaviour
{
    public Dice[] Dices = new Dice[2];
    public int[] DicesValue = new int[2];
    private readonly int DEFAULT_VALUES = 1;

    protected readonly int DICE_MIN_VALUE = 1;
    protected readonly int DICE_MAX_VALUE = 6;

    void Start()
    {
        DicesValue[0] = DEFAULT_VALUES;
        DicesValue[1] = DEFAULT_VALUES;
    }

    private void DetermineOutcome()
    {
        int total = MathHandler.Instance.GetDiceSumForThisGame(GameManager.Instance.GetGameNumber());

        while (DicesValue[0] + DicesValue[1] != total)
        {
            DicesValue[0] = Random.Range(1, 7);
            DicesValue[1] = Random.Range(1, 7);
        }
    }

    //public void RollDices( Dice[0], Doce[1])
    public void RollDices()
    {
        DetermineOutcome();
        for (int i = 0; i < Dices.Length; i++)
        {
            if (Dices[i] != null && i < DicesValue.Length)
            {
                Dices[i].ChangeColor();
                Dices[i].ChangeValueRandomly(DicesValue[i]);
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

    public void SetDiceValues(int dice1Value, int dice2Value)
    {
        if (Dices.Length >= 2 && Dices[0] != null && Dices[1] != null)
        {
            Dices[0].SetDiceValue(dice1Value);
            Dices[1].SetDiceValue(dice2Value);
        }
    }
}
