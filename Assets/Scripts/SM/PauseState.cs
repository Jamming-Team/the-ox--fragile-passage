using UnityEngine;

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
            Time.timeScale = 0f;
        }

        protected override void OnExit()
        {
            base.OnExit();
            GameEvents.OnPressContinue -= OnPressContinue;
            GameEvents.OnPressRestart -= OnPressRestart;
            GameEvents.OnPressToMainMenu -= OnPressToMainMenu;
            Time.timeScale = 1f;
        }
        
        private void OnPressToMainMenu()
        {
            _core.StopGame();
            RequestTransition<MainViewState>();
        }

        private void OnPressRestart()
        {
            _core.StopGame();
            _core.StartGame();
            RequestTransition<ActionState>();
        }

        private void OnPressContinue()
        {
            RequestTransition<ActionState>();
        }
    }
}