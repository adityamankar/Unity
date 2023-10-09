using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro; // Import TextMeshPro

public class ChangeBet : MonoBehaviour
{
    public GameObject objectToColor;
    public Button colorButton;
    public TMP_Text numberText; // Reference to the TextMeshPro text element.

    private Renderer objectRenderer;
    private Color originalColor;
    private int[] possibleBetValues = { 10, 20, 30, 40, 50, 60, 70, 80, 90, 100 };
    private int currentBetIndex;


    // Start is called before the first frame update
    void Start()
    {
        colorButton.onClick.AddListener(NextBet);
        objectRenderer = objectToColor.GetComponent<Renderer>();
        originalColor = objectRenderer.material.color;
        currentBetIndex = 0;
        numberText.text = possibleBetValues[currentBetIndex].ToString();
    }

    public void NextBet()
    {
        // Change the object's color (e.g., to red)
        objectRenderer.material.color = Color.red;

        // Increment the current bet value by 10
        currentBetIndex++;

        // Ensure the current bet does not exceed the maximum (100)
        if (currentBetIndex >= possibleBetValues.Length)
        {
            currentBetIndex = 0;
        }

        // Display the updated bet value
        numberText.text = possibleBetValues[currentBetIndex].ToString();

        // Delay for a moment (you can adjust the duration)
        StartCoroutine(ResetColorAfterDelay());
    }

    public void JumpToMaxBet()
    {
        // Calculate the index based on the length of possibleBetValues
        currentBetIndex = possibleBetValues.Length - 1;

        // Display the updated bet value
        numberText.text = possibleBetValues[currentBetIndex].ToString();
    }

        private IEnumerator ResetColorAfterDelay()
    {
        // Wait for a moment (e.g., 1 second)
        yield return new WaitForSeconds(1.0f);

        // Restore the original color
        objectRenderer.material.color = originalColor;
    }

    //get
}
