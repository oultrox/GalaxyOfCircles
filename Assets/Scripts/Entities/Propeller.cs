using GalaxyOfCircles.Flavour;
using UnityEngine;

namespace GalaxyOfCircles.Entities
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Propeller : MonoBehaviour
    {
        [SerializeField] private float _movementSpeed;
        [Range(0,0.9f)]
        [SerializeField] private float _randomOffsetBounce = 0.4f;
        private Rigidbody2D _rBody;
        private ColorChanger _colorChanger;
        private ParticleActivator _particleActivator;
        private GraphicBouncer _graphicBouncer;

        private ContactPoint2D _contact;
        private Vector2 _moveDirection;
        private Vector2 _reflectDirection;
        private float _randomAngle;
        private float _angleMotion = 45f;
        private const string WALL_TAG = "Wall";
        private const float MIN_TRESHOLD_MAGNITUDE = 0.9f;

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
            _contact = collision.GetContact(0);
            BounceDirection(_contact);
            ChangeColor();
            BounceSize();
            ActivateParticles();
        }

        // Trying to get them away from wall as much as possible.
        private void OnCollisionStay2D(Collision2D collision)
        {
            if (_rBody.velocity.magnitude > MIN_TRESHOLD_MAGNITUDE || collision.gameObject.CompareTag(WALL_TAG) == false)
                return;

            _contact = collision.GetContact(0);
            BounceDirection(_contact);
        }

        // Bounce off using Reflect function
        private void BounceDirection(ContactPoint2D contact)
        {
            _reflectDirection = Vector2.Reflect(_moveDirection, contact.normal);
            _reflectDirection = RandomizeDirectionOffset(_reflectDirection, -_randomOffsetBounce, _randomOffsetBounce); 
            _moveDirection = _reflectDirection.normalized;
        }

        // With a little bit of randomization offset.
        private Vector2 RandomizeDirectionOffset(Vector2 vector, float minRange, float maxRange)
        {
            _randomAngle = Random.Range(minRange, maxRange);
            vector.x += _randomAngle;
            vector.y += _randomAngle;
            return vector;
        }

        // Flavour effects
        private void ChangeColor()
        {
            if (_colorChanger == null)
                return;

            _colorChanger.ChangeRandomColor();
        }

        private void BounceSize()
        {
            if (_graphicBouncer == null)
                return;

            _graphicBouncer.BounceSize();
        }

        private void ActivateParticles()
        {
            if (_particleActivator == null)
                return;

            _particleActivator.ActivateParticle();
        }

    }
}


