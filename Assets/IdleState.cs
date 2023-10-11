using UnityEngine;
using System.Collections;


public class IdleState : IGameState
{
    private GameManager manager;

    /// <summary>
    /// Initializes a new instance of the IdleState class with a reference to the game manager.
    /// </summary>
    /// <param name="manager">The game manager controlling the state transitions.</param>
    public IdleState(GameManager manager)
    {
        this.manager = manager;
    }

    /// <summary>
    /// Handles coroutines for this game state.
    /// </summary>
    /// <param name="coroutine">The coroutine to execute within this state.</param>
    public void HandleCoroutines(IEnumerator coroutine)
    {
        manager.StartCoroutine(coroutine);
    }

    public void ExitButtonPressed()
    {
        manager.EndGame();
    }

    /// <summary>
    /// Handles state transitions based on the new game state. First thing called when moving to this state
    /// </summary>
    /// <param name="newState">The new game state to transition to.</param>
    public void HandleStateChange(GameManager.GameState newState)
    {
        manager.buttonHandler.SetAllButtonInteractable(true);
    }

    /// <summary>
    /// Handles the player pressing the "Roll Dice" button to start a new round.
    /// </summary>
    public void RollDiceButtonPressed()
    {
        StartGame();
    }

    /// <summary>
    /// Initiates the start of a new round.
    /// </summary>
    private void StartGame()
    {
        //game starts only after taking credit
        manager.buttonHandler.SetAllButtonInteractable(false);
        manager.creditHandler.TakeCredit(manager.betHandler.GetCurrBet());
        manager.UpdateGameNumber();

        manager.SetGameState(GameManager.GameState.Playing);
        
    }
}