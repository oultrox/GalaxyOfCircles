using UnityEngine;
using GalaxyOfCircles.Events;

public class Disabler : MonoBehaviour
{
    [SerializeField] private VoidEventChannelSO _eventStartGame;

    void Start()
    {
        _eventStartGame.OnEventRaised += Hide;
    }
    private void OnEnable()
    {
        _eventStartGame.OnEventRaised -= Hide;
    }

    private void OnDisable()
    {
        _eventStartGame.OnEventRaised -= Hide;
    }

    private void OnDestroy()
    {
        _eventStartGame.OnEventRaised -= Hide;
    }

    void Hide()
    {
        if (gameObject != null)
        {
            gameObject.SetActive(false);
        }
    }
}
