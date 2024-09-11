using UnityEngine;

public class CustomCursor 
{
    // Reference to the texture for the custom cursor
    public Texture2D cursorTexture;

    // The point on the cursor image that will act as the "click" point (hotspot)
    public Vector2 cursorHotspot;

    public CustomCursor(string cursorTexturePath, Vector2 cursorHotspot)
    {
        cursorTexture = Resources.Load<Texture2D>(cursorTexturePath);
        this.cursorHotspot = cursorHotspot;
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
