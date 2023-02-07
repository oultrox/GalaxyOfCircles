using UnityEngine;
using UnityEngine.SceneManagement;
using GalaxyOfCircles.Events;

namespace GalaxyOfCircles.Core
{
    public class MatchRestarter : MonoBehaviour
    {
        [Header("Channel Events Reference")]
        [SerializeField] private VoidEventChannelSO _eventReset;

        private void Start()
        {
            _eventReset.OnEventRaised += Restart;
        }

        private void Restart()
        {
            Debug.Log("Restarting");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}

