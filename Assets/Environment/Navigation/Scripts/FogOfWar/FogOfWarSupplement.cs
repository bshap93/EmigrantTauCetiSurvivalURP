using DunGen;
using Plugins.DunGen.Code;
using UnityEngine;

namespace Environment.Navigation.Scripts.FogOfWar
{
    public class FogOfWarSupplement : MonoBehaviour
    {
        public DungenCharacter dungenCharacter;
        Plugins.AOSFogWar.FogOfWar _fogOfWar;
        Transform roomMidpoint;

        void Start()
        {
            _fogOfWar = GetComponent<Plugins.AOSFogWar.FogOfWar>();
            dungenCharacter.OnTileChanged += OnCharacterTileChanged;
            roomMidpoint.position = dungenCharacter.CurrentTile.Placement.Position;
            _fogOfWar.levelMidPoint.position = roomMidpoint.position;
        }

        void OnCharacterTileChanged(DungenCharacter character, Tile previousTile, Tile newTile)
        {
            roomMidpoint.position = newTile.Placement.Position;
            _fogOfWar.levelMidPoint.position = roomMidpoint.position;

            // Update the fog of war
        }
    }
}
