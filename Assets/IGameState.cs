using System.Collections;

public interface IGameState
{
    void HandleStateChange(GameManager.GameState newState);
    void RollDiceButtonPressed();
    void ExitButtonPressed();
    void HandleCoroutines(IEnumerator coroutine);

}
