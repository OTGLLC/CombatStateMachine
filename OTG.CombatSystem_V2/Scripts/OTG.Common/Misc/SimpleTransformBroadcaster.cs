#pragma warning disable CS0649

using UnityEngine;
using OTG.EventSystem;

namespace OTG.Common
{
    public class SimpleTransformBroadcaster : MonoBehaviour
    {
        [SerializeField] private BroadcastTransformEvent m_event;
        private Transform m_trans;

        private void OnEnable()
        {
            m_trans = GetComponent<Transform>();
        }
        private void OnDisable()
        {
            m_trans = null;
        }
        private void Update()
        {
            m_event.Raise(m_trans);
        }

    }

}
