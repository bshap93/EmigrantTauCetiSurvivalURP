﻿using Characters.Player.Camera.Scripts.Commands;
using Cinemachine;
using DG.Tweening;
using UnityEngine;

namespace Core.Cameras.Commands.RotateCamera
{
    public class RotateClockwiseCommand : ICameraCommand
    {
        public void Execute(CinemachineVirtualCamera virtualCamera)
        {
            var initialYRotation = virtualCamera.transform.rotation.eulerAngles.y;
            var initialXRotation = virtualCamera.transform.rotation.eulerAngles.x;
            var initialZRotation = virtualCamera.transform.rotation.eulerAngles.z;

            var targetYRotation = initialYRotation + 90f;

            // Rotate the virtual camera to the new rotation over 0.5 seconds using DOTween
            virtualCamera.transform.DORotate(
                new Vector3(initialXRotation, targetYRotation, initialZRotation), 0.5f);
        }
    }
}
