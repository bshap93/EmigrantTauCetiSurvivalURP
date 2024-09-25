using Items.Equipment.Commands;
using Items.Scripts;

namespace Items.Equipment
{
    public abstract class Tool : EquippableItemObject
    {
        IToolUseCommand _toolUseCommand;
        public override void InitializeUseCommand(EquippableHandler equippableHandler)
        {
        }
    }
}
