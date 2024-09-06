using System.Collections.Generic;
using UnityEngine;

namespace Core.Cameras.Scripts
{
    public class RoomCameraPositions : ScriptableObject
    {
        public List<Transform> cameraPositions = new();
    }
}
