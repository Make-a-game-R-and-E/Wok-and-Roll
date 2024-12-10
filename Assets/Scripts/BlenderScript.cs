using UnityEngine;

public class BlenderScript : MonoBehaviour
{
    private string[] correctOrder = { "Lemon", "Water", "Milk", "Coconut" };

    [SerializeField] SpriteRenderer blenderSpriteRenderer;
    [SerializeField] Sprite emptyBlenderSprite; // The blender sprite when it's empty
    [SerializeField] Sprite filledBlenderSprite; // The blender sprite when it's filled
    [SerializeField] Sprite overflowBlenderSprite; // The blender sprite when it's overflow
    [SerializeField] Sprite lemonadeCupSprite; // The lemonade cup sprite

    int lemonCount = 0;
    int waterCount = 0;
    int milkCount = 0;
    int coconutCount = 0;

    void Start()
    {
        // The blender is empty at the beginning
        if (blenderSpriteRenderer != null)
        {
            blenderSpriteRenderer.sprite = emptyBlenderSprite;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("OnTriggerEnter2D: " + other.gameObject.name);
        string objectName = other.gameObject.name;

        // Check if the object is one of the correct ingredients
        UpdateCounts(objectName);

        // Check if the blender contains more than 4 ingredients
        UpdateBlenderState();

        // If the blender contains more than 4 ingredients, end the game
        if (lemonCount + waterCount + milkCount + coconutCount > 4)
        {
            Debug.Log("Game Over: Blender overflow!");
            EndGameWithOverflow();
        }

        // If the blender contains all the correct ingredients, change the sprite to the lemonade cup
        if (lemonCount > 0 && waterCount > 0 && milkCount > 0 && coconutCount > 0)
        {
            Debug.Log("Lemonade is ready!");
            ChangeToLemonadeCup();
        }

        // Destroy the object that entered the blender
        Destroy(other.gameObject);
    }

    private void UpdateCounts(string objectName)
    {
        switch (objectName)
        {
            case "Lemon":
                Debug.Log("Lemon");
                lemonCount++;
                Debug.Log(lemonCount);
                break;

            case "Water":
                Debug.Log("Water");
                waterCount++;
                Debug.Log(waterCount);
                break;
            case "Milk":
                Debug.Log("Milk");
                milkCount++;
                Debug.Log(milkCount);
                break;
            case "Coconut":
                Debug.Log("Coconut");
                coconutCount++;
                Debug.Log(coconutCount);
                break;
        }
    }

    private void UpdateBlenderState()
    {
        if (lemonCount + waterCount + milkCount + coconutCount == 1)
        {
            // Change to the filled blender sprite
            blenderSpriteRenderer.sprite = filledBlenderSprite;
        }
        else if (lemonCount + waterCount + milkCount + coconutCount > 4)
        {
            // Change to the overflow blender sprite
            blenderSpriteRenderer.sprite = overflowBlenderSprite;
        }
    }

    private void ChangeToLemonadeCup()
    {
        if (blenderSpriteRenderer != null)
        {
            blenderSpriteRenderer.sprite = lemonadeCupSprite;
        }
    }

    private void EndGameWithOverflow()
    {
        if (blenderSpriteRenderer != null)
        {
            blenderSpriteRenderer.sprite = overflowBlenderSprite;
        }

        Debug.Log("Game Over: Blender overflow!");
        Time.timeScale = 0; // Stop the game
    }
}

