using UnityEngine;
using UnityEngine.UI;

public class StatManager : MonoBehaviour
{
    // Field Declaration
    public Image foodImage;
    public Image washImage;
    public Image exerciseImage;

    private int foodStat;
    private int washStat;
    private int exerciseStat;

    public int foodStatMax;
    public int washStatMax;
    public int exerciseStatMax;

    public Sprite happyCat;
    public Sprite neutralCat;
    public Sprite sadCat;
    public GameObject catObject;


    public float statDecreaseTimer;
    private float timeRemaining;
    private bool timerIsRunning;


    void Start()
    {
        // Initialize stats to max
        foodStat = foodStatMax;
        washStat = washStatMax;
        exerciseStat = exerciseStatMax;

        // Initialize stat colors to green
        foodImage.color = Color.green;
        washImage.color = Color.green;
        exerciseImage.color = Color.green;

        timeRemaining = statDecreaseTimer;
        timerIsRunning = true;
    }

    void Update()
    {
        // Logic for the timer
        if (timerIsRunning)
        {
            // If time is left, keep decrementing time
            // Otherwise, decrease all stats, update colors,
            // and reset timer
            if(timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                foodStat--;
                if(foodStat < 0)
                {
                    foodStat = 0;
                }
                UpdateStat(foodStatMax, ref foodStat, foodImage);
                washStat--;
                if (washStat < 0)
                {
                    washStat = 0;
                }
                UpdateStat(washStatMax, ref washStat, washImage);
                exerciseStat--;
                if (exerciseStat < 0)
                {
                    exerciseStat = 0;
                }
                UpdateStat(exerciseStatMax, ref exerciseStat, exerciseImage);
                timeRemaining = statDecreaseTimer;

            }
        }
    }

    // Public methods to link with buttons
    public void OnFeedClick()
    {
        foodStat++;
        UpdateStat(foodStatMax, ref foodStat, foodImage);
    }
    public void OnWashClick()
    {
        washStat++;
        UpdateStat(washStatMax, ref washStat, washImage);
    }
    public void OnExerciseClick()
    {
        exerciseStat++;
        UpdateStat(exerciseStatMax, ref exerciseStat, exerciseImage);
    }

    /// <summary>
    /// Updates a specfic stat based on a given max and value.
    ///
    ///     Since the ref keyword is new to me, I am documenting how it works for my learning - Joshua
    ///     Allows for a value type to be passed as a reference.
    /// </summary>
    /// <param name="maxStat"></param>
    /// <param name="currentStat"></param>
    /// <param name="statDisplay"></param>
    public void UpdateStat(int maxStat, ref int currentStat, Image statDisplay)
    {
        float statbreakPointThird = (float)maxStat / 3;
        float statbreakPointSecondThird = (float)maxStat / 3 * 2;
        // Cap number at max for stat
        if (currentStat > maxStat)
        {
            currentStat = maxStat;
        }

        // Change color according to current stat
        if (currentStat < statbreakPointThird)
        {
            statDisplay.color = Color.red;
        }
        else if (currentStat > statbreakPointThird && currentStat < statbreakPointSecondThird)
        {
            statDisplay.color = Color.yellow;
        }
        else if (currentStat > statbreakPointSecondThird)
        {
            statDisplay.color = Color.green;
        }
    }
}
