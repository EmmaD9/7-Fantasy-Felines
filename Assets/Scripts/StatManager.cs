using UnityEngine;
using UnityEngine.UI;

public class StatManager : MonoBehaviour
{
    // Field Declaration
    public Image foodStat;
    public Image washStat;
    public Image exerciseStat;


    // Public methods to link with buttons
    public void OnFeedClick()
    {
        Debug.Log("Nom Nom Nom!");
        foodStat.color = Color.green;
    }
    public void OnWashClick()
    {
        Debug.Log("Squeaky Clean!");
        washStat.color = Color.green;
    }
    public void OnExerciseClick()
    {
        Debug.Log("Whew! I'm tired!");
        exerciseStat.color = Color.red;
    }
}
