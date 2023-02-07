using UnityEngine;

namespace GalaxyOfCircles.Flavour
{
    public class GraphicBouncer : MonoBehaviour
    {
        [SerializeField] private float _scaleFactor = 1.5f ;
        private SpriteRenderer _spriteRenderer;
        private Vector3 _initialScale;
        private Vector3 _targetScale;
        private const float LERP_DURATION = 0.3f;
        private float _currentLerpTime = 0f;
        private bool _isActive = false;
        
        void Start()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _initialScale = _spriteRenderer.transform.localScale;
            _targetScale = _initialScale * _scaleFactor;
        }

        void Update()
        {
            if(_isActive)
                ApplySizeLerp();
        }

        private void ApplySizeLerp()
        {
            _currentLerpTime += Time.deltaTime;
            
            if (_currentLerpTime > LERP_DURATION)
            {
                _currentLerpTime = 0f;
                _isActive = false;
            }

            float t = _currentLerpTime / LERP_DURATION;
            _spriteRenderer.transform.localScale = Vector3.Lerp(_initialScale, _targetScale, Mathf.Sin(Mathf.PI * t));
        }

        public void LerpSize()
        {
            _isActive = true;
        }
    }
}
