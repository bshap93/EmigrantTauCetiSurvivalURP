using DunGen;
using FischlWorks_FogWar;
using UnityEngine;

namespace Environment.Navigation.Scripts.FogOfWar
{
    public class FogOfWarSupplement : MonoBehaviour
    {
        public DungenCharacter dungenCharacter;
        csFogWar _fogWar;
        Transform roomMidpoint;

        void Start()
        {
            _fogWar = GetComponent<csFogWar>();
            dungenCharacter.OnTileChanged += OnCharacterTileChanged;
            roomMidpoint.position = dungenCharacter.CurrentTile.Placement.Position;
            _fogWar.levelMidPoint.position = roomMidpoint.position;
        }

        void OnCharacterTileChanged(DungenCharacter character, Tile previousTile, Tile newTile)
        {
            roomMidpoint.position = newTile.Placement.Position;
            _fogWar.levelMidPoint.position = roomMidpoint.position;

            // Update the fog of war
        }
    }
}
