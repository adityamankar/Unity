using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    ////enum of game states idle/play/award

    //public List<Dice> Dices = new List<Dice>();
    public CreditHandler creditHandler;
    public BetHandler betHandler;

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
        //if current state == idle
        /*for both dices:
                rolldice();
        */
        Debug.Log("play handled by game manager");
        creditHandler.TakeCredit(betHandler.GetCurrBet());
        //change state to running
    }
}
