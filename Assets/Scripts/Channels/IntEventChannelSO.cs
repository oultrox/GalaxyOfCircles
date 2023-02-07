using UnityEngine;
using UnityEngine.Events;

namespace GalaxyOfCircles.Events
{
    [CreateAssetMenu(menuName = "Events/Int Event Channel")]
    public class IntEventChannelSO : ScriptableObject
    {
        public UnityAction<int> OnEventRaised;

        public void RaiseEvent(int value)
        {
            if (OnEventRaised == null)
            {
                return;
            }
            OnEventRaised.Invoke(value);
        }
    }
}

