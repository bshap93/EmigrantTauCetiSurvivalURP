using System;
using DunGen;
using UnityEngine;

namespace Environment.Navigation.Scripts.ReticleData
{
    [Serializable]
    public class ReticleLocation
    {
        public Tile currentTile; // Reference to the tile or room the reticle belongs to
        public Vector3 absolutePosition; // Global position in the world
        public Vector3 relativePosition; // Position relative to the tile or room

        // Constructor
        public ReticleLocation(Vector3 absolute, Vector3 relative, Tile tile)
        {
            absolutePosition = absolute;
            relativePosition = relative;
            currentTile = tile;
        }
    }
}
