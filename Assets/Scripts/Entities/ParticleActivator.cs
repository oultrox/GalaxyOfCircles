using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GalaxyOfCircles.Entities
{
    public class ParticleActivator : MonoBehaviour
    {
        private ParticleSystem _particlePrefab;
        private ColorChanger _colorChanger;
        private ParticleSystem.MainModule _particleMain;
        private readonly float _delayDeactivate = 0.8f;
       
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
            yield return new WaitForSeconds(_delayDeactivate);
            _particlePrefab.gameObject.SetActive(false);
        }
    }
}

