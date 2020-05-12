
using UnityEngine;
using System.Collections;

namespace OTG.CombatStateMachine
{
    public class MovementHandler
    {
        public MovementCOnfig MoveConfig { get; private set; }
        public Transform TransformComp { get; private set; }
        public Rigidbody RigidbodyComp { get; private set; }
        public CharacterController CharacterControlComp { get; private set; }
        public Vector3 SmoothHeadind { get; set; }

        #region Public API
        public void InitializeComponents(GameObject _owner, MovementCOnfig _moveConfig)
        {
            InitializeReferences(_owner,_moveConfig);

        }
        public void CleanupComponents()
        {
            Cleanup();
        }


        #endregion

        #region Utility
        private void InitializeReferences(GameObject _owner, MovementCOnfig _moveConfig)
        {
            TransformComp = _owner.GetComponent<Transform>();
            RigidbodyComp = _owner.GetComponent<Rigidbody>();
            CharacterControlComp = _owner.GetComponent<CharacterController>();
            MoveConfig = _moveConfig;
        }
        private void Cleanup()
        {
            TransformComp = null;
            RigidbodyComp = null;
            CharacterControlComp = null;
        }
        #endregion
    }

}
