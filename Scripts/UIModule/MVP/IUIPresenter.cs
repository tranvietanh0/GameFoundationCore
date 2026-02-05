namespace GameFoundationCore.Scripts.UIModule.MVP
{
    /// <summary>
    /// Show logic of Presenter in MVP architecture
    /// </summary>
    public interface IUIPresenter
    {
        public void SetView(IUIView view);
    }
    public interface IUIPresenterWithModel<TModel> : IUIPresenter
    {
        void Init(IUIView view, TModel param);
    }
}