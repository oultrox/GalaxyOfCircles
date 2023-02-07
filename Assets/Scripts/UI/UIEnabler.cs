using GalaxyOfCircles.Events;
using System.Collections;
using UnityEngine;

namespace GalaxyOfCircles.UI
{
    // Enables all Children GameObjects when subscribed event is invoked.
    public class UIEnabler : MonoBehaviour
    {
        [Header("Channel Events Reference")]
        [SerializeField] private VoidEventChannelSO _eventEnabler;
        private Transform[] _gameObjects;


        private void Awake()
        {
            _gameObjects = GetComponentsInChildren<Transform>(includeInactive: true);
        }

        private void Start()
        {
            _eventEnabler.OnEventRaised += EnableObjects;
        }

        private void OnDestroy()
        {
            _eventEnabler.OnEventRaised -= EnableObjects;
        }

        private void EnableObjects()
        {
            if (_gameObjects.Length == 1)
                return;         
            
            for (int i = 1; i < _gameObjects.Length; i++)
            {
                _gameObjects[i].gameObject.SetActive(true);
            }
        }
    }
}