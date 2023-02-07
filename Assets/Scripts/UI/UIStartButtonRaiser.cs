using GalaxyOfCircles.Events;
using UnityEngine;
using UnityEngine.UI;

namespace GalaxyOfCircles.UI
{
    [RequireComponent(typeof(Button))]
    public class UIStartButtonRaiser : MonoBehaviour
    {
        [Header("Channel Events Reference")]
        [SerializeField] private IntEventChannelSO _eventChangeAmountCircles;
        [SerializeField] private VoidEventChannelSO _eventGameStart;

        private Button _buttonStart;
        private int _amountCircles;

        private void Awake()
        {
            _buttonStart = GetComponent<Button>();
        }

        void Start()
        {
            _buttonStart.onClick.AddListener(CheckValue);
            _eventChangeAmountCircles.OnEventRaised += SetAmountCircles;
        }

        private void CheckValue()
        {
            if (_amountCircles > 0 && _amountCircles <= 100)
                _eventGameStart.RaiseEvent();
        }

        private void SetAmountCircles(int amount)
        {
            _amountCircles = amount;
        }
    }
}

