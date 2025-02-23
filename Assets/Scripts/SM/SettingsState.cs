namespace MoI.SM
{
    public class SettingsState : LevelStateBase
    {
        protected override void OnEnter()
        {
            base.OnEnter();
            GameEvents.OnPressBack += OnPressBack;
        }
        
        protected override void OnExit()
        {
            base.OnExit();
            GameEvents.OnPressBack -= OnPressBack;
        }

        private void OnPressBack()
        {
            RequestTransition<MainViewState>();
        }
    }
}