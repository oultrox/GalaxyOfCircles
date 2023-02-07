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

        public void ChangeRandomColor()
        {
            StopAllCoroutines();
            StartCoroutine(ChangeColor());
        }

        private IEnumerator ChangeColor()
        {
            _r = Random.Range(0f, 1f);
            _g = Random.Range(0f, 1f);
            _b = Random.Range(0f, 1f);
            _randomColor.r = _r;
            _randomColor.g = _g;
            _randomColor.b = _b;
            _spriteRender.color = _randomColor;

            yield return new WaitForSeconds(_colorChangeTime);
            _spriteRender.color = _originalColor;
        }
    }

}
