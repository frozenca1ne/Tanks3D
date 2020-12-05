namespace Managers
{
    public class PauseState : GameState
    {
        public override void Handle()
        {
            context.DisableTankControl();
        }
    }
}
