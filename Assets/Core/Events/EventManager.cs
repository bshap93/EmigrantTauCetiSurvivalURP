using UnityEngine;

namespace Core.Events
{
    public class EventManager : MonoBehaviour
    {
        public static EventManager Instance { get; private set; }


        void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}
