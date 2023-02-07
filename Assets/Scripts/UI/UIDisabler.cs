using UnityEngine;
using GalaxyOfCircles.Events;

namespace GalaxyOfCircles.UI
{
    public class UIDisabler : MonoBehaviour
    {
        [SerializeField] private VoidEventChannelSO _eventDisabler;

        void Start()
        {
            _eventDisabler.OnEventRaised += Hide;
        }
        private void OnEnable()
        {
            _eventDisabler.OnEventRaised -= Hide;
        }

        private void OnDisable()
        {
            _eventDisabler.OnEventRaised -= Hide;
        }

        private void OnDestroy()
        {
            _eventDisabler.OnEventRaised -= Hide;
        }

        void Hide()
        {
            if (gameObject != null)
            {
                gameObject.SetActive(false);
            }
        }
    }
}

