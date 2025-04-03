using UnityEngine;

public class AdjustCollider : MonoBehaviour
{
    void Start()
    {
        BoxCollider2D boxCollider = GetComponent<BoxCollider2D>();
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

        if (boxCollider != null && spriteRenderer != null)
        {
            boxCollider.size = spriteRenderer.bounds.size;
        }
    }
}
