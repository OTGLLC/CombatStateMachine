#pragma warning disable CS0649

using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using OTG.EventSystem;


namespace OTG.Input
{
    public class OTGInputHandler : MonoBehaviour
    {
        #region Inspector Fields
        [SerializeField] private OTGInputEvent m_inputEvent; 
        #endregion

        #region constants
        private const float k_inputWitTime = 0.2f;
       
        #endregion

        #region Fields
        private Vector2 m_moveVector;
        private Vector2 m_lookVector;
        
        private WaitForSeconds m_inputDelayWaitForSeconds;
        private Coroutine m_westFaceButtonCoroutine;
        private Coroutine m_northFaceButtonCoroutine;
        private Coroutine m_eastFaceButtonCoroutine;
        private Coroutine m_southFaceButtonCoroutine;
        private Coroutine m_leftShoulderButtonCoroutine;
        private Coroutine m_rightShoulderButtonCoroutine;
        private Coroutine m_leftStickClickCoroutine;
        private Coroutine m_rightStickClickCoroutine;

        private EventData_OTGInput m_inputEventData;
        #endregion

        #region Components
        public Vector2 MoveVector { get { return m_moveVector; } }
        public Vector2 LookVector { get { return m_lookVector; } }
        public bool HasWestFaceButtonInput { get; private set; }
        public bool HasNorthFaceButtonInput { get; private set; }
        public bool HasEastFaceButtonInput { get; private set; }
        public bool HasSouthFaceButtonInput { get; private set; }
        public bool HasLeftShoulderButtonInput { get; private set; }
        public bool HasRightShoulderButtonInput { get; private set; }
        public bool HasLeftStickClickInput { get; private set; }
        public bool HasRightStickClickInput { get; private set; }
        
        #endregion

        #region Unity API
        void OnEnable()
        {
            StopAllCoroutines();
            m_inputEventData = new EventData_OTGInput();
            m_inputDelayWaitForSeconds = new WaitForSeconds(k_inputWitTime);
        }
        void OnDisable()
        {
            StopAllCoroutines();
            m_inputEventData = null;
        }
        private void Update()
        {
            SetInputEventParams();
            m_inputEvent.Raise(m_inputEventData);
        }
        #endregion

        #region Public API

        public void OnMove(InputAction.CallbackContext ctx)
        {
            GetVectorFromCtx(ctx, ref m_moveVector);
        }
        public void OnLook(InputAction.CallbackContext ctx)
        {
            GetVectorFromCtx(ctx, ref m_lookVector);
        }
        public void OnWestButtonClick(InputAction.CallbackContext ctx)
        {
            m_westFaceButtonCoroutine = StartCorrectActionCoroutine(m_westFaceButtonCoroutine, WestButtonCountdown_CO(), ctx);
        }
        public void OnNorthButtonClick(InputAction.CallbackContext ctx)
        {
            m_northFaceButtonCoroutine = StartCorrectActionCoroutine(m_northFaceButtonCoroutine, NorthButtonCountdown_CO(), ctx);
        }
        public void OnEastButtonClick(InputAction.CallbackContext ctx)
        {
            m_eastFaceButtonCoroutine = StartCorrectActionCoroutine(m_eastFaceButtonCoroutine, EastButtonCountdown_CO(), ctx);
        }
        public void OnSouthButtonClick(InputAction.CallbackContext ctx)
        {
            m_southFaceButtonCoroutine = StartCorrectActionCoroutine(m_southFaceButtonCoroutine, SouthButtonCountdown_CO(), ctx);
        }
        public void OnLeftStickClick(InputAction.CallbackContext ctx)
        {
            m_leftStickClickCoroutine = StartCorrectActionCoroutine(m_leftStickClickCoroutine, LeftStickClickCountdown_CO(), ctx);
        }
        public void OnRightStckClick(InputAction.CallbackContext ctx)
        {
            m_rightStickClickCoroutine = StartCorrectActionCoroutine(m_rightStickClickCoroutine, RightStickClickCountdown_CO(), ctx);
        }
        public void OnLeftShoulderButtonClick(InputAction.CallbackContext ctx)
        {
            m_leftShoulderButtonCoroutine = StartCorrectActionCoroutine(m_leftShoulderButtonCoroutine, LeftShoulderButtonCountdown_CO(), ctx);
        }
        public void OnRightShoulderButtonClick(InputAction.CallbackContext ctx)
        {
            m_rightShoulderButtonCoroutine = StartCorrectActionCoroutine(m_rightShoulderButtonCoroutine, RightShoulderButtonCountdown_CO(), ctx);
        }
        #endregion

        #region Utility
        private void GetVectorFromCtx(InputAction.CallbackContext ctx, ref Vector2 _targetVector)
        {
            _targetVector = ctx.ReadValue<Vector2>();
            switch (ctx.phase)
            {
                case InputActionPhase.Canceled:
                case InputActionPhase.Disabled:
                case InputActionPhase.Waiting:
                    _targetVector = Vector2.zero;
                    break;
            }
        }
        private Coroutine StartCorrectActionCoroutine(Coroutine _targetCoroutine, IEnumerator _routineToStart, InputAction.CallbackContext ctx)
        {
            Coroutine retVal = null;
            if (ctx.phase != InputActionPhase.Performed)
                return null;

            if (_targetCoroutine != null)
                StopCoroutine(_routineToStart);

            retVal = StartCoroutine(_routineToStart);

            return retVal;
        }
        private void SetInputEventParams()
        {
            m_inputEventData.SetEastButton(HasEastFaceButtonInput);
            m_inputEventData.SetWestButton(HasWestFaceButtonInput);
            m_inputEventData.SetNorthButton(HasNorthFaceButtonInput);
            m_inputEventData.SetSouthButton(HasSouthFaceButtonInput);
            m_inputEventData.SetLeftShoulderButton(HasLeftShoulderButtonInput);
            m_inputEventData.SetRightShoulderButton(HasRightShoulderButtonInput);
            m_inputEventData.SetRightStickClickButton(HasRightStickClickInput);
            m_inputEventData.SetLeftStickClickButton(HasLeftStickClickInput);
            m_inputEventData.SetMoveVector(MoveVector);
            m_inputEventData.SetLookVector(LookVector);
        }
        #endregion

        #region Coroutine
        private IEnumerator WestButtonCountdown_CO()
        {
            HasWestFaceButtonInput = true;
            yield return m_inputDelayWaitForSeconds;
            HasWestFaceButtonInput = false;
        }
        private IEnumerator NorthButtonCountdown_CO()
        {
            HasNorthFaceButtonInput= true;
            yield return m_inputDelayWaitForSeconds;
            HasNorthFaceButtonInput = false;
        }
        private IEnumerator EastButtonCountdown_CO()
        {
            HasEastFaceButtonInput = true;
            yield return m_inputDelayWaitForSeconds;
            HasEastFaceButtonInput = false;
        }
        private IEnumerator SouthButtonCountdown_CO()
        {
            HasSouthFaceButtonInput = true;
            yield return m_inputDelayWaitForSeconds;
            HasSouthFaceButtonInput = false;
        }
        private IEnumerator LeftStickClickCountdown_CO()
        {
            HasLeftStickClickInput = true;
            yield return m_inputDelayWaitForSeconds;
            HasLeftStickClickInput = false;
        }
        private IEnumerator RightStickClickCountdown_CO()
        {
            HasRightStickClickInput = true;
            yield return m_inputDelayWaitForSeconds;
            HasRightStickClickInput = false;
        }
        private IEnumerator LeftShoulderButtonCountdown_CO()
        {
            HasLeftShoulderButtonInput = true;
            yield return m_inputDelayWaitForSeconds;
            HasLeftShoulderButtonInput = false;
        }
        private IEnumerator RightShoulderButtonCountdown_CO()
        {
            HasRightShoulderButtonInput = true;
            yield return m_inputDelayWaitForSeconds;
            HasRightShoulderButtonInput = false;
        }
        #endregion
    }

}
