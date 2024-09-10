using Cinemachine;
using UnityEngine;

namespace Core.Cameras.Commands.MoveCamera
{
    public class MouseCameraMovementCommand : ICameraCommand
    {
        readonly float _deadZoneRadius;
        readonly float _maxMouseOffset;
        readonly float _mouseInfluence;
        readonly Vector2 _mouseMovement;

        public MouseCameraMovementCommand(Vector2 mouseMovement, float mouseInfluence, float maxMouseOffset,
            float deadZoneRadius)
        {
            _mouseMovement = mouseMovement;
            _mouseInfluence = mouseInfluence;
            _maxMouseOffset = maxMouseOffset;
            _deadZoneRadius = deadZoneRadius;
        }

        public void Execute(CinemachineVirtualCamera virtualCamera, float _)
        {
            var cameraOffset = virtualCamera.GetComponent<CinemachineCameraOffset>();
            if (cameraOffset == null || _mouseMovement.magnitude <= _deadZoneRadius) return;

            var normalizedMovement = _mouseMovement.normalized;
            var newOffset = cameraOffset.m_Offset;

            newOffset.x = Mathf.Clamp(
                newOffset.x + normalizedMovement.x * _mouseInfluence * Time.deltaTime, -_maxMouseOffset,
                _maxMouseOffset);

            newOffset.y = Mathf.Clamp(
                newOffset.y + normalizedMovement.y * _mouseInfluence * Time.deltaTime, -_maxMouseOffset,
                _maxMouseOffset);

            cameraOffset.m_Offset = newOffset;
        }
    }
}
