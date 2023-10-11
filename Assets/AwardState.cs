using UnityEngine;
using System.Collections;


// Inside the AwardState
public class AwardState : IGameState
{
    private GameManager manager;

    /// <summary>
    /// Initializes a new instance of the AwardState class with a reference to the game manager.
    /// </summary>
    /// <param name="manager">The game manager controlling the state transitions.</param>
    public AwardState(GameManager manager)
    {
        this.manager = manager;
    }

    public void RollDiceButtonPressed() {}
    public void ExitButtonPressed() {}

    /// <summary>
    /// Handles coroutines for this game state.
    /// </summary>
    /// <param name="coroutine">The coroutine to execute within this state.</param>
    public void HandleCoroutines(IEnumerator coroutine)
    {
        manager.StartCoroutine(coroutine);
    }

    /// <summary>
    /// Handles state transitions based on the new game state. First thing called when moving to this state
    /// </summary>
    /// <param name="newState">The new game state to transition to.</param>
    public void HandleStateChange(GameManager.GameState newState)
    {
        manager.StartCoroutine(WaitDiceAnimationConfirm());
    }

    /// <summary>
    /// Initiates the award process, which includes displaying win or lose animations and updating the player's credit.
    /// </summary>
    private void AwardGame()
    {
        //ideally there should be a state here where it will wait for animatio to complete
        if (manager.IsWinningPlay())
            manager.splashHandler.TriggerWinSplash();
        else
            manager.splashHandler.TriggerLoseSplash();

        //would be useful to add animations to win increasing gradually
        manager.creditHandler.UpdateWinAmount();
        manager.StartCoroutine(PlayAwardAnimationsAndTransitionToIdle());
    }

    /// <summary>
    /// Plays award animations and transitions to the "Idle" state.
    /// </summary>
    private IEnumerator PlayAwardAnimationsAndTransitionToIdle()
    {
        // Play animations and credit calculations for the "award" state.
        yield return new WaitForSeconds(GameManager.ANIM_TIME);
        manager.SetGameState(GameManager.GameState.Idle);

        //manager.isTransitioning = false; // Reset the flag when the transition is complete.
    }

    /// <summary>
    /// Waits for the dice animation confirmation before initiating the award process.
    /// </summary>
    private IEnumerator WaitDiceAnimationConfirm()
    {
        yield return new WaitForSeconds(GameManager.ANIM_TIME);
        AwardGame();
    }
}
