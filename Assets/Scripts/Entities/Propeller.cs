using UnityEngine;

namespace GalaxyOfCircles.Entities
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Propeller : MonoBehaviour
    {
        [SerializeField] private float _movementSpeed;
        private Rigidbody2D _rBody;
        private ColorChanger _colorChanger;
        private ParticleActivator _particleActivator;

        private ContactPoint2D _contact;
        private Vector2 _moveDirection;
        private Vector2 _reflectDirection;
        private float _randomAngle;
        private float _angleMotion = 45f;
       

        private void Awake()
        {
            _rBody = GetComponent<Rigidbody2D>();
            _colorChanger = GetComponent<ColorChanger>();
            _particleActivator = GetComponent<ParticleActivator>();
        }

        private void Start()
        {
            _angleMotion = Random.Range(-360, 360);
            _moveDirection.x = Mathf.Cos(Mathf.Deg2Rad * _angleMotion);
            _moveDirection.y = Mathf.Sin(Mathf.Deg2Rad * _angleMotion);
        }

        private void FixedUpdate()
        {
            _rBody.velocity = _movementSpeed * Time.deltaTime * _moveDirection;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            _contact = collision.GetContact(0);
            _reflectDirection = Vector2.Reflect(_moveDirection, _contact.normal);
            _randomAngle = Random.Range(-0.2f, 0.2f);
            
            _reflectDirection.x += _randomAngle;
            _reflectDirection.y += _randomAngle;
            _moveDirection = _reflectDirection.normalized;
            
            if(_colorChanger != null)
                _colorChanger.ChangeRandomColor();
            
            if (_particleActivator != null)
                _particleActivator.ActivateParticle();
        }

    }
}


