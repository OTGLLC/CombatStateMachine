#pragma warning disable CS0649

using UnityEngine;
using System.Collections;


namespace OTG.CombatStateMachine
{
    [System.Serializable]
    public class CombatStateTransition
    {
        [SerializeField]
        private TransitionDecision[] m_decisions;

        [SerializeField]
        private CombatState m_nextState;
        public CombatState StateToTransitionTo { get { return m_nextState; } }

        public void MakeDecision(CombatStateMachineController _controller)
        {
            int decisionCount = m_decisions.Length;

            for(int i = 0; i < decisionCount; i++)
            {
                if (!m_decisions[i].Decide(_controller))
                    return;
            }
            _controller.ChangeState(m_nextState);
        }
    }

}
