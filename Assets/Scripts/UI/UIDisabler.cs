using UnityEngine;
using GalaxyOfCircles.Events;

namespace GalaxyOfCircles.UI
{
    public class UIDisabler : MonoBehaviour
    {
        [Header("Channel Events Reference")]
        [SerializeField] private VoidEventChannelSO _eventDisabler;
        
        private void Start()
        {
            _eventDisabler.OnEventRaised += Hide;
        }

        private void OnDestroy()
        {
            _eventDisabler.OnEventRaised -= Hide;
        }

        private void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}

