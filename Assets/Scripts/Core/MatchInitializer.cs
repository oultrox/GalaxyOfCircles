using GalaxyOfCircles.Events;
using UnityEngine;

namespace GalaxyOfCircles.Core
{
    [RequireComponent(typeof(ObjectSpawner))]
    public class MatchInitializer : MonoBehaviour
    {
        [SerializeField] private VoidEventChannelSO _eventStartGame;
        [SerializeField] private IntEventChannelSO _eventChangeAmountCircles;
        
        private ObjectSpawner _spawner;
        private int _amountCircles;

        private void Awake()
        {
            _spawner = GetComponent<ObjectSpawner>();
        }

        private void Start()
        {
            _eventChangeAmountCircles.OnEventRaised += SetAmountCircles;
            _eventStartGame.OnEventRaised += InitMatch;
        }

        private void OnDestroy()
        {
            _eventStartGame.OnEventRaised -= InitMatch;
        }

        private void SetAmountCircles(int amount)
        {
            _amountCircles = amount;
        }

        private void InitMatch()
        {
            _spawner.SpawnObjectAmount(_amountCircles);
        }
    }
}

