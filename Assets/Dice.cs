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
    private Coroutine animationCoroutine; // Reference to the animation coroutine.

    private readonly int DICE_MIN_VALUE = 1;
    private readonly int DICE_MAX_VALUE = 6;

    // Start is called before the first frame update
    void Start()
    {
        //colorButton.onClick.AddListener(ChangeColor);
        objectRenderer = objectToColor.GetComponent<Renderer>();
        originalColor = objectRenderer.material.color;
        value = 1;
    }

    /// <summary>
    /// Changes the value of the dice randomly to simulate rolling, with an animation.
    /// </summary>
    /// <param name="diceOutcome">The desired outcome value of the dice after animation.</param>
    public void ChangeValueRandomly(int diceOutcome)
    {
        // Generate a random target value between 1 and 6
        int randomTargetValue = Random.Range(DICE_MIN_VALUE, DICE_MAX_VALUE+1);

        // Stop the previous animation coroutine if it's running
        if (animationCoroutine != null)
        {
            StopCoroutine(animationCoroutine);
        }

        // Start a new animation coroutine
        animationCoroutine = StartCoroutine(AnimateValueChange(randomTargetValue, GameManager.ANIM_TIME, diceOutcome));
    }

    /// <summary>
    /// Animates the change of the dice value from the current value to a target value.
    /// </summary>
    /// <param name="targetValue">The target value for the dice.</param>
    /// <param name="duration">The duration of the animation.</param>
    /// <param name="diceOutcome">The desired outcome value of the dice after animation.</param>
    private IEnumerator AnimateValueChange(int targetValue, float duration, int diceOutcome)
    {
        float elapsedTime = 0f;
        int startValue = value;

        while (elapsedTime < duration)
        {
            // Calculate the interpolated value between startValue and targetValue
            float t = elapsedTime / duration;

            //Adjust the speed of the animation
            t *= 10f;

            value = Mathf.RoundToInt(Mathf.Lerp(startValue, targetValue, t));

            // Display the current value
            numberText.text = value.ToString();

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        value = targetValue;
        numberText.text = value.ToString();

        //aditya - logic should be seperate from the graphics part,(could be in handler). But for time being, its here
        AnimationEndedCallback(diceOutcome);
    }

    // This function is called when the animation ends
    // ADITYA - its too late to call here. All animations are done before the actual values are set
    void AnimationEndedCallback(int diceOutcome)
    {
        value = diceOutcome;
        numberText.text = value.ToString();
    }

    /// <summary>
    /// Changes the color of the dice object and displays its current value with a delay.
    /// </summary>
    public void ChangeColor()
    {
        // Change the object's color (e.g., to red)
        objectRenderer.material.color = Color.red;

        // Generate a random number between 1 and 6 and display it
        numberText.text = value.ToString();

        // Delay for a moment (you can adjust the duration)
        StartCoroutine(ResetColorAfterDelay());
    }

    /// <summary>
    /// Resets the color of the dice object to its original color after a delay.
    /// </summary>
    private IEnumerator ResetColorAfterDelay()
    {
        // Wait for a moment (e.g., 1 second)
        yield return new WaitForSeconds(GameManager.ANIM_TIME);

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
