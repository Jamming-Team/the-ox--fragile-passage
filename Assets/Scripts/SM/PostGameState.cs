namespace MoI.SM
{
    public class PostGameState : LevelStateBase
    {
        protected override void OnEnter()
        {
            base.OnEnter();
            GameEvents.OnPressRestart += OnPressRestart;
            GameEvents.OnPressToMainMenu += OnPressToMainMenu;
            _core.StopGame();
        }

        protected override void OnExit()
        {
            base.OnExit();
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
    }
}