using UnityEngine;

namespace Characters.Command
{
    // Base class for all commands
    public abstract class BaseCommand
    {
        // Execute the command on the given actor
        public abstract void Execute(GameObject actor);
    }
}
