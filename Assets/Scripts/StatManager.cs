using UnityEngine;
using UnityEngine.UI;

public enum CatState
{
    Happy,
    Neutral,
    Sad
}
public class StatManager : MonoBehaviour
{
    // Field Declaration
    public Image foodImage;
    public Image washImage;
    public Image exerciseImage;

    public static int foodStat = -1;
    public static int washStat = -1;
    public static int exerciseStat = -1;

    public int foodStatMax;
    public int washStatMax;
    public int exerciseStatMax;

    public Sprite happyCat;
    public Sprite neutralCat;
    public Sprite sadCat;
    public GameObject catObject;

    private CatState foodState;
    private CatState washState;
    private CatState exerciseState;


    public float statDecreaseTimer;
    private float timeRemaining;
    private bool timerIsRunning;


    void Start()
    {
        // Initialize stats to max unless reloaded
        if(foodStat == -1)
        {
            foodStat = foodStatMax;
            washStat = washStatMax;
            exerciseStat = exerciseStatMax;

            // Initialize stat colors to green
            foodImage.color = Color.green;
            washImage.color = Color.green;
            exerciseImage.color = Color.green;

            foodState = CatState.Happy;
            washState = CatState.Happy;
            exerciseState = CatState.Happy;
        }        

        timeRemaining = statDecreaseTimer;
        timerIsRunning = true;
        UpdateCat();
    }

    void Update()
    {
        // Logic for the timer
        if (timerIsRunning)
        {
            // If time is left, keep decrementing time
            // Otherwise, decrease all stats, update colors,
            // and reset timer
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                foodStat--;
                if (foodStat < 0)
                {
                    foodStat = 0;
                }
                UpdateStat(foodStatMax, ref foodStat, foodImage, ref foodState);
                washStat--;
                if (washStat < 0)
                {
                    washStat = 0;
                }
                UpdateStat(washStatMax, ref washStat, washImage, ref washState);
                exerciseStat--;
                if (exerciseStat < 0)
                {
                    exerciseStat = 0;
                }
                UpdateStat(exerciseStatMax, ref exerciseStat, exerciseImage, ref exerciseState);
                timeRemaining = statDecreaseTimer;

            }
            UpdateCat();
        }
    }

    // Public methods to link with buttons
    public void OnFeedClick()
    {
        foodStat++;
        UpdateStat(foodStatMax, ref foodStat, foodImage, ref foodState);
    }
    public void OnWashClick()
    {
        washStat++;
        UpdateStat(washStatMax, ref washStat, washImage, ref washState);
    }
    public void OnExerciseClick()
    {
        exerciseStat++;
        UpdateStat(exerciseStatMax, ref exerciseStat, exerciseImage, ref exerciseState);
    }

    /// <summary>
    /// Updates a specific stat based on a given max and value.
    ///
    ///     Since the ref keyword is new to me, I am documenting how it works for my learning - Joshua
    ///     Allows for a value type to be passed as a reference.
    /// </summary>
    /// <param name="maxStat"></param>
    /// <param name="currentStat"></param>
    /// <param name="statDisplay"></param>
    public void UpdateStat(int maxStat, ref int currentStat, Image statDisplay, ref CatState catState)
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
            catState = CatState.Sad;
        }
        else if (currentStat > statbreakPointThird && currentStat < statbreakPointSecondThird)
        {
            statDisplay.color = Color.yellow;
            catState = CatState.Neutral;
        }
        else if (currentStat > statbreakPointSecondThird)
        {
            statDisplay.color = Color.green;
            catState = CatState.Happy;
        }
    }

    public void UpdateCat()
    {
        int happyCount = 0;
        int neutralCount = 0;
        int sadCount = 0;
        switch (foodState)
        {
            case CatState.Sad:
                sadCount++;
                break;
            case CatState.Happy:
                happyCount++;
                break;
            case CatState.Neutral:
                neutralCount++;
                break;
        }
        switch (exerciseState)
        {
            case CatState.Sad:
                sadCount++;
                break;
            case CatState.Happy:
                happyCount++;
                break;
            case CatState.Neutral:
                neutralCount++;
                break;

        }
        switch (washState)
        {
            case CatState.Sad:
                sadCount++;
                break;
            case CatState.Happy:
                happyCount++;
                break;
            case CatState.Neutral:
                neutralCount++;
                break;
        }

        if (sadCount >= 1)
        {
            catObject.GetComponent<SpriteRenderer>().sprite = sadCat;
        }
        else if(neutralCount >= 2)
        {
            catObject.GetComponent<SpriteRenderer>().sprite = neutralCat;
        }
        else if(happyCount == 3)
        {
            catObject.GetComponent<SpriteRenderer>().sprite = happyCat;
        }
        
    }
}