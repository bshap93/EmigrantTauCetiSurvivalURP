namespace Core.Levels
{
    public struct DungeonLevel
    {
        public int LevelID;
        public int Seed;

        public DungeonLevel(int levelID, int seed)
        {
            LevelID = levelID;
            Seed = seed;
        }
    }
}
