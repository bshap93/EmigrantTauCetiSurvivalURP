using UI.ETCCustomCursor.Scripts.Commands;
using UnityEngine;

namespace UI.ETCCustomCursor.Scripts
{
    public class CustomCursor
    {
        // The point on the cursor image that will act as the "click" point (hotspot)
        readonly Vector2 _cursorHotspot;
        // Reference to the texture for the custom cursor
        readonly Texture2D _cursorTexture;

        public CustomCursor(string cursorTexturePath, Vector2 cursorHotspot)
        {
            _cursorTexture = Resources.Load<Texture2D>(cursorTexturePath);
            _cursorHotspot = cursorHotspot;
            SetCustomCursor();
        }


        void SetCustomCursor()
        {
            // Set the custom cursor
            Cursor.SetCursor(_cursorTexture, _cursorHotspot, CursorMode.Auto);
            var enableCursorCommand = new EnableConfinedCursorCommand();
            enableCursorCommand.Execute();
        }

        // Optional: Reset the cursor to default when exiting the game or specific state
        void OnDisable()
        {
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto); // Reset to default
        }
    }
}
