#pragma warning disable CS0649

using UnityEngine;
using OTG.Common;

namespace OTG.CombatStateMachine
{
    [CreateAssetMenu(menuName = StringUtilities.CombatAnimationPath)]
    public class CombatAnimation : ScriptableObject
    {
        [SerializeField] private AnimationClip m_clip;
        public AnimationClip Clip { get { return m_clip; } }

        [SerializeField] private S_CombatAnimationData m_data;
        public S_CombatAnimationData Data { get { return m_data; } }
    }
    [System.Serializable]
    public struct S_CombatAnimationData
    {
        [SerializeField] private Vector3 m_rootMotionMultiplier;
        public Vector3 RootMotionMultiplier { get { return m_rootMotionMultiplier; } }

    }
}
