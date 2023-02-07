using GalaxyOfCircles.Events;
using System.Collections;
using UnityEngine;

namespace GalaxyOfCircles.UI
{
    public class UIRangeCatcher : MonoBehaviour
    {
        [Header("Reference")]
        [SerializeField] private GameObject[] _catchErrorTexts;
        [SerializeField] private float _amountOfSecondsShown = 1.5f;

        [Header("Channel Events Reference")]
        [SerializeField] private VoidEventChannelSO _eventWrongValue;

        private void Start()
        {
            _eventWrongValue.OnEventRaised += ShowError;
        }

        private void OnDestroy()
        {
            _eventWrongValue.OnEventRaised -= ShowError;
        }

        private void ShowError()
        {
            StopAllCoroutines();
            StartCoroutine(DisplayTextError());
        }

        private IEnumerator DisplayTextError()
        {
            SetGameObjectsActive(true);
            yield return new WaitForSeconds(_amountOfSecondsShown);
            SetGameObjectsActive(false);
        }

        private void SetGameObjectsActive(bool isActive)
        {
            for (int i = 0; i < _catchErrorTexts.Length; i++)
            {
                _catchErrorTexts[i].SetActive(isActive);
            }
        }
    }

}
