﻿/*


different objects with tag


i know there is a way to keep all the assets as a bundle but i am not sure how to. so I am using individual assets
what is game object


for me
what is serlialized
prefab


there are lot of places where i could have containerized the assets like all buttons under one umbrella


instead of assigning game object from inspector, you can search for name of object and then assign
but it is expensive

max bet has instance of changebet to perform functions. ideally i would need handler seperate and will control both buttons seperately and dispaly separately as well











///////////////rotate
///using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dice : MonoBehaviour
{
    public GameObject objectToRotate;
    public Button rotateButton;

    // Start is called before the first frame update
    void Start()
    {
        rotateButton.onClick.AddListener(Rotate);
    }

    public void Rotate()
    {
        objectToRotate.transform.Rotate(Vector3.up, 30f);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
/////////////////////



////////////change color
///using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Dice : MonoBehaviour
{
    public GameObject objectToColor;
    public Button colorButton;

    private Renderer objectRenderer;
    private Color originalColor;

    // Start is called before the first frame update
    void Start()
    {
        colorButton.onClick.AddListener(ChangeColor);
        objectRenderer = objectToColor.GetComponent<Renderer>();
        originalColor = objectRenderer.material.color;
    }

    public void ChangeColor()
    {
        // Change the object's color (e.g., to red)
        objectRenderer.material.color = Color.red;

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

///


//////////////change color and keep the number
///
/// 
///using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro; // Import TextMeshPro

public class Dice : MonoBehaviour
{
    public GameObject objectToColor;
    public Button colorButton;
    public TMP_Text numberText; // Reference to the TextMeshPro text element.

    private Renderer objectRenderer;
    private Color originalColor;

    // Start is called before the first frame update
    void Start()
    {
        colorButton.onClick.AddListener(ChangeColor);
        objectRenderer = objectToColor.GetComponent<Renderer>();
        originalColor = objectRenderer.material.color;
    }

    public void ChangeColor()
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


*/
