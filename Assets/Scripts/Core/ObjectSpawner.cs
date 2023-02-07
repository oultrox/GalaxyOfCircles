using UnityEngine;
using GalaxyOfCircles.Events;

namespace GalaxyOfCircles.Core
{
    public class ObjectSpawner : MonoBehaviour
    {
        [Header("Reference")]
        [Space(6)]
        [SerializeField] private GameObject _objectPrefab;
        [SerializeField] private IntEventChannelSO _eventChangeAmountCircles;
        [SerializeField] private VoidEventChannelSO _eventStartGame;
        
        [Header("Spawn Limits")]
        [Space(6)]
        [SerializeField] private Transform _xPositionMin;
        [SerializeField] private Transform _xPositionMax;
        [SerializeField] private Transform _yPositionMin;
        [SerializeField] private Transform _yPositionMax;
        
        private int _amountCircles;
        private Vector3 randomPosition;


        private void Start()
        {
            _eventChangeAmountCircles.OnEventRaised += SetAmountCircles;
            _eventStartGame.OnEventRaised += SpawnObject;
        }

        private void OnDestroy()
        {
            _eventStartGame.OnEventRaised -= SpawnObject;
        }

        private void SetAmountCircles(int amount)
        {
            _amountCircles = amount;
        }

        private void SpawnObject()
        {
            for (int i = 0; i < _amountCircles; i++)
            {
                randomPosition.x = (Random.Range(_xPositionMin.position.x, _xPositionMax.position.x));
                randomPosition.y = (Random.Range(_yPositionMin.position.y, _yPositionMax.position.y));
                randomPosition.z = 0;
                Instantiate(_objectPrefab, randomPosition, Quaternion.identity, transform);
            }
        }
    }
}

