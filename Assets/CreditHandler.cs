using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Import TextMeshPro

public class CreditHandler : MonoBehaviour
{
    public CreditDisplay creditDisplay;
    private int defaultCredit = 2000;
    private int credits;

    // Start is called before the first frame update
    void Start()
    {
        credits = defaultCredit;
        creditDisplay.SetValue(credits);
    }

    // Function to deduct credits based on the bet amount
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

    // Function to add winnings to the credits
    public void AddWins(int winnings)
    {
        if (winnings > 0)
        {
            credits += winnings; // Add the winnings to the credits
        }
        creditDisplay.SetValue(credits);
    }

    // Function to get the current credits value
    public int GetCredits()
    {
        return credits;
    }

    // Function to reset credits to the initial value (2000)
    public void ResetCredits()
    {
        credits = 2000;
        creditDisplay.SetValue(credits);
    }
}
