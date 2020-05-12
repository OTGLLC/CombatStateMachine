#pragma warning disable CS0649

using UnityEngine;
using OTG.Common;

namespace OTG.CombatStateMachine
{
    [CreateAssetMenu(menuName =StringUtilities.CombatStatePath)]
    public class CombatState : ScriptableObject
    {
        #region CombatActions
        [SerializeField] private CombatAnimation m_combatAnim;
        [SerializeField] private CombatAction[] m_onEnterActions;
        [SerializeField] private CombatAction[] m_onExitActions;
        [SerializeField] private CombatAction[] m_updateActions;
        [SerializeField] private CombatAction[] m_fixedUpdateActions;
        [SerializeField] private CombatAction[] m_animatorMoveActions;
        [SerializeField] private CombatStateTransition[] m_transitions;
        #endregion

        #region Public API
        public void OnStateEnter(CombatStateMachineController _controller)
        {
           
            PerformActions(m_onEnterActions, _controller);
            PlayAnimation(_controller);
        }
        public void OnStateExit(CombatStateMachineController _controller)
        {
            PerformActions(m_onExitActions, _controller);
        }

        public void OnUpdateState(CombatStateMachineController _controller)
        {
            PerformActions(m_updateActions, _controller);
            EvaluateDecisions(_controller);
        }
        public void OnFixedUpdateState(CombatStateMachineController _controller)
        {
            PerformActions(m_fixedUpdateActions, _controller);
        }
        public void OnAnimaterMoveState(CombatStateMachineController _controller)
        {
            PerformActions(m_animatorMoveActions, _controller);
        }
        #endregion

        #region Utility
        private void PerformActions(CombatAction[] _actions, CombatStateMachineController _controller)
        {
            int actionCount = _actions.Length;
            for(int i = 0; i < actionCount; i++)
            {
                _actions[i].Act(_controller);
            }
        }
        private void PlayAnimation(CombatStateMachineController _controller)
        {
            if (m_combatAnim == null || m_combatAnim.Clip == null)
                return;
            _controller.AnimHandler.PlayAnimation(m_combatAnim.Clip);
        }
        private void EvaluateDecisions(CombatStateMachineController _controller)
        {
            int transitionCount = m_transitions.Length;

            for(int i = 0; i < transitionCount; i++)
            {
                m_transitions[i].MakeDecision(_controller);
            }
        }
        #endregion
    }

}
