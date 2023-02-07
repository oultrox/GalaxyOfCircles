using GalaxyOfCircles.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIRangeCatcher : MonoBehaviour
{

    [SerializeField] private GameObject _catchError;
    [SerializeField] private float _amountOfSecondsShown = 1.3f;
    [SerializeField] private VoidEventChannelSO _eventWrongValue;
    private void Start()
    {
        _eventWrongValue.OnEventRaised += ShowError;
    }

    private void ShowError()
    {
        StartCoroutine(DisplayTextError());
    }
    private IEnumerator DisplayTextError()
    {
        _catchError.SetActive(true);
        yield return new WaitForSeconds(_amountOfSecondsShown);
        _catchError.SetActive(false);
    }
}
