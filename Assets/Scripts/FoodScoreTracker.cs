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

    private bool checking = true;

    private float winTimer = 0f;
    private float winTime = 3.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        counter.text = foodCount.ToString() + "/" + foodGoal;
    }

    // Update is called once per frame
    void Update()
    {
        if(checking)
        {
            if(foodCount >= foodGoal)
            {
                checking = false;
                title.text = "Great Job!";
            }
        }
        else
        {
            winTimer += Time.deltaTime;
            if(winTimer >= winTime)
            {
                StatManager.foodStat++;
                SceneManager.LoadScene("UI Testing");
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
