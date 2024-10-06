using System.Collections.Generic;
using Characters.Scripts;
using UnityEngine;

namespace Environment.Hazard.Scripts.ElectricalWireHazard
{
    public class ElectricalWireHazard : ElectricalHazard, ICuttable
    {
        public ParticleSystem sparksParticleSystem;
        public GameObject scrap;


        public void Cut(float secondsToCut)
        {
            StartCoroutine(DestroyWire(secondsToCut));
        }
        public float GetSecondsToCut()
        {
            return 0.5f;
        }

        IEnumerator<WaitForSeconds> DestroyWire(float secondsToCut)
        {
            yield return new WaitForSeconds(secondsToCut);
            sparksParticleSystem.Stop();
            scrap.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
