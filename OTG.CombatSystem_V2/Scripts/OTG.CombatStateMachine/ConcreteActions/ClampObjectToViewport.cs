
using UnityEngine;
using OTG.Common;
using OTG.Cameras;

namespace OTG.CombatStateMachine
{
    [CreateAssetMenu(fileName = "ClampObjectToViewport", menuName = StringUtilities.CombatActionPathRoot+"ClampObjectToViewport")]
    public class ClampObjectToViewport : CombatAction
    {
        public override void Act(CombatStateMachineController _controller)
        {
            Vector3 pos = MainCameraReference.MainCamera.WorldToViewportPoint(_controller.MoveHandler.TransformComp.position);
            pos.x = Mathf.Clamp01(pos.x);
            pos.y = Mathf.Clamp01(pos.y);
            _controller.MoveHandler.TransformComp.position = MainCameraReference.MainCamera.ViewportToWorldPoint(pos);
        }
    }

}

