namespace MoI.SM
{
    public class ActionState : LevelStateBase
    {
        protected override void OnEnter()
        {
            base.OnEnter();
            GameEvents.OnPressPause += OnPressPause;
        }
        protected override void OnExit()
        {
            base.OnExit();
            GameEvents.OnPressPause -= OnPressPause;
        }
        
        private void OnPressPause()
        {
            RequestTransition<PauseState>();
        }
    }
}