using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Import TextMeshPro

public class CreditHandler : MonoBehaviour
{
    public CreditDisplay creditDisplay;
    private int defaultCredit = 2000;
    private int credits;

    
    void Start()
    {
        credits = defaultCredit;
        creditDisplay.SetValue(credits);
    }


    /// <summary>
    /// Function to deduct credits based on the bet amount
    /// Signifies the start of the game
    /// </summary>
    public void TakeCredit(int bet)
    {
        if (bet > 0 && bet <= credits)
        {
            credits -= bet; // Deduct the bet amount from the credits
        }

        //******** TESTING PURPOSE ONLY
        if (credits < 50)
        {
            credits = 100;
        }

        creditDisplay.SetValue(credits);
    }

    /// Function to add winnings to the credits and update meter
    public void AddWins(int winnings)
    {
        if (winnings > 0)
        {
            credits += winnings; // Add the winnings to the credits
        }
        creditDisplay.SetValue(credits);
    }

    /// <summary>
    /// Function to add winnings to the credits logically, but does not update in meter. Update graphically after animation
    /// </summary>
    /// <param name="winnings"></param>
    public void AddWinsDontReflect(int winnings)
    {
        if (winnings > 0)
        {
            credits += winnings; // Add the winnings to the credits
        }
    }

    /// <summary>
    /// Graphically update the credit meter
    /// </summary>
    public void UpdateWinAmount()
    {
        creditDisplay.SetValue(credits);
    }

    /// Function to get the current credits value
    public int GetCredits()
    {
        return credits;
    }

    /// Function to reset credits to the initial value (2000)
    public void ResetCredits()
    {
        credits = 2000;
        creditDisplay.SetValue(credits);
    }
}
