using Characters.Player.Camera.Scripts.Commands;
using Cinemachine;
using DG.Tweening;

namespace Core.Cameras.Commands.MoveCamera
{
    public class MoveCameraRight : ICameraCommand
    {
        public void Execute(CinemachineVirtualCamera virtualCamera)
        {
            // Get the current position of the virtual camera
            var currentPosition = virtualCamera.transform.position;

            // Move the virtual camera to the right by 1 unit
            virtualCamera.transform.DOMoveX(currentPosition.x + 1f, 0.5f);
        }
    }
}
