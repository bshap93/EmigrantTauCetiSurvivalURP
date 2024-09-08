using Cinemachine;
using UnityEngine;

namespace Core.Cameras.Managers.Scripts
{
    public enum CameraTypeEnum
    {
        Player = 10,
        Room = 5
    }

    public class CameraManager : MonoBehaviour
    {
        public GameObject playerCamera;
        public GameObject roomCamera;

        public static CameraManager Instance { get; private set; }

        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject); // Keep the manager across scenes
            }
            else
            {
                Destroy(gameObject); // Prevent duplicates
            }

            // SetActiveCamera(0);
        }

        public void SetActiveCamera(CameraTypeEnum virtualCamera)
        {
            switch (virtualCamera)
            {
                case CameraTypeEnum.Player:
                    playerCamera.GetComponent<CinemachineVirtualCamera>().Priority = 10;
                    roomCamera.GetComponent<CinemachineVirtualCamera>().Priority = 5;
                    break;
                case CameraTypeEnum.Room:
                    playerCamera.GetComponent<CinemachineVirtualCamera>().Priority = 5;
                    roomCamera.GetComponent<CinemachineVirtualCamera>().Priority = 10;

                    break;
            }
        }
        public void SetActiveRoom(GameObject room)
        {
            throw new System.NotImplementedException();
        }
    }
}
