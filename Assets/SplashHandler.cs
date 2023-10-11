using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashHandler : MonoBehaviour
{

    public WinSplash winSplash;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void TriggerWinSplash()
    {
        if (winSplash)
            winSplash.Splash();
        else
            Debug.Log("win splash not working");
    }
    public void DisableWinSplash()
    {
        winSplash.DisableSplash();
    }
}
