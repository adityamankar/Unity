using System.Collections;

public interface IGameState
{
    void HandleStateChange(GameManager.GameState newState);
    void RollDiceButtonPressed();
    void HandleCoroutines(IEnumerator coroutine);
}
