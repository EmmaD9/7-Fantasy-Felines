using UnityEngine;
using UnityEngine.Events;

public class CatWashMinigame : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Camera mainCamera;
    [SerializeField] private Transform sponge;
    [SerializeField] private Collider2D catCollider;
    [SerializeField] private ParticleSystem bubbleFX;
    [SerializeField] private DirtySpot[] dirtySpots;

    [Header("Cleaning Settings")]
    [SerializeField] private float cleanRequired = 5f;
    [SerializeField] private float cleanRate = 1f;

    [Header("Events")]
    public UnityEvent onWin;

    private bool holdingSponge = false;
    private float cleanProgress = 0f;
    private Collider2D spongeCollider;

    void Start()
    {
        spongeCollider = sponge.GetComponent<Collider2D>();
    }

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

        bool touchingCat = spongeCollider.IsTouching(catCollider);

        // Bubble FX only when rubbing the cat
        if (touchingCat)
        {
            if (!bubbleFX.isPlaying)
                bubbleFX.Play();

            cleanProgress += cleanRate * Time.deltaTime;
        }
        else
        {
            if (bubbleFX.isPlaying)
                bubbleFX.Stop();
        }

        // Dirty spot cleaning
        foreach (var spot in dirtySpots)
        {
            if (!spot.cleaned && spongeCollider.IsTouching(spot.GetComponent<Collider2D>()))
            {
                spot.Clean();
                cleanProgress += spot.cleanAmount;
            }
        }

        // Win check
        if (cleanProgress >= cleanRequired)
        {
            onWin?.Invoke();
        }
    }
}