using UnityEngine;

public class FoodManager : MonoBehaviour
{
    public GameObject food;
    public static int numFood = 50;
    public static bool isEmpty;
    public float tiltScalar = 1.0f;
    private Vector3 smoothedAcc;
    private int foodLeft;

    [Range(0.01f, 0.5f)]
    public float smoothness;

    void Start()
    {
        for (int i = 0; i < numFood; i++)
        {
            Instantiate(food, new Vector3(transform.position.x, transform.position.y+.75f, 10), Quaternion.identity);
        }
        foodLeft = numFood;
        isEmpty = false;
    }

    private void Update()
    {
        if(foodLeft <= 0)
        {
            isEmpty = true;
        }
        Debug.Log(foodLeft);
    }


    void FixedUpdate()
    {
        // Lerp input acceleration to smooth
        smoothedAcc = Vector3.Lerp(smoothedAcc, new Vector3(0, 0, Input.acceleration.x), smoothness);

        // Apply the smoothed acceleration to the rotation
        transform.rotation = Quaternion.Euler(-smoothedAcc * tiltScalar);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        foodLeft--;
    }
}
