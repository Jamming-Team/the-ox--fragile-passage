namespace MoI.SM
{
    public class PauseState : LevelStateBase
    {
        protected override void OnEnter()
        {
            base.OnEnter();
            GameEvents.OnPressContinue += OnPressContinue;
            GameEvents.OnPressRestart += OnPressRestart;
            GameEvents.OnPressToMainMenu += OnPressToMainMenu;
        }

        protected override void OnExit()
        {
            base.OnExit();
            GameEvents.OnPressContinue -= OnPressContinue;
            GameEvents.OnPressRestart -= OnPressRestart;
            GameEvents.OnPressToMainMenu -= OnPressToMainMenu;
        }
        
        private void OnPressToMainMenu()
        {
            RequestTransition<MainViewState>();
        }

        private void OnPressRestart()
        {
            RequestTransition<GameInitState>();
        }

        private void OnPressContinue()
        {
            RequestTransition<ActionState>();
        }
    }
}