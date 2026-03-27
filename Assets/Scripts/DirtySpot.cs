using UnityEngine;

public class DirtySpot : MonoBehaviour
{
    public bool cleaned = false;
    public float cleanAmount = 1f; // how much this spot contributes

    public void Clean()
    {
        cleaned = true;
        gameObject.SetActive(false);
    }
}