using UnityEngine;

public class BlockController : MonoBehaviour
{
    private Collider2D blockCollider;

    void Start()
    {
        
        blockCollider = GetComponent<Collider2D>();
    }

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ToggleCollider();
        }
    }

    void ToggleCollider()
    {
        
        blockCollider.enabled = !blockCollider.enabled;
    }
}