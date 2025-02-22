namespace MoI.SM
{
    public class MainViewState : LevelStateBase
    {
        protected override void OnEnter()
        {
            base.OnEnter();
            GameEvents.OnPressStart += OnPressStart;
            GameEvents.OnPressSettings += OnPressSettings;
            GameEvents.OnPressHowToPlay += OnPressHowToPlay;
            _core.IntroGame();
        }
        
        protected override void OnExit()
        {
            base.OnExit();
            GameEvents.OnPressStart -= OnPressStart;
            GameEvents.OnPressSettings -= OnPressSettings;
            GameEvents.OnPressHowToPlay -= OnPressHowToPlay;
        }

        private void OnPressSettings()
        {
            RequestTransition<SettingsState>();
        }

        private void OnPressHowToPlay()
        {
            RequestTransition<HowToPlayState>();
        }

        private void OnPressStart()
        {
            _core.StartGame();
            RequestTransition<ActionState>();
        }
    }
}