using UnityEngine;
using TMPro;
using GalaxyOfCircles.Events;

namespace GalaxyOfCircles.UI
{
    [RequireComponent(typeof(TMP_InputField))]
    public class UIInputEventRaiser : MonoBehaviour
    {
        [Header("Channel Events Reference")]
        [SerializeField] private IntEventChannelSO _eventChangeAmountCircles;
        [SerializeField] private VoidEventChannelSO _eventWrongValue;
        
        private TMP_InputField _inputField;
        private int _amountCircles;
        private bool _isAmountParsed = false;

        private void Awake()
        {
            _inputField = GetComponent<TMP_InputField>();
        }

        // Subscribing to events from inputfield so we can grab the num of circles comfortably.
        private void Start()
        {
            _inputField.onValueChanged.AddListener(Edit);
            _inputField.onEndEdit.AddListener(CheckValue);
        }

        public void Edit(string value)
        {
            if (int.TryParse(value, out _amountCircles))
            {
                _isAmountParsed = true;
                _eventChangeAmountCircles.RaiseEvent(_amountCircles);
            }
            else
            {
                _isAmountParsed = false;
            }
        }

        // If the value is not withing range we raise the error wrong value event.
        public void CheckValue(string value)
        {
            if ((_amountCircles <= 0 || _amountCircles > 100) &&  _isAmountParsed)
                _eventWrongValue.RaiseEvent();    
        }
    }
}

