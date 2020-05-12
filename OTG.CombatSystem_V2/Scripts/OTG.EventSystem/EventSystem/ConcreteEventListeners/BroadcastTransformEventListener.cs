#pragma warning disable CS0649

using UnityEngine;
using UnityEngine.Events;

namespace OTG.EventSystem
{
    public class BroadcastTransformEventListener : OTGEventListener<Transform>
    {

        [SerializeField] private BroadcastTransformEvent m_otgEvent;
        [SerializeField] private BroadcastTransformUnityEvent m_unityEvent;

        public override void OnEventRaised(Transform t)
        {
            m_unityEvent.Invoke(t);
        }
        protected override void OnEnable()
        {
            m_otgEvent.AddListener(this);
        }
        protected override void OnDisable()
        {
            m_otgEvent.RemoveListener(this);
        }
    }
    [System.Serializable]
    public class BroadcastTransformUnityEvent : UnityEvent<Transform> { }

}
