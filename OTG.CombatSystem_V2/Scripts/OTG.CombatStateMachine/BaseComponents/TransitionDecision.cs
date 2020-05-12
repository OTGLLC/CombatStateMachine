#pragma warning disable CS0649

using UnityEngine;
using System.Collections;


namespace OTG.CombatStateMachine
{

    public abstract class TransitionDecision : ScriptableObject
    {
        public abstract bool Decide(CombatStateMachineController _controller);
       
    }

}
