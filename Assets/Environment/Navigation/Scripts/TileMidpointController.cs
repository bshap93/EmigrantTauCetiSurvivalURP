using DunGen;
using Plugins.DunGen.Code;
using UnityEngine;

namespace Environment.Navigation.Scripts
{
    public class TileMidpointController : MonoBehaviour
    {
        public DungenCharacter dungenCharacter;
        Transform _tileMidpoint;

        void Start()
        {
            _tileMidpoint = transform;
            dungenCharacter.OnTileChanged += OnCharacterTileChanged;
        }

        void OnCharacterTileChanged(DungenCharacter character, Tile previousTile, Tile newTile)
        {
            // Use Dotween to move the midpoint to the new tile's position

            _tileMidpoint = newTile.transform;
        }
    }
}
