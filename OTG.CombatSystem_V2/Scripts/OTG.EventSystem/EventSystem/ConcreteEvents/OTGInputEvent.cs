
using UnityEngine;
using OTG.Common;

namespace OTG.EventSystem
{
    [CreateAssetMenu(fileName ="OTGInputEvent", menuName =StringUtilities.OTGEventPathRoot+"OTGInputEvent")]
    public class OTGInputEvent : OTGEvent<EventData_OTGInput>
    {
        public override void Raise(EventData_OTGInput t)
        {
            for (int i = m_listeners.Count - 1; i >= 0; i--)
            {
                m_listeners[i].OnEventRaised(t);
            }
        }
    }

    public class EventData_OTGInput
    {
        public Vector2 MoveVector { get; private set; }
        public Vector2 LookVector { get; private set; }
        public bool HasWestFaceButtonInput { get; private set; }
        public bool HasNorthFaceButtonInput { get; private set; }
        public bool HasEastFaceButtonInput { get; private set; }
        public bool HasSouthFaceButtonInput { get; private set; }
        public bool HasLeftShoulderButtonInput { get; private set; }
        public bool HasRightShoulderButtonInput { get; private set; }
        public bool HasLeftStickClickInput { get; private set; }
        public bool HasRightStickClickInput { get; private set; }

        #region Public API
        public EventData_OTGInput()
        {
            MoveVector = Vector2.zero;
            LookVector = Vector2.zero;
        }
        public void SetMoveVector(Vector2 _moveVector)
        {
            MoveVector = _moveVector;
        }
        public void SetLookVector(Vector2 _lookVector)
        {
            LookVector = _lookVector;
        }
        public void SetWestButton(bool _value)
        {
            HasWestFaceButtonInput = _value;
        }
        public void SetEastButton(bool _value)
        {
            HasEastFaceButtonInput = _value;
        }
        public void SetNorthButton(bool _value)
        {
            HasNorthFaceButtonInput = _value;
        }
        public void SetSouthButton(bool _value)
        {
            HasSouthFaceButtonInput = _value;
        }
        public void SetLeftStickClickButton(bool _value)
        {
            HasLeftStickClickInput = _value;
        }
        public void SetRightStickClickButton(bool _value)
        {
            HasRightStickClickInput = _value;
        }
        public void SetLeftShoulderButton(bool _value)
        {
            HasLeftShoulderButtonInput = _value;
        }
        public void SetRightShoulderButton(bool _value)
        {
            HasRightShoulderButtonInput = _value;
        }
        #endregion
    }

}
