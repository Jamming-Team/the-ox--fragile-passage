namespace MoI.SM
{
    public class HowToPlayState : LevelStateBase
    {
        protected override void OnEnter()
        {
            base.OnEnter();
            GameEvents.OnPressBack += OnPressBack;
        }
        
        protected override void OnExit()
        {
            base.OnEnter();
            GameEvents.OnPressBack += OnPressBack;
        }

        private void OnPressBack()
        {
            RequestTransition<MainViewState>();
        }
    }
}