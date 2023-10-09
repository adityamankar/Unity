using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro; // Import TextMeshPro

public class ButtonScript : MonoBehaviour
{
    public GameObject objectToColor;
    public Button colorButton;
    public TMP_Text numberText; // Reference to the TextMeshPro text element.

    private Renderer objectRenderer;
    private Color originalColor;

    // Start is called before the first frame update
    void Start()
    {
        colorButton.onClick.AddListener(PerformAction);
        objectRenderer = objectToColor.GetComponent<Renderer>();
        originalColor = objectRenderer.material.color;
    }

    public void PerformAction()
    {
        // Change the object's color (e.g., to red)
        objectRenderer.material.color = Color.red;

        // Generate a random number between 1 and 6 and display it
        int randomNumber = Random.Range(1, 7);
        numberText.text = randomNumber.ToString();

        // Delay for a moment (you can adjust the duration)
        StartCoroutine(ResetColorAfterDelay());
    }

    private IEnumerator ResetColorAfterDelay()
    {
        // Wait for a moment (e.g., 1 second)
        yield return new WaitForSeconds(1.0f);

        // Restore the original color
        objectRenderer.material.color = originalColor;
    }
}
