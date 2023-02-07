using UnityEngine;
using TMPro;
using GalaxyOfCircles.Events;

namespace GalaxyOfCircles.UI
{
    [RequireComponent(typeof(TMP_InputField))]
    public class UIInputEventRaiser : MonoBehaviour
    {
        [SerializeField] private IntEventChannelSO _eventChangeAmountCircles;
        [SerializeField] private VoidEventChannelSO _eventWrongValue;
        private TMP_InputField _inputField;
        private int _amountCircles;

        private void Awake()
        {
            _inputField = GetComponent<TMP_InputField>();
        }

        private void Start()
        {
            _inputField.onValueChanged.AddListener(Edit);
            _inputField.onEndEdit.AddListener(CheckValue);
        }

        public void Edit(string value)
        {
            if (int.TryParse(value, out _amountCircles))
            {
                _eventChangeAmountCircles.RaiseEvent(_amountCircles);
            }
        }

        public void CheckValue(string value)
        {
            if (_amountCircles <= 0 || _amountCircles > 100)
                _eventWrongValue.RaiseEvent();    
        }
    }
}

