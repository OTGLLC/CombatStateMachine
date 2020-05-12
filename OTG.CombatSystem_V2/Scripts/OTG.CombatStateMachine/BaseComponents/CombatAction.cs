using UnityEngine;
using System.Collections;

namespace OTG.CombatStateMachine
{
    public abstract class CombatAction : ScriptableObject
    {
        public abstract void Act(CombatStateMachineController _controller);
    }

}
