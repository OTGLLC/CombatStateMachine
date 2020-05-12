#pragma warning disable CS0649

using UnityEngine;

namespace OTG.CombatStateMachine
{
    public class CombatStateMachineController : MonoBehaviour
    {
        #region Inspector Fields
        [SerializeField] private MovementCOnfig m_moveConfig;
        [SerializeField] private CombatState m_startState;
        #endregion

        #region Handler Classes
        public AnimationHandler AnimHandler { get; private set; }
        public MovementHandler MoveHandler { get; private set; }
        public InputHandler PlayerInputHandler { get; private set; }
        #endregion

        #region Fields
        private CombatState m_currentState;
        #endregion

        #region Unity API

        private void OnEnable()
        {
            SetComponentReferences();
        }

        private void OnDisable()
        {
            CleanupComponents();
        }
        private void Start()
        {
            m_currentState = m_startState;
            m_currentState.OnStateEnter(this);
        }
        private void Update()
        {
            m_currentState.OnUpdateState(this);
        }
        private void FixedUpdate()
        {
            m_currentState.OnFixedUpdateState(this);
        }
        private void OnAnimatorMove()
        {
            m_currentState.OnAnimaterMoveState(this);
        }
        #endregion

        #region Utility
        private void SetComponentReferences()
        {
            AnimHandler = new AnimationHandler();
            AnimHandler.InitializeAnimHandler(this.gameObject);

            MoveHandler = new MovementHandler();
            MoveHandler.InitializeComponents(this.gameObject,m_moveConfig);

            PlayerInputHandler = new InputHandler();
            PlayerInputHandler.InitializeHandler();
        }
        private void CleanupComponents()
        {
            AnimHandler.CleanupAnimHandler();
            MoveHandler.CleanupComponents();
            PlayerInputHandler.CleanupHandler();
        }
        #endregion

        #region Public API
        public void ChangeState(CombatState _newState)
        {
            m_currentState.OnStateExit(this);
            _newState.OnStateEnter(this);
            m_currentState = _newState;
        }
        #endregion

        #region Event Hooks
        public void UpdateAnimationEventContainer(AnimationEventContainer _container)
        {
            AnimHandler.SetAnimationEvent(_container);
        }
        public void OnInputRecieved(OTG.EventSystem.EventData_OTGInput _inputData)
        {
            if (PlayerInputHandler == null)
                return;
            PlayerInputHandler.OnInputRecieved(_inputData);
        }
        #endregion
    }

}
