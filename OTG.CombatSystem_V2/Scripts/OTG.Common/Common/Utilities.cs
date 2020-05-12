using UnityEngine;
using System.Collections;

namespace OTG.Common
{
    public static class StringUtilities
    {
        public const string OTGRoot = "OTG/";
        public const string CombatStateMachinePathRoot = OTGRoot + "CombatStateMachine/";
        public const string CombatStatePath = CombatStateMachinePathRoot + "CombatState";
        public const string CombatActionPathRoot = CombatStateMachinePathRoot + "CombatActions/";
        public const string TransitionDecisionPathRoot = CombatStateMachinePathRoot + "TransitionDecisions/";
        public const string CombatAnimationPath = CombatStateMachinePathRoot + "CombatAnimation";
        public const string AnimationEventPathRoot = CombatStateMachinePathRoot + "AnimationEvents/";
        public const string AnimationEventContainerPath = AnimationEventPathRoot + "AnimationEventContainer";
        public const string AnimationEventContentPathRoot = AnimationEventPathRoot + "AnimationEventContents/";
        public const string ConfigurationPathRoot = CombatStateMachinePathRoot + "Configurations/";

        public const string EventSystemPathRoot = OTGRoot + "EventSystem/";
        public const string OTGEventPathRoot = EventSystemPathRoot + "OTGEvents/";
    }
    public static class AudioStrings
    {
        public const string SoundFXMixingGroup = "SoundFx";
        public const string StageMusicMixingGroup = "StageMusic";
        public const string BattleMusicMixingGroup = "BattleMusic";
        public const string AmbientMixingGroup = "Ambient";
        public const string BattleSnapShot = "BattleMusic";
        public const string StageSnapShot = "StageMusic";

    }

}
