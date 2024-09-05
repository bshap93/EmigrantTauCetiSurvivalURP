using UnityEngine;

namespace Core.Command
{
    public abstract class BaseCommand
    {
        public abstract void Execute(GameObject actor);
    }
}
