using UnityEngine;

public class GhostModeController : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Collider2D playerCollider;
    private bool isGhostMode = false;

    void Start()
    {
        
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerCollider = GetComponent<Collider2D>();
    }

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ToggleGhostMode();
        }
    }

    void ToggleGhostMode()
    {
        
        isGhostMode = !isGhostMode;

        
        spriteRenderer.enabled = !isGhostMode;
        playerCollider.enabled = !isGhostMode;
    }
}