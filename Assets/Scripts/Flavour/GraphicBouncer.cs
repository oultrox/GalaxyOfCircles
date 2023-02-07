using UnityEngine;

namespace GalaxyOfCircles.Flavour
{
    public class GraphicBouncer : MonoBehaviour
    {
        private SpriteRenderer spriteRenderer;
        private Vector3 initialScale;
        private Vector3 targetScale;
        private const float LERP_DURATION = 0.3f;
        private float currentLerpTime = 0f;
        private bool _isActive = false;
        
        void Start()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            initialScale = spriteRenderer.transform.localScale;
            targetScale = initialScale * 1.3f;
        }

        void Update()
        {
            if(_isActive)
                ApplySizeLerp();
        }

        private void ApplySizeLerp()
        {
            currentLerpTime += Time.deltaTime;
            
            if (currentLerpTime > LERP_DURATION)
            {
                currentLerpTime = 0f;
                _isActive = false;
            }

            float t = currentLerpTime / LERP_DURATION;
            spriteRenderer.transform.localScale = Vector3.Lerp(initialScale, targetScale, Mathf.Sin(Mathf.PI * t));
        }

        public void LerpSize()
        {
            _isActive = true;
        }
    }
}
