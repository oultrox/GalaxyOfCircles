
using UnityEngine;
using GalaxyOfCircles.Events;

namespace GalaxyOfCircles.Core
{
    public class ObjectSpawner : MonoBehaviour
    {
        [Header("Reference")]
        [SerializeField] private GameObject _objectPrefab;
        [SerializeField] private IntEventChannelSO _eventChangeAmountCircles;
        [SerializeField] private VoidEventChannelSO _eventStartGame;
        
        [Header("Spawn Limits")]
        [SerializeField] private Transform _xPositionMin;
        [SerializeField] private Transform _xPositionMax;
        [SerializeField] private Transform _yPositionMin;
        [SerializeField] private Transform _yPositionMax;
        
        private int _amountCircles = 10;
        
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
                float xRange = _xPositionMax.position.x - _xPositionMin.position.x;
                float yRange = _yPositionMax.position.y - _yPositionMin.position.y;
                Vector3 randomPosition = new Vector3(Random.Range(_xPositionMin.position.x, _xPositionMax.position.x), Random.Range(_yPositionMin.position.y, _yPositionMax.position.y), 0);
                Instantiate(_objectPrefab, randomPosition, Quaternion.identity, transform);
            }
        }
    }
}

