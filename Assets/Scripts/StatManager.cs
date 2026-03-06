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
                FeedUpdate();
                washStat--;
                if (washStat < 0)
                {
                    washStat = 0;
                }
                WashUpdate();
                exerciseStat--;
                if (exerciseStat < 0)
                {
                    exerciseStat = 0;
                }
                ExerciseUpdate();
                timeRemaining = statDecreaseTimer;
            }
        }
    }

    // Public methods to link with buttons
    public void OnFeedClick()
    {
        foodStat++;
        FeedUpdate();
    }
    public void OnWashClick()
    {
        washStat++;
        WashUpdate();
    }
    public void OnExerciseClick()
    {
        exerciseStat++;
        ExerciseUpdate();
    }

    // Methods to update stat color
    public void FeedUpdate()
    {
        // Cap number at max for stat
        if (foodStat > foodStatMax)
        {
            foodStat = foodStatMax;
        }

        // Change color according to current stat
        if (foodStat < 7)
        {
            foodImage.color = Color.red;
        }
        else if (foodStat > 7 && foodStat < 15)
        {
            foodImage.color = Color.yellow;
        }
        else if (foodStat > 15)
        {
            foodImage.color = Color.green;
        }
    }

    public void WashUpdate()
    {
        // Cap number at max for stat
        if (washStat > washStatMax)
        {
            washStat = washStatMax;
        }

        // Change color according to current stat
        if (washStat < 7)
        {
            washImage.color = Color.red;
        }
        else if (washStat > 7 && washStat < 15)
        {
            washImage.color = Color.yellow;
        }
        else if (washStat > 15)
        {
            washImage.color = Color.green;
        }
    }

    public void ExerciseUpdate()
    {
        // Cap number at max for stat
        if (exerciseStat > exerciseStatMax)
        {
            exerciseStat = exerciseStatMax;
        }

        // Change color according to current stat
        if (exerciseStat < 7)
        {
            exerciseImage.color = Color.red;
        }
        else if (exerciseStat > 7 && exerciseStat < 15)
        {
            exerciseImage.color = Color.yellow;
        }
        else if (exerciseStat > 15)
        {
            exerciseImage.color = Color.green;
        }
    }
}
