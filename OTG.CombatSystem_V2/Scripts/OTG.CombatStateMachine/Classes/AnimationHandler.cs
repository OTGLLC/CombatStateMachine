using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Playables;


namespace OTG.CombatStateMachine
{
    public class AnimationHandler
    {
        public Animator AnimatorComp { get; private set; }
        public AnimationEventContainer CurrentAnimationEvent { get; private set; }


        #region Fields
        private PlayableGraph m_playableGraph;
        private AnimationPlayableOutput m_playableOutput;
        private AnimationClipPlayable m_clipPlayable;
        #endregion

        #region Public API
        public void InitializeAnimHandler(GameObject _owner)
        {
            InitiaizeReferences(_owner);
            SetupPlayableGraph();
        }
        public void CleanupAnimHandler()
        {
            Cleanup();
        }
        public void PlayAnimation(AnimationClip _clip)
        {
            SetAnimationClip(_clip);
            PlayCurrentAnimation();
        }
        public void SetAnimationEvent(AnimationEventContainer _animEventContainer)
        {
            CurrentAnimationEvent = _animEventContainer;
        }
        #endregion

        #region Utility
        private void InitiaizeReferences(GameObject _owner)
        {
            AnimatorComp = _owner.GetComponent<Animator>();
        }
        private void Cleanup()
        {
            AnimatorComp = null;
            CurrentAnimationEvent = null;
            m_playableGraph.Destroy();
        }
        private void SetupPlayableGraph()
        {
            m_playableGraph = PlayableGraph.Create();
            m_playableGraph.SetTimeUpdateMode(DirectorUpdateMode.GameTime);
            m_playableOutput = AnimationPlayableOutput.Create(m_playableGraph, "CombatAnimation", AnimatorComp);

        }
        private void SetAnimationClip(AnimationClip _clip)
        {
            m_clipPlayable = AnimationClipPlayable.Create(m_playableGraph, _clip);
            m_playableOutput.SetSourcePlayable(m_clipPlayable);
        }
        void PlayCurrentAnimation()
        {
            m_clipPlayable.Play();
            m_playableGraph.Play();
        }
        #endregion
    }

}
