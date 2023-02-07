using UnityEngine;
using UnityEngine.SceneManagement;
using GalaxyOfCircles.Events;

namespace GalaxyOfCircles.Core
{
    public class MatchRestarter : MonoBehaviour
    {
        [SerializeField] private VoidEventChannelSO _eventReset;

        void Start()
        {
            _eventReset.OnEventRaised += Restart;
        }

        void Restart()
        {
            Debug.Log("Restarting");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}

