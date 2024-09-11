using UI.ETCCustomCursor.Scripts;
using UnityEngine;

namespace UI
{
    public class UIManager : MonoBehaviour
    {
        public string cursorName;
        public Vector2 cursorHotspot;
        CustomCursor _customCursor;

        void Start()
        {
            // Create and set the custom cursor
            _customCursor = new CustomCursor(cursorName, cursorHotspot);
        }
    }
}
