using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    ////enum of game states idle/play/award

    //public List<Dice> Dices = new List<Dice>();
    public CreditHandler creditHandler;
    public BetHandler betHandler;
    public DiceHandler diceHandler;

    private const int WINNINGSUM = 7;
    private const int WINMULTIPLIER = 3;

    // Static reference to the GameManager instance
    private static GameManager instance;

    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                // If the instance is null, find it in the scene or create a new GameObject for it
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
        // Ensure there is only one GameManager instance in the scene
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
        Debug.Log("play handled by game manager");
        diceHandler.RollDices();
        creditHandler.TakeCredit(betHandler.GetCurrBet());
        //change state to running
        EvaluateGamePlay();
    }

    public void EvaluateGamePlay()
    {
        if (IsWinningPlay())
            creditHandler.AddWins(betHandler.GetCurrBet() * WINMULTIPLIER);
        else
        {
            
        }
    }

    private bool IsWinningPlay()
    {
        return diceHandler.GetGamplayResult() == WINNINGSUM;
    }
}
