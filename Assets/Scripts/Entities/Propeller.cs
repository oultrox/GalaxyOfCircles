using GalaxyOfCircles.Flavour;
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
        private GraphicBouncer _graphicBouncer;

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
            _graphicBouncer = GetComponent<GraphicBouncer>();
        }

        private void Start()
        {
            // Set a random angle start
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
            // Bounce off using Reflect function with a little bit of randomization offset.
            _contact = collision.GetContact(0);
            _reflectDirection = Vector2.Reflect(_moveDirection, _contact.normal);
            _moveDirection = RandomizeDirectionOffset(-0.2f,0.2f);
            
            ChangeColor();

            // Flavour stuff
            ActivateParticles();
            ActivateGraphicBounce();
        }

        private Vector2 RandomizeDirectionOffset(float minRange, float maxRange)
        {
            _randomAngle = Random.Range(minRange, maxRange);
            _reflectDirection.x += _randomAngle;
            _reflectDirection.y += _randomAngle;
            return _reflectDirection.normalized;
        }

        private void ActivateGraphicBounce()
        {
            if (_graphicBouncer != null)
                _graphicBouncer.LerpSize();
        }

        private void ActivateParticles()
        {
            if (_particleActivator != null)
                _particleActivator.ActivateParticle();
        }

        private void ChangeColor()
        {
            
            if (_colorChanger != null)
                _colorChanger.ChangeRandomColor();
        }
    }
}


