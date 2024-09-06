using Characters.Scripts.Commands.Move;
using UnityEngine;

namespace Characters.NPCs.Scripts
{
    public class AIController : MonoBehaviour
    {
        public GameObject target; // The target to follow (e.g., player or waypoint)
        public float speed = 3f;
        MoveToCommand _moveToCommand;

        void Update()
        {
        }
    }
}
