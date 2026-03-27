using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Threading;
using UnityEngine.SceneManagement;

public class FoodScoreTracker : MonoBehaviour
{
    public int foodCount = 0;
    public int foodGoal = 35;
    public TextMeshProUGUI counter;
    public TextMeshProUGUI title;

    private bool win = false;

    private float winTimer = 0f;
    private float winTime = 3.0f;

    private float lossTimer = 0f;
    private float lossTime = 3.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        counter.text = foodCount.ToString() + "/" + foodGoal;
    }

    // Update is called once per frame
    void Update()
    {
        if(win)
        {
            winTimer += Time.deltaTime;
            if (winTimer >= winTime)
            {
                StatManager.foodStat++;
                SceneManager.LoadScene("UI Testing");
            }
        }
        else
        {
            if (!FoodManager.isEmpty)
            {
                if (foodCount >= foodGoal)
                {
                    win = true;
                    title.text = "Great Job!";
                }
            }
            else
            {
                if (foodCount <= foodGoal)
                {
                    lossTimer += Time.deltaTime;
                    if (lossTimer >= lossTime)
                    {
                        title.text = "Try Again!";
                    }
                    if (lossTimer >= lossTime + 2.0f)
                    {
                        SceneManager.LoadScene("UI Testing");
                    }
                }
                else
                {
                    win = true;
                    title.text = "Great Job!";
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        foodCount++;
        counter.text = foodCount.ToString() + "/" + foodGoal;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        foodCount--;
        counter.text = foodCount.ToString() + "/" + foodGoal;
    }
}
