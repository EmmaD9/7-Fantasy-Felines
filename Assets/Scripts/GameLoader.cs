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
        SceneManager.LoadScene("WashGame");
    }
}
