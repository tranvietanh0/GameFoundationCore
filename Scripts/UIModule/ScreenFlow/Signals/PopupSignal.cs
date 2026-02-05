namespace GameFoundationCore.Scripts.UIModule.ScreenFlow.Signals
{
    using GameFoundationCore.Scripts.UIModule.ScreenFlow.BaseScreen.Presenter;

    public class PopupShowedSignal
    {
        public IScreenPresenter ScreenPresenter;
    }

    public class PopupHiddenSignal
    {
        public IScreenPresenter ScreenPresenter;
    }

    public class PopupBlurBgShowedSignal
    {
    }
}