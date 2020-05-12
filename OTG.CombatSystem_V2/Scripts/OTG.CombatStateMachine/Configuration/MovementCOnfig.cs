#pragma warning disable CS0649

using UnityEngine;
using OTG.Common;

namespace OTG.CombatStateMachine
{
    [CreateAssetMenu(menuName =StringUtilities.ConfigurationPathRoot+"MovementConfig")]
    public class MovementCOnfig : ScriptableObject
    {
        [SerializeField] private float m_moveSpeed;
        public float MoveSpeed { get { return m_moveSpeed; } }
        [SerializeField]private float m_rotationSpeed;
        public float RotationSpeed { get { return m_rotationSpeed; } }
    }

}
