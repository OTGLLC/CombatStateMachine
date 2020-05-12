
using UnityEngine;
using OTG.Common;

namespace OTG.EventSystem
{
    [CreateAssetMenu(fileName = "BroadcastTransformEvent", menuName =StringUtilities.OTGEventPathRoot+ "BroadcastTransformEvent")]
    public class BroadcastTransformEvent : OTGEvent<Transform>
    {
        public override void Raise(Transform t)
        {
            for (int i = m_listeners.Count - 1; i >= 0; i--)
            {
                m_listeners[i].OnEventRaised(t);
            }
        }
    }

}
