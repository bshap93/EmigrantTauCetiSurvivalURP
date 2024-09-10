using System.Collections.Generic;
using System.Numerics;

namespace Core.SaveSystem.Scripts
{
    public class LevelState
    {
        public List<Vector3> doorStates;
        public int dungeonSeed;
        public List<Vector3> enemyPositions;
        public int levelID;
    }
}
