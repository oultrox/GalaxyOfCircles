using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GalaxyOfCircles.Entities
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(SpriteRenderer))]
    public class Propeller : MonoBehaviour
    {
        [SerializeField] private float _movementSpeed;

        private SpriteRenderer _spriteRender;
        private Rigidbody2D _rBody;
        private Vector2 _moveDirection;
        private Vector2 _reflectDirection;
        private Color _originalColor;
        private Color _randomColor;
        private float _randomAngle;
        private float _angleMotion = 45f;
        private float _r, _g, _b;
        private const float CHANGE_COLOR_TIMER = 0.5f;
        private ContactPoint2D _contact;

        private void Awake()
        {
            _spriteRender = GetComponent<SpriteRenderer>();
            _rBody = GetComponent<Rigidbody2D>();
        }

        private void Start()
        {
            _originalColor = _spriteRender.color;
            _angleMotion = Random.Range(-360, 360);
            _moveDirection.x = Mathf.Cos(Mathf.Deg2Rad * _angleMotion);
            _moveDirection.y = Mathf.Sin(Mathf.Deg2Rad * _angleMotion);
        }

        private void FixedUpdate()
        {
            _rBody.velocity = _moveDirection * _movementSpeed * Time.deltaTime;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            _contact = collision.GetContact(0);
            _reflectDirection = Vector2.Reflect(_moveDirection, _contact.normal);
            _randomAngle = Random.Range(-0.2f, 0.2f);
            _reflectDirection.x += _randomAngle;
            _reflectDirection.y += _randomAngle;
            _moveDirection = _reflectDirection.normalized;

            StopCoroutine(ChangeColor());
            StartCoroutine(ChangeColor());
        }

        private IEnumerator ChangeColor()
        {
            _r = Random.Range(0f, 1f);
            _g = Random.Range(0f, 1f);
            _b = Random.Range(0f, 1f);
            _randomColor = new Color(_r, _g, _b);
            _spriteRender.color = _randomColor;

            yield return new WaitForSeconds(CHANGE_COLOR_TIMER);
            _spriteRender.color = _originalColor;
        }
    }
}


