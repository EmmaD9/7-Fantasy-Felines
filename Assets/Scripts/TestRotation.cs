using UnityEngine;

public class TestRotation : MonoBehaviour
{
    private float degrees;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Euler(Vector3.forward * degrees);
        degrees -= 0.1f;
    }
}
