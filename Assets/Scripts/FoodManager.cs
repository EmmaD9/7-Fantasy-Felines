using UnityEngine;

public class FoodManager : MonoBehaviour
{
    private float degrees;
    public float speed;
    public GameObject food;

    void Start()
    {
        for (int i = 0; i < 50; i++)
        {
            Instantiate(food, new Vector3(transform.position.x, transform.position.y+.75f, 10), Quaternion.identity);
        }
    }


    void Update()
    {
        transform.rotation = Quaternion.Euler(Vector3.forward * degrees);
        degrees -= speed;
    }
}
