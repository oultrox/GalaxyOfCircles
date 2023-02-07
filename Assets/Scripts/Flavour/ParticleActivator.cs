using System.Collections;
using UnityEngine;


namespace GalaxyOfCircles.Flavour
{
    public class ParticleActivator : MonoBehaviour
    {
        private ParticleSystem _particlePrefab;
        private ColorChanger _colorChanger;
        private ParticleSystem.MainModule _particleMain;
        private const float DELAY_DEACTIVATE = 0.8f;
       
        private void Awake()
        {
            _colorChanger = GetComponent<ColorChanger>();
            _particlePrefab = GetComponentInChildren<ParticleSystem>();
        }

        public void ActivateParticle()
        {
            StopAllCoroutines();
            StartCoroutine(EnableParticle());
        }

        private IEnumerator EnableParticle()
        {
            _particlePrefab.gameObject.SetActive(true);
            _particleMain = _particlePrefab.main;
            _particleMain.startColor = _colorChanger.RandomColor;

            _particlePrefab.Play();
            yield return new WaitForSeconds(DELAY_DEACTIVATE);
            _particlePrefab.gameObject.SetActive(false);
        }
    }
}

