using System.Collections.Generic;
using UnityEngine;

public class FoodScoreTracker : MonoBehaviour
{
    public int foodCount = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        foodCount++;
        Debug.Log(foodCount);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        foodCount--;
        Debug.Log(foodCount);
    }
}
