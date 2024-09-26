using UnityEngine;

namespace Environment.Hazard.Scripts
{
    public class ElectricalWireHazard : MonoBehaviour
    {
        public ParticleSystem sparksParticleSystem;
        
        void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                var playerController = other.GetComponent<CharacterController>();
                if (playerController == null) return;

                Debug.Log("Player entered electrical wire trigger");

                sparksParticleSystem.Play();
            }
        }
    }
}
