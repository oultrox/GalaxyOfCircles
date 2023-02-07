using System.Collections;
using UnityEngine;

namespace GalaxyOfCircles.Flavour
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class ColorChanger : MonoBehaviour
    {
        [SerializeField] private float _colorChangeTime = 0.5f;
        private SpriteRenderer _spriteRender;
        private float _r, _g, _b;
        private Color _originalColor;
        private Color _randomColor = new Color(0,0,0);
        private bool _isActive = false;
        private float _currentColorTimer;
        #region Properties
        public Color RandomColor { get => _randomColor; set => _randomColor = value; }
        #endregion


        private void Awake()
        {
            _spriteRender = GetComponent<SpriteRenderer>();
        }

        private void Start()
        {
            _originalColor = _spriteRender.color;
        }

        void Update()
        {
            if (_isActive)
                CheckCooldownColor();
        }

        // Manual timer for changing color. I used a Coroutine in here instead... but it was allocating GC so I changed it.
        public void ChangeRandomColor()
        {
            _r = Random.Range(0f, 1f);
            _g = Random.Range(0f, 1f);
            _b = Random.Range(0f, 1f);
            _randomColor.r = _r;
            _randomColor.g = _g;
            _randomColor.b = _b;
            _spriteRender.color = _randomColor;
            _currentColorTimer = 0f;
            _isActive = true;
        }
        
        private void CheckCooldownColor()
        {
            _currentColorTimer += Time.deltaTime;

            if (_currentColorTimer > _colorChangeTime)
            {
                _currentColorTimer = 0f;
                _isActive = false;
                _spriteRender.color = _originalColor;
            }
        }
    }

}
