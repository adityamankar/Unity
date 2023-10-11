using System.Collections;
using UnityEngine;
using System.Collections.Generic;

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

    private IGameState currentState;
    private Dictionary<GameState, IGameState> stateMap; 
    private bool isTransitioning = false; // Flag to block input during transitions

    // -----------Objects 
    public CreditHandler creditHandler;
    public BetHandler betHandler;
    public DiceHandler diceHandler;
    public ButtonHandler buttonHandler;
    public SplashHandler splashHandler;


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

        stateMap = new Dictionary<GameState, IGameState>
        {
            { GameState.Idle, new IdleState(this) },
            { GameState.Playing, new PlayingState(this) },
            { GameState.Award, new AwardState(this) }
        };

        currentState = stateMap[GameState.Idle];
    }

    // ------------Game Number 
    //
    //  I will use game number to keep the track, but it can all be handled more elegenetly in real world game
    //  increment this after you take credit for each game
    private static int gameNumber = -1;
    public int GetGameNumber() => gameNumber;

    //update only after credit has been deducted from the game
    public void UpdateGameNumber() => gameNumber = (gameNumber + 1) % MathHandler.Instance.GetMathFileEntries(); 
    public bool IsWinningPlay() => (diceHandler.GetGamplayResult() >= MathHandler.Instance.GetWinningSum());


    public void SetGameState(GameState newState)
    {
        if (currentState != null && !isTransitioning)
        {
            //isTransitioning = true; // Flag to block input during transition.
            string message = $"Changing game state to {newState}";
            Debug.Log(message);
            currentState = stateMap[newState];
            // Delegate the state change to the current state object
            currentState.HandleStateChange(newState);
        }
    }

    public IGameState GetCurrentGameState()
    {
        return currentState;
    }

}

