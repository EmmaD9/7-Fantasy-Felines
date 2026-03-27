using UnityEngine;
using UnityEngine.Events;

public class CatWashMinigame : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Camera mainCamera;
    [SerializeField] private Transform sponge;
    [SerializeField] private Collider2D catCollider;

    [Header("Cleaning Settings")]

    //can change for difficulty
    [SerializeField] private float cleanRequired = 5f;

    //the rate of change of cleaning
    [SerializeField] private float cleanRate = 1f;    

    [Header("Events")]
    public UnityEvent onWin;

    private bool holdingSponge = false;
    private float cleanProgress = 0f;

    void Update()
    {
        HandleSpongePickup();
        HandleSpongeMovement();
        HandleCleaning();
    }

    void HandleSpongePickup()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);

            Collider2D hit = Physics2D.OverlapPoint(mousePos);
            if (hit != null && hit.transform == sponge)
            {
                holdingSponge = true;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            holdingSponge = false;
        }
    }

    void HandleSpongeMovement()
    {
        if (!holdingSponge) return;

        Vector3 mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f;
        sponge.position = mousePos;
    }

    void HandleCleaning()
    {
        if (!holdingSponge) return;

        if (sponge.GetComponent<Collider2D>().IsTouching(catCollider))
        {
            cleanProgress += cleanRate * Time.deltaTime;

            if (cleanProgress >= cleanRequired)
            {
                onWin?.Invoke();
            }
        }
    }
}