using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Import TextMeshPro


public class CreditDisplay : MonoBehaviour
{
    public TMP_Text numberText; // Reference to the TextMeshPro text element.
    private int value;  //default bet

    // Start is called before the first frame update
    void Start()
    {
        numberText.text = value.ToString();
    }

    public void SetValue(int val)
    {
        value = val;
        numberText.text = value.ToString();
    }

    public int GetValue()
    {
        return value;
    }
}
