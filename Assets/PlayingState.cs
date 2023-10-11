using UnityEngine;
using System.Collections;

// Inside another state (e.g., PlayingState)
public class PlayingState : IGameState
{
    private GameManager manager;

    public PlayingState(GameManager manager)
    {
        this.manager = manager;
    }

    public void HandleCoroutines(IEnumerator coroutine)
    {
        manager.StartCoroutine(coroutine);
    }

    public void RollDiceButtonPressed() { }

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

    private IEnumerator PlayWinAnimationsAndTransitionToAward()
    {
        // Play animations for a winning play.
        yield return new WaitForSeconds(GameManager.ANIM_TIME);
        //AwardGame();
        manager.SetGameState(GameManager.GameState.Award);

    }

    private IEnumerator PlayNonWinningAnimationsAndTransitionToAward()
    {
        // Play animations for a non-winning play.
        yield return new WaitForSeconds(GameManager.ANIM_TIME);
        //AwardGame();
        manager.SetGameState(GameManager.GameState.Award);
    }
}
