namespace MoI.SM
{
    public class GameInitState : LevelStateBase
    {
        
        protected override void OnEnter()
        {
            base.OnEnter();
            _core.StartGame();
            RequestTransition<ActionState>();
        }
        
    }
}