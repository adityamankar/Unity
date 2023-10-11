using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//  We can have mulitple files for math but its too simple for now. So this would suffice

public class MathHandler : MonoBehaviour
{
    // Singleton instance
    private static MathHandler instance;

    // Math-related constants
    //
    //  MATH_FILE values are to be generated randomly in real world through random number generator.
    //  if we fix the seed value then we can trace each outcome and this is simulation of this
    //  for release purpose, we will test for random seeds multiple times and verify the outcome
    //
    private static readonly int[] MATH_FILE = { 5, 8, 9, 3, 10, 7, 2, 4, 6, 11, 2, 12, 9, 8, 4, 5, 7, 6, 11, 3 };
    private const int MATH_FILE_ENTRIES = 20;
    private const int WINNINGSUM = 7;
    private const int WINMULTIPLIER = 3;

    // Property to access the singleton instance
    public static MathHandler Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<MathHandler>();
                if (instance == null)
                {
                    GameObject obj = new GameObject("MathHandler");
                    instance = obj.AddComponent<MathHandler>();
                }
            }
            return instance;
        }
    }

    public int GetMathFileEntries() => MATH_FILE_ENTRIES;
    public int GetWinningSum() => WINNINGSUM;
    public int GetWinMultiplier() => WINMULTIPLIER;

    private void Awake()
    {
        // Ensure there is only one MathHandler instance in the scene
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }
    
    // Get the dice sum for a specific game number
    public int GetDiceSumForThisGame(int gameNumber)
    {
        if (gameNumber >= 0 && gameNumber < MATH_FILE_ENTRIES)
            return MATH_FILE[gameNumber];
        else
        {
            Debug.LogError("Invalid game number.");
            return -1; // or handle the error in an appropriate way
        }
    }
}



/* ------------- Try without MonoBehaviour

public class MathHandler
{
    private static MathHandler instance;

    private static readonly int[] MATH_FILE = { 5, 8, 9, 3, 10, 7, 2, 4, 6, 11, 2, 12, 9, 8, 4, 5, 7, 6, 11, 3 };
    private const int MATH_FILE_ENTRIES = 20;
    private const int WINNINGSUM = 7;
    private const int WINMULTIPLIER = 3;

    public static MathHandler Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new MathHandler();
            }
            return instance;
        }
    }

    public int GetDiceSumForThisGame(int gameNumber)
    {
        if (gameNumber >= 0 && gameNumber < MATH_FILE_ENTRIES)
        {
            return MATH_FILE[gameNumber];
        }
        else
        {
            Console.Error.WriteLine("Invalid game number.");
            return -1; // or handle the error in an appropriate way
        }
    }

    private MathHandler()
    {
        // Private constructor to ensure a singleton pattern
    }
}


 */
