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

    //ideally animations should be based on each animation but I am keeping it constant
    public const float ANIM_TIME = 2.0f;

    private GameState currentState = GameState.Idle;
    private bool isTransitioning = false; // Flag to block input during transitions

    // -----------Objects 
    public CreditHandler creditHandler;
    public BetHandler betHandler;
    public DiceHandler diceHandler;
    public ButtonHandler buttonHandler;
    public SplashHandler splashHandler;
    //public MathHandler mathHandler;


    // -----------singleton object
    private static GameManager instance;
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

    // ------------Game Number 
    //
    //  I will use game number to keep the track, but it can all be handled more elegenetly in real world game
    //  increment this after you take credit for each game
    private static int gameNumber = -1;
    public int GetGameNumber() => gameNumber;

    //update only after credit has been deducted from the game
    private void UpdateGameNumber() 
    { 
        gameNumber = (gameNumber + 1) % MathHandler.Instance.GetMathFileEntries(); 
    }

    // ------------ Related to gameplay
    //return if evaluation is successful
    public bool EvaluateGamePlay()
    {
        if (currentState == GameState.Playing)
        {
            if (IsWinningPlay())
            {
                //would be useful to add animations to win increasing gradually in AWARD state
                creditHandler.AddWinsDontReflect(betHandler.GetCurrBet() * MathHandler.Instance.GetWinMultiplier());
                return true;
            }
        }
        return false;
    }

    private bool IsWinningPlay()
    {
        //bool isWin = diceHandler.GetGamplayResult() == MathHandler.Instance.GetWinningSum();
        bool isWin = diceHandler.GetGamplayResult() >= MathHandler.Instance.GetWinningSum();
        return isWin;
    }

    // ------- Start of game flow
    //
    public void RollDiceButtonPressed()
    {
        if (currentState == GameState.Idle && !isTransitioning)
        {
            StartGame();
            isTransitioning = true; // flag to block input during transition.
            //currentState = GameState.Playing;
            //StartCoroutine(PlayAnimationsAndTransitionToAward());
        }
    }

    private void StartGame()
    {
        //game starts only after taking credit
        creditHandler.TakeCredit(betHandler.GetCurrBet());
        UpdateGameNumber();

        buttonHandler.SetAllButtonInteractable(false);
        currentState = GameState.Playing;
        Debug.Log("Game state changed to playing");
        diceHandler.RollDices();
        if (EvaluateGamePlay())
        {
            StartCoroutine(PlayWinAnimationsAndTransitionToAward());
        }
        else
            StartCoroutine(PlayNonWinningAnimationsAndTransitionToAward());
    }

    private IEnumerator PlayWinAnimationsAndTransitionToAward()
    {
        // Play animations for a winning play.
        yield return new WaitForSeconds(GameManager.ANIM_TIME);
        splashHandler.DisableWinSplash();
        AwardGame();
    }

    private IEnumerator PlayNonWinningAnimationsAndTransitionToAward()
    {
        // Play animations for a non-winning play.
        yield return new WaitForSeconds(GameManager.ANIM_TIME);
        AwardGame();
    }

    private void AwardGame()
    {
        //EvaluateGamePlay();
        currentState = GameState.Award;
        Debug.Log("Game state changed to Award");
        
        //ideally there should be a state here where it will wait for animatio to complete
        if(IsWinningPlay())
            splashHandler.TriggerWinSplash();

        //would be useful to add animations to win increasing gradually
        creditHandler.UpdateWinAmount();
        StartCoroutine(PlayAwardAnimationsAndTransitionToIdle());
    }

    private IEnumerator PlayAwardAnimationsAndTransitionToIdle()
    {
        // Play animations and credit calculations for the "award" state.
        yield return new WaitForSeconds(GameManager.ANIM_TIME);
        Debug.Log("Game state changed to idle");
        currentState = GameState.Idle;
        
        buttonHandler.SetAllButtonInteractable(true);
        isTransitioning = false; // Reset the flag when the transition is complete.
    }

    //private IEnumerator PlayAnimationsAndTransitionToAward()
    //{
    //    // Play animations and game logic for the "playing" state.
    //    yield return new WaitForSeconds(GameManager.ANIM_TIME);
    //    AwardGame();
    //    isTransitioning = false; // Reset the flag when the transition is complete.
    //}
}

