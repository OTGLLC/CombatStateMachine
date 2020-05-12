#pragma warning disable CS0649

using UnityEngine;
using OTG.Common;

namespace OTG.CombatStateMachine
{
    [CreateAssetMenu(menuName =StringUtilities.AnimationEventContainerPath)]
    public class AnimationEventContainer : ScriptableObject
    {
        [SerializeField] private AnimationTimingStatus m_timing;
        public AnimationTimingStatus Timing { get { return m_timing; } }
      
    }
}

