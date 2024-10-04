using Core.Utilities.Commands;
using UnityEngine;

namespace Environment.Interactables.Consoles.Scripts.Commands
{
    public class OpenConsoleCommand : ISimpleCommand
    {
        public OpenConsoleCommand(OpenableConsole openableConsole)
        {
            Debug.Log("OpenConsoleCommand Created");
        }
        public void Execute()
        {
            Debug.Log("OpenConsoleCommand Execute");
        }
    }
}
