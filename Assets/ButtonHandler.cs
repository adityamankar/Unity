﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHandler : MonoBehaviour
{
    public Button playButton;
    public Button changeBetButton;
    public Button maxBetButton;
    public Button exitButton;

    /// <summary>
    /// Sets interactability for multiple buttons by enabling or disabling it.
    /// </summary>
    /// <param name="status">Interactability status to apply.</param>
    public void SetAllButtonInteractable(bool status)
    {
        playButton.interactable = status;
        changeBetButton.interactable = status;
        maxBetButton.interactable = status;
    }

    // All buttons can be derived from a parent Button class and use dependency injection here
    public void SetPlayInteractable(bool status)
    {
        playButton.interactable = status;
    }
    public void SetChangeBetInteractable(bool status)
    {
        changeBetButton.interactable = status;
    }
    public void SetMaxBetInteractable(bool status)
    {
        maxBetButton.interactable = status;
    }
    public void SetExitInteractable(bool status)
    {
        maxBetButton.interactable = status;
    }
}
