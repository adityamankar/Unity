using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashHandler : MonoBehaviour
{
    /// <summary>
    /// All the splashed that could be used in game are managed here
    /// </summary>
    public WinSplash winSplash;
    public LoseSplash loseSplash;

    /// <summary>
    /// It could be TriggerSplash(SplashType obj)
    /// But only two are used. No need for POLYMORPHISM as of now in this
    /// </summary>
    public void TriggerWinSplash()
    {
        if (winSplash)
            winSplash.Splash();
        else
            Debug.Log("win splash not working");
    }
    public void TriggerLoseSplash()
    {
        if (loseSplash)
            loseSplash.Splash();
        else
            Debug.Log("lose splash not working");
    }
}
