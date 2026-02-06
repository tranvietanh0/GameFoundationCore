namespace GameFoundationCore.Scripts.Utilities.ApplicationServices
{
    public class ApplicationPauseSignal
    {
        public bool PauseStatus;

        public ApplicationPauseSignal(bool pauseStatus)
        {
            this.PauseStatus = pauseStatus;
        }
    }
}