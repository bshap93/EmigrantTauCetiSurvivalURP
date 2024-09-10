using UnityEngine;

namespace Debugging.Scripts
{
    public class PlayerDebug : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
        }

        void OnCollisionEnter(Collision other)
        {
            Debug.Log("Player collided with " + other.gameObject.name);
        }
    }
}
