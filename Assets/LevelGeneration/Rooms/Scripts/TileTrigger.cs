using Core.Cameras.Managers.Scripts;
using UnityEngine;

namespace LevelGeneration.Rooms.Scripts
{
    public class TileTrigger : MonoBehaviour
    {
        public new bool enabled; // Hides the enabled field from the base class
        public CameraTypeEnum cameraType;
        void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player") && enabled)
            {
                CameraManager.Instance.SetActiveCamera(cameraType); 
                CameraManager.Instance.SetActiveRoom(this.gameObject);
            }

        }
    }
}
