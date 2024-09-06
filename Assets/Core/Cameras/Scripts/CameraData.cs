using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

namespace Core.Cameras.Scripts
{
    public class CameraData
    {
        // Enum for camera types
        public enum CameraTypeEnum
        {
            Player,
            Room
        }

        // Constructor for initializing the data
        public CameraData(CameraTypeEnum cameraType, GameObject room = null, List<Transform> fixedPositions = null)
        {
            CameraType = cameraType;
            Room = room;
            FixedPositions = fixedPositions ?? new List<Transform>(); // Default empty list if null
        }

        // Camera type (Player or Room)
        public CameraTypeEnum CameraType { get; set; }

        // The room this camera is associated with (if applicable)
        public GameObject Room { get; set; }

        // Fixed camera positions for the room
        [CanBeNull] public List<Transform> FixedPositions { get; set; }

        // Method to set the room for the camera
        public void SetRoom(GameObject room)
        {
            Room = room;
        }

        // Method to add a fixed camera position
        public void AddFixedPosition(Transform position)
        {
            FixedPositions.Add(position);
        }

        // Method to clear all fixed positions
        public void ClearFixedPositions()
        {
            FixedPositions.Clear();
        }

        // Get a specific camera position (by index)
        public Transform GetFixedPosition(int index)
        {
            if (index >= 0 && index < FixedPositions.Count) return FixedPositions[index];
            return null; // Return null if index is out of bounds
        }
    }
}
