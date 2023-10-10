using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Enum to represent game states
    public enum GameState
    {
        Idle,
        Playing,
        Award
    }

    private GameState currentState = GameState.Idle;
    private bool isTransitioning = false; // Flag to block input during transitions

    public CreditHandler creditHandler;
    public BetHandler betHandler;
    public DiceHandler diceHandler;
    public ButtonHandler buttonHandler;

    private const int WINNINGSUM = 7;
    private const int WINMULTIPLIER = 3;
    private float animationDuration = 2.0f; // Adjust animation duration as needed.

    private static GameManager instance;

    //singleton object
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameManager>();
                if (instance == null)
                {
                    GameObject obj = new GameObject("GameManager");
                    instance = obj.AddComponent<GameManager>();
                }
            }
            return instance;
        }
    }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    public void RollDiceButtonPressed()
    {
        if (currentState == GameState.Idle && !isTransitioning)
        {
            Debug.Log("Play handled by game manager");
            StartGame();
            isTransitioning = true; // Set the flag to block input during transition.
            //currentState = GameState.Playing;
            //StartCoroutine(PlayAnimationsAndTransitionToAward());
        }
    }

    private void StartGame()
    {
        //game starts only after taking credit
        creditHandler.TakeCredit(betHandler.GetCurrBet());
        
        buttonHandler.SetAllButtonInteractable(false);
        currentState = GameState.Playing;
        Debug.Log("Game state changed to playing");
        diceHandler.RollDices();
        if (EvaluateGamePlay())
            StartCoroutine(PlayWinAnimationsAndTransitionToAward());
        else
            StartCoroutine(PlayNonWinningAnimationsAndTransitionToAward());
    }

    private IEnumerator PlayAnimationsAndTransitionToAward()
    {
        // Play animations and game logic for the "playing" state.
        yield return new WaitForSeconds(animationDuration);
        AwardGame();
        isTransitioning = false; // Reset the flag when the transition is complete.
    }
    
    private void AwardGame()
    {
        //EvaluateGamePlay();
        currentState = GameState.Award;
        Debug.Log("Game state changed to Award");
        
        //would be useful to add animations to win increasing gradually
        creditHandler.UpdateWinAmount();
        StartCoroutine(PlayAwardAnimationsAndTransitionToIdle());
    }

    private IEnumerator PlayAwardAnimationsAndTransitionToIdle()
    {
        // Play animations and credit calculations for the "award" state.
        yield return new WaitForSeconds(animationDuration);
        Debug.Log("Game state changed to idle");
        currentState = GameState.Idle;
        
        buttonHandler.SetAllButtonInteractable(true);
        isTransitioning = false; // Reset the flag when the transition is complete.
    }

    //return if evaluation is successful
    public bool EvaluateGamePlay()
    {
        if (currentState == GameState.Playing)
        {
            if (IsWinningPlay())
            {
                //would be useful to add animations to win increasing gradually in AWARD state
                creditHandler.AddWinsDontReflect(betHandler.GetCurrBet() * WINMULTIPLIER);
                return true;
            }
        }
        return false;
    }

    private bool IsWinningPlay()
    {
        bool isWin = true;// diceHandler.GetGamplayResult() == WINNINGSUM;
        Debug.Log("Player WON !!!");
        return isWin;
    }

    private IEnumerator PlayWinAnimationsAndTransitionToAward()
    {
        // Play animations for a winning play.
        yield return new WaitForSeconds(animationDuration);
        AwardGame();
    }

    private IEnumerator PlayNonWinningAnimationsAndTransitionToAward()
    {
        // Play animations for a non-winning play.
        yield return new WaitForSeconds(animationDuration);
        AwardGame();
    }
}

