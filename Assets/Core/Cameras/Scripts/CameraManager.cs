using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

namespace Core.Cameras.Scripts
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
        public Dictionary<CameraTypeEnum, CinemachineVirtualCamera> Cameras = new();

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

        void Start()
        {
            // Create a new CameraData instance for a player camera without room data
            var playerCameraData = new CameraData(CameraData.CameraTypeEnum.Player);
            // Create a new CameraData instance for a room camera without room data
            var roomCameraData = new CameraData(CameraData.CameraTypeEnum.Room);
        }

        public void SetActiveCamera(CameraTypeEnum cameraType)
        {
        }


        public void SwitchToRoomCamera()
        {
            SetActiveCamera(CameraTypeEnum.Room);
        }

        public void SwitchToPlayerCamera()
        {
            SetActiveCamera(CameraTypeEnum.Player);
        }
    }
}
