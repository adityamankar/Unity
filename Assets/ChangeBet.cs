using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro; // Import TextMeshPro

public class ChangeBet : MonoBehaviour
{
    public GameObject objectToColor;
    public Button colorButton;
    public TMP_Text numberText; // Reference to the TextMeshPro text element.

    private int[] possibleBetValues = { 10, 20, 30, 40, 50, 60, 70, 80, 90, 100 };
    private int currentBetIndex;


    void Start()
    {
        colorButton.onClick.AddListener(NextBet);
        currentBetIndex = 0;
        numberText.text = possibleBetValues[currentBetIndex].ToString();
    }

    /// <summary>
    /// Jump to next possible bet
    /// </summary>
    public void NextBet()
    {
        currentBetIndex++;

        // Ensure the current bet does not exceed the maximum (100)
        if (currentBetIndex >= possibleBetValues.Length)
        {
            currentBetIndex = 0;
        }

        // Display the updated bet value
        numberText.text = possibleBetValues[currentBetIndex].ToString();
    }

    /// <summary>
    /// Directly Jump to highest bet
    /// </summary>
    public void JumpToMaxBet()
    {
        // Calculate the index based on the length of possibleBetValues
        currentBetIndex = possibleBetValues.Length - 1;

        // Display the updated bet value
        numberText.text = possibleBetValues[currentBetIndex].ToString();
    }
}
