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
            if (int.TryParse(value, out int inputValue))
            {
                _eventChangeAmountCircles.RaiseEvent(inputValue);
            }
        }

        public void CheckValue(string value)
        {
            if (int.TryParse(value, out int inputValue))
            {
                if (inputValue <= 0 || inputValue > 100)
                    _eventWrongValue.RaiseEvent();    
            }
        }
    }
}

