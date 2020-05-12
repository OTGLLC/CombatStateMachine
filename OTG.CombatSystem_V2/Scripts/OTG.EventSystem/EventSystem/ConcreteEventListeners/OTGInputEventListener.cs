#pragma warning disable CS0649


using UnityEngine;
using UnityEngine.Events;

namespace OTG.EventSystem
{
    public class OTGInputEventListener : OTGEventListener<EventData_OTGInput>
    {
        [SerializeField] private OTGInputEvent m_otgEvent;
        [SerializeField] private OTGInputUnityEvent m_unityEvent;

        public override void OnEventRaised(EventData_OTGInput t)
        {
            m_unityEvent.Invoke(t);
        }

        protected override void OnDisable()
        {
            m_otgEvent.RemoveListener(this);
        }

        protected override void OnEnable()
        {
            m_otgEvent.AddListener(this);
        }
    }
    [System.Serializable]
    public class OTGInputUnityEvent : UnityEvent<EventData_OTGInput> { }

}
