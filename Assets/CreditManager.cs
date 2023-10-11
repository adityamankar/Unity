using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro; // Import TextMeshPro

public class CreditManager : MonoBehaviour
{
    //betmanger object
    private int credits; // Initial credit value set to 2000
    private int default_credits = 2000; // Initial credit value set to 2000
    public TMP_Text numberText; // Reference to the TextMeshPro text element.


    void Start()
    {
        credits = default_credits;
        numberText.text = credits.ToString();
    }

    /// Function to deduct credits based on the bet amount
    public void TakeCredit(int bet)
    {
        //int bet = betmanger.get();

        if (bet > 0 && bet <= credits)
        {
            credits -= bet; // Deduct the bet amount from the credits
            numberText.text = credits.ToString();

        }
        else
        {
            Debug.LogWarning("Invalid bet amount or insufficient credits.");
        }
    }

    /// Function to add winnings to the credits
    public void AddWins(int winnings)
    {
        if (winnings > 0)
        {
            credits += winnings; // Add the winnings to the credits
            numberText.text = credits.ToString();
        }
        else
        {
            Debug.LogWarning("Invalid winnings amount.");
        }
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
        numberText.text = credits.ToString();

    }
}
