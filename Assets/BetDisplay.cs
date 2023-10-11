using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Import TextMeshPro


public class BetDisplay : MonoBehaviour
{
    public TMP_Text numberText; 
    private int value;

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
