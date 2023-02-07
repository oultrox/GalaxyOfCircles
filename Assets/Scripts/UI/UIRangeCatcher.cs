using GalaxyOfCircles.Events;
using System.Collections;
using UnityEngine;

namespace GalaxyOfCircles.UI
{
    public class UIRangeCatcher : MonoBehaviour
    {
        [Header("Reference")]
        [SerializeField] private GameObject _catchError;
        [SerializeField] private float _amountOfSecondsShown = 1.3f;

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
            _catchError.SetActive(true);
            yield return new WaitForSeconds(_amountOfSecondsShown);
            _catchError.SetActive(false);
        }
    }

}
