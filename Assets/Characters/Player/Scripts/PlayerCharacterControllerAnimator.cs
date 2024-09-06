using UnityEngine;

namespace Characters.Player.Scripts
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

            // If there is movement input
            if (Mathf.Abs(horizontalInput) > 0.1f || Mathf.Abs(verticalInput) > 0.1f)
            {
                // Calculate movement speed based on CharacterController's velocity
                var velocity = _characterController.velocity;
                var speed = velocity.magnitude / SpeedDivider;

                // Update the animator's speed parameter
                _animator.SetFloat(SpeedParameter, speed);
            }
            else
            {
                // If no input, immediately stop the walking animation
                _animator.SetFloat(SpeedParameter, 0f);
            }
        }
    }
}
