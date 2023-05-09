using UnityEngine;
using UnityEngine.UI;

public class HoverHealthbar : MonoBehaviour
{
    private SpriteRenderer foregroundSprite;    // Reference to the foreground sprite of the health bar

    private void Start()
    {
        foregroundSprite = GetComponent<SpriteRenderer>();
    }

    public void UpdateHealth(float currentHealth, float maxHealth)
    {
        // Calculate the scale of the foreground sprite based on the current and max health
        float scaleX = currentHealth / maxHealth;
        scaleX = Mathf.Clamp01(scaleX);

        // Set the scale of the foreground sprite
        foregroundSprite.transform.localScale = new Vector3(scaleX, 0.1f, 1f);
    }
}

