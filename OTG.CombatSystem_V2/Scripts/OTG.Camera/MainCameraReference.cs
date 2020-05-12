
using UnityEngine;


namespace OTG.Cameras
{
    public class MainCameraReference : MonoBehaviour
    {
        private static MainCameraReference m_instance;
        private Transform m_trans;
        private Camera m_mainCamera;
        public static Transform TransformComponent { get { return m_instance.m_trans; } }
        public static Camera MainCamera { get { return m_instance.m_mainCamera; } }

        private void OnEnable()
        {
            m_instance = this;
            m_trans = GetComponent<Transform>();
            m_mainCamera = GetComponent<Camera>();
        }

        private void OnDisable()
        {
            m_trans = null;
            m_instance = null;
            m_mainCamera = null;
        }
    }

}

