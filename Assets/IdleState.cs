using UnityEngine;
using System.Collections;


public class IdleState : IGameState
{
    private GameManager manager;

    public IdleState(GameManager manager)
    {
        this.manager = manager;
    }

    public void HandleCoroutines(IEnumerator coroutine)
    {
        manager.StartCoroutine(coroutine);
    }
    public void ExitButtonPressed()
    {
        manager.EndGame();
    }
    public void HandleStateChange(GameManager.GameState newState)
    {
        manager.buttonHandler.SetAllButtonInteractable(true);
    }

    // ------- Start of game flow
    //
    public void RollDiceButtonPressed()
    {
        StartGame();
    }

    private void StartGame()
    {
        //game starts only after taking credit
        manager.buttonHandler.SetAllButtonInteractable(false);
        manager.creditHandler.TakeCredit(manager.betHandler.GetCurrBet());
        manager.UpdateGameNumber();

        manager.SetGameState(GameManager.GameState.Playing);
        
    }
}