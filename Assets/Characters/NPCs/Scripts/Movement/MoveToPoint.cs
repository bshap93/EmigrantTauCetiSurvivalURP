using UnityEngine;
using UnityEngine.AI;

namespace Characters.Movement.Scripts
{
    public class MoveToPoint : MonoBehaviour
    {
        Camera _camera;
        NavMeshAgent agent;

        void Start()
        {
            _camera = Camera.main;
            agent = GetComponent<NavMeshAgent>();
        }

        void Update()
        {
            if (Input.GetMouseButton(0))
            {
                var mousePosition = Input.mousePosition;

                if (_camera != null)
                {
                    var ray = _camera.ScreenPointToRay(mousePosition);

                    RaycastHit hit;

                    if (Physics.Raycast(ray, out hit))
                    {
                        var selectedPoint = hit.point;

                        agent.SetDestination(selectedPoint);
                    }
                }
            }
        }
    }
}
