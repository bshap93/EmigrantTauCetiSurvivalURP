using Cinemachine;

namespace Characters.Player.Camera.Scripts.Commands
{
    public interface ICameraCommand
    {
        void Execute(CinemachineVirtualCamera virtualCamera);
    }
}
