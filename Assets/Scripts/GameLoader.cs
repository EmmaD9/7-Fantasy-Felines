using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLoader : MonoBehaviour
{
    public void LoadFeed()
    {
        SceneManager.LoadScene("FoodGame");
    }

    public void LoadWash()
    {
        StatManager.washStat++;
        SceneManager.LoadScene("WashGame");
    }

    public void LoadHome()
    {
        SceneManager.LoadScene("UI Testing");
    }
}
