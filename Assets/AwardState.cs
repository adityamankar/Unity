using UnityEngine;
using System.Collections;


// Inside the AwardState
public class AwardState : IGameState
{
    private GameManager manager;

    public AwardState(GameManager manager)
    {
        this.manager = manager;
    }

    public void RollDiceButtonPressed() {}

    public void HandleCoroutines(IEnumerator coroutine)
    {
        manager.StartCoroutine(coroutine);
    }

    public void HandleStateChange(GameManager.GameState newState)
    {
        manager.StartCoroutine(WaitDiceAnimationConfirm());
    }

    private void AwardGame()
    {
        //ideally there should be a state here where it will wait for animatio to complete
        if (manager.IsWinningPlay())
            manager.splashHandler.TriggerWinSplash();

        //would be useful to add animations to win increasing gradually
        manager.creditHandler.UpdateWinAmount();
        manager.StartCoroutine(PlayAwardAnimationsAndTransitionToIdle());
    }

    private IEnumerator PlayAwardAnimationsAndTransitionToIdle()
    {
        // Play animations and credit calculations for the "award" state.
        yield return new WaitForSeconds(GameManager.ANIM_TIME);
        manager.SetGameState(GameManager.GameState.Idle);

        //manager.isTransitioning = false; // Reset the flag when the transition is complete.
    }

    private IEnumerator WaitDiceAnimationConfirm()
    {
        yield return new WaitForSeconds(GameManager.ANIM_TIME);
        AwardGame();
    }
}
