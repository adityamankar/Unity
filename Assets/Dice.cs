using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro; // Import TextMeshPro

public class Dice : MonoBehaviour
{
    public GameObject objectToColor;
    //public Button colorButton;
    public TMP_Text numberText; // Reference to the TextMeshPro text element.

    private Renderer objectRenderer;
    private Color originalColor;
    private int value;

    // Start is called before the first frame update
    void Start()
    {
        //colorButton.onClick.AddListener(ChangeColor);
        objectRenderer = objectToColor.GetComponent<Renderer>();
        originalColor = objectRenderer.material.color;
        value = 1;
    }

    public void ChangeColor()
    {
        // Change the object's color (e.g., to red)
        objectRenderer.material.color = Color.red;

        // Generate a random number between 1 and 6 and display it
        numberText.text = value.ToString();

        // Delay for a moment (you can adjust the duration)
        StartCoroutine(ResetColorAfterDelay());
    }

    private IEnumerator ResetColorAfterDelay()
    {
        // Wait for a moment (e.g., 1 second)
        yield return new WaitForSeconds(2.0f);

        // Restore the original color
        objectRenderer.material.color = originalColor;
    }
    
    public int GetDiceValue()
    {
        return value;
    }

    public void SetDiceValue(int val)
    {
        value = val;
    }
}
