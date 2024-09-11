using UnityEngine;

namespace UI
{
    public class UIManager : MonoBehaviour
    {
        CustomCursor _customCursor;
        
        void Start()
        {
            _customCursor = new CustomCursor();
        }
        
    }
}
