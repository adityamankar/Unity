using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetHandler : MonoBehaviour
{
    private int[] possibleBetValues = { 10, 20, 30, 40, 50, 60, 70, 80, 90, 100 };
    private int currentBetIndex;
    public BetDisplay betDisplay;

    // Start is called before the first frame update
    void Start()
    {
        currentBetIndex = 2;
        betDisplay.SetValue(GetCurrBet());
    }

    public int GetNextBet()
    {
        currentBetIndex++;
        if (currentBetIndex >= possibleBetValues.Length)
        {
            currentBetIndex = 0;
        }
        return possibleBetValues[currentBetIndex];
    }

    public int GetMaxBet()
    {
        currentBetIndex = possibleBetValues.Length - 1;
        return possibleBetValues[currentBetIndex];
    }

    public void OnClickChangeBet()
    {
        UpdateBet( GetNextBet() );
    }
    public void OnClickMaxBet()
    {
        UpdateBet(GetMaxBet());
    }

    public void UpdateBet(int betVal)
    {
        betDisplay.SetValue(betVal);
    }

    public int GetCurrBet()
    {
        return possibleBetValues[currentBetIndex];
    }


}
