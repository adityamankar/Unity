using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Import TextMeshPro


public class CreditDisplay : MonoBehaviour
{
    public TMP_Text numberText; // Reference to the TextMeshPro text element.
    private int value;  //default bet

    void Start()
    {
        numberText.text = value.ToString();
    }

    /// <summary>
    /// update the value displayed in credit meter
    /// </summary>
    /// <param name="val"></param>
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
