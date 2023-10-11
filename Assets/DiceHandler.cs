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

    /// <summary>
    /// Setup default values of both dices
    /// </summary>
    void Start()
    {
        DicesValue[0] = DEFAULT_VALUES;
        DicesValue[1] = DEFAULT_VALUES;
    }

    /// <summary>
    /// Determines the outcome by generating random values for two dice until they match the game's required total.
    /// </summary>
    private void DetermineOutcome()
    {
        int total = MathHandler.Instance.GetDiceSumForThisGame(GameManager.Instance.GetGameNumber());

        while (DicesValue[0] + DicesValue[1] != total)
        {
            DicesValue[0] = Random.Range(1, 7);
            DicesValue[1] = Random.Range(1, 7);
        }
    }

    /// <summary>
    /// Simulates rolling two dice, determines their outcome, and updates their values.
    /// </summary>
    public void RollDices()
    {
        DetermineOutcome();
        for (int i = 0; i < Dices.Length; i++)
        {
            if (Dices[i] != null && i < DicesValue.Length)
            {
                Dices[i].ChangeColor();  //change color to indicate that dices are being rolled
                Dices[i].ChangeValueRandomly(DicesValue[i]);
            }
        }
    }

    /// <summary>
    /// Retrieves the total gameplay result based on the current values of the two dice.
    /// </summary>
    /// <returns>The sum of the dice values.</returns>
    public int GetGamplayResult()
    {
        int totalDiceValue = 0;
        foreach (Dice dice in Dices)
        {
            totalDiceValue += dice.GetDiceValue();
        }

        return totalDiceValue;
    }

    /// <summary>
    /// Update Dice values
    /// </summary>
    /// <param name="dice1Value"></param>
    /// <param name="dice2Value"></param>
    public void SetDiceValues(int dice1Value, int dice2Value)
    {
        if (Dices.Length >= 2 && Dices[0] != null && Dices[1] != null)
        {
            Dices[0].SetDiceValue(dice1Value);
            Dices[1].SetDiceValue(dice2Value);
        }
    }
}
