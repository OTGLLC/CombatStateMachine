

using UnityEngine;


namespace OTG.CombatStateMachine
{
    public class InputHandler
    {
        public OTG.EventSystem.EventData_OTGInput InputData { get; private set; }


        #region Public API
        public void InitializeHandler()
        {
            
        }
        public void CleanupHandler()
        {
            InputData = null;
        }
        public void OnInputRecieved(OTG.EventSystem.EventData_OTGInput _input)
        {
            InputData = _input;
        }
        #endregion
    }

}
