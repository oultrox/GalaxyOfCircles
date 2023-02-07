using UnityEngine;

namespace GalaxyOfCircles.Core
{
    public class ObjectSpawner : MonoBehaviour
    {
        [Header("Reference")]
        [Space(6)]
        [SerializeField] private GameObject _objectPrefab;
        
        [Header("Spawn Limits")]
        [Space(6)]
        [SerializeField] private Transform _xPositionMin;
        [SerializeField] private Transform _xPositionMax;
        [SerializeField] private Transform _yPositionMin;
        [SerializeField] private Transform _yPositionMax;
        
        private Vector3 randomPosition;

        // You know what this does.  :P
        public void SpawnObjectAmount(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                randomPosition.x = (Random.Range(_xPositionMin.position.x, _xPositionMax.position.x));
                randomPosition.y = (Random.Range(_yPositionMin.position.y, _yPositionMax.position.y));
                randomPosition.z = 0;
                Instantiate(_objectPrefab, randomPosition, Quaternion.identity, transform);
            }
        }
    }
}

