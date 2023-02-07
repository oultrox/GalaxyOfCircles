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

        private void Start()
        {
            _particleMain = _particlePrefab.main;
        }

        public void ActivateParticle()
        {
            _particleMain.startColor = _colorChanger.RandomColor;
            _particlePrefab.Play();
        }
    }
}

