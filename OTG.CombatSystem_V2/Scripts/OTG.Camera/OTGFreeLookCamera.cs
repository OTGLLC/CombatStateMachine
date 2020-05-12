using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;
using OTG.EventSystem;

namespace OTG.Cameras
{
    public class OTGFreeLookCamera : MonoBehaviour
    {

        private CinemachineFreeLook m_freelook;

        private void OnEnable()
        {
            m_freelook = GetComponent<CinemachineFreeLook>();
        }

        private void OnDisable()
        {
            m_freelook = null;
        }

        public void OnLook(InputAction.CallbackContext ctx)
        {
            if (m_freelook == null)
                return;

            m_freelook.m_XAxis.m_InputAxisValue = ctx.ReadValue<Vector2>().x;
            m_freelook.m_YAxis.m_InputAxisValue = ctx.ReadValue<Vector2>().y;
        }
    }
}

