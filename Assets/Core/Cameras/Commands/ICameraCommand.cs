using Cinemachine;

namespace Core.Cameras.Commands
{
    public interface ICameraCommand
    {
        void Execute(CinemachineVirtualCamera virtualCamera);
    }
}
