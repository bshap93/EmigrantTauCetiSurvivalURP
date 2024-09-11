using UnityEngine;

public class CustomCursor : MonoBehaviour
{
    // Reference to the texture for the custom cursor
    public Texture2D cursorTexture;

    // The point on the cursor image that will act as the "click" point (hotspot)
    public Vector2 cursorHotspot = Vector2.zero;

    // Start is called before the first frame update
    void Start()
    {
        SetCustomCursor();
    }

    void SetCustomCursor()
    {
        // Set the custom cursor
        Cursor.SetCursor(cursorTexture, cursorHotspot, CursorMode.Auto);
    }

    // Optional: Reset the cursor to default when exiting the game or specific state
    void OnDisable()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);  // Reset to default
    }
}
