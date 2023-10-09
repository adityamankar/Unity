using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Import TextMeshPro


public class BetDisplay : MonoBehaviour
{
    public TMP_Text numberText; // Reference to the TextMeshPro text element.
    private int value;  //default bet

    // Start is called before the first frame update
    void Start()
    {
        numberText.text = value.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
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
