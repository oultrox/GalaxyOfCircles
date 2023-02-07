using UnityEngine;
using UnityEngine.Events;

namespace GalaxyOfCircles.Events
{
    [CreateAssetMenu(menuName = "Events/Void Event Channel")]
    public class VoidEventChannelSO : ScriptableObject
    {
        public UnityAction OnEventRaised;

        public void RaiseEvent()
        {
            if (OnEventRaised == null)
            {
                return;
            }
            OnEventRaised.Invoke();
        }
    }
}
