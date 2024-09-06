using Core.Cameras.Scripts;
using UnityEngine;

namespace LevelGeneration.GenerationAssets.Tiles.Scripts
{
    public class TileTrigger : MonoBehaviour
    {
        public bool Enabled; // Hides the enabled field from the base class

        void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player") && Enabled)
                CameraManager.Instance.SwitchToRoomCamera();
        }
    }
}
