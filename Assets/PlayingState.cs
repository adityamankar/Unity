using UnityEngine;
using System.Collections;

// Inside another state (e.g., PlayingState)
public class PlayingState : IGameState
{
    private GameManager manager;

    /// <summary>
    /// Initializes a new instance of the IdleState class with a reference to the game manager.
    /// </summary>
    /// <param name="manager">The game manager controlling the state transitions.</param>
    public PlayingState(GameManager manager)
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

    public void RollDiceButtonPressed() { }
    public void ExitButtonPressed() { }

    /// <summary>
    /// Handles state transitions based on the new game state. First thing called when moving to this state
    /// </summary>
    /// <param name="newState">The new game state to transition to.</param>
    public void HandleStateChange(GameManager.GameState newState)
    {
        manager.diceHandler.RollDices();
        if (manager.IsWinningPlay())
        {
            manager.creditHandler.AddWinsDontReflect(manager.betHandler.GetCurrBet() * MathHandler.Instance.GetWinMultiplier());
            manager.StartCoroutine(PlayWinAnimationsAndTransitionToAward());
        }
        else
            manager.StartCoroutine(PlayNonWinningAnimationsAndTransitionToAward());
    }

    /// <summary>
    /// Plays animations for a winning play and transitions to the "Award" state.
    /// </summary>
    private IEnumerator PlayWinAnimationsAndTransitionToAward()
    {
        // Play animations for a winning play.
        yield return new WaitForSeconds(GameManager.ANIM_TIME);
        //AwardGame();
        manager.SetGameState(GameManager.GameState.Award);

    }

    /// <summary>
    /// Plays animations for a non-winning play and transitions to the "Award" state.
    /// </summary>
    private IEnumerator PlayNonWinningAnimationsAndTransitionToAward()
    {
        // Play animations for a non-winning play.
        yield return new WaitForSeconds(GameManager.ANIM_TIME);
        //AwardGame();
        manager.SetGameState(GameManager.GameState.Award);
    }
}
