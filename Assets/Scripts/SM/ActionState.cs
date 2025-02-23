namespace MoI.SM
{
    public class ActionState : LevelStateBase
    {
        protected override void OnEnter()
        {
            base.OnEnter();
            GameEvents.OnPressPause += OnPressPause;
            
            GameEvents.OnGameWon += OnGameWon;
            GameEvents.OnGameLost += OnGameLost;
        }
        protected override void OnExit()
        {
            base.OnExit();
            GameEvents.OnPressPause -= OnPressPause;
            
            GameEvents.OnGameWon -= OnGameWon;
            GameEvents.OnGameLost -= OnGameLost;
        }
        
        private void OnPressPause()
        {
            RequestTransition<PauseState>();
        }
        
        private void OnGameLost()
        {
            _core.StopGame();
            RequestTransition<PostGameState>();
        }

        private void OnGameWon()
        {
            _core.StopGame();
            RequestTransition<PostGameState>();
        }
    }
}