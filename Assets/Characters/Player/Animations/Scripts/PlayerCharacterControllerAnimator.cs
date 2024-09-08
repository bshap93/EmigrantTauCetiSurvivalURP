using UnityEngine;

namespace Characters.Player.Animations.Scripts
{
    public class CharacterControllerAnimator : MonoBehaviour
    {
        public string SpeedParameter = "ForwardSpeed";
        public float SpeedDivider = 1f;
        Animator _animator;

        CharacterController _characterController;

        void Start()
        {
            _animator = GetComponentInChildren<Animator>();
            _characterController = GetComponent<CharacterController>();

            if (_animator == null)
            {
                UnityEngine.Debug.LogError(
                    $"No animator on a child of {gameObject.name}. One is required for the CharacterControllerAnimator");

                enabled = false;
            }
        }

        void Update()
        {
            // Get movement input from the user
            var horizontalInput = UnityEngine.Input.GetAxis("Horizontal");
            var verticalInput = UnityEngine.Input.GetAxis("Vertical");

            // If there is input, calculate speed and set the animation
            if (Mathf.Abs(horizontalInput) > 0.1f || Mathf.Abs(verticalInput) > 0.1f)
            {
                // Set the animation speed directly based on input, ignoring velocity
                var inputDirection = new Vector3(horizontalInput, 0, verticalInput);
                var inputMagnitude = inputDirection.magnitude / SpeedDivider;

                _animator.SetFloat(SpeedParameter, inputMagnitude);
            }
            else
            {
                // Stop the animation immediately when no input is detected
                _animator.SetFloat(SpeedParameter, 0f);
            }
        }
    }
}
