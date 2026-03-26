using UnityEngine;

public class FoodManager : MonoBehaviour
{
    public GameObject food;
    public static int numFood = 50;
    public float tiltScalar = 1.0f;
    private Vector3 smoothedAcc;

    [Range(0.01f, 0.5f)]
    public float smoothness;

    void Start()
    {
        for (int i = 0; i < numFood; i++)
        {
            Instantiate(food, new Vector3(transform.position.x, transform.position.y+.75f, 10), Quaternion.identity);
        }
    }


    void FixedUpdate()
    {
        // Lerp input acceleration to smooth
        smoothedAcc = Vector3.Lerp(smoothedAcc, new Vector3(0, 0, Input.acceleration.x), smoothness);

        // Apply the smoothed acceleration to the rotation
        transform.rotation = Quaternion.Euler(-smoothedAcc * tiltScalar);
    }
}
