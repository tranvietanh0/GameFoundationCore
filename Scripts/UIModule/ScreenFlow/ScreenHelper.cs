namespace GameFoundationCore.Scripts.UIModule.ScreenFlow
{
    using GameFoundationCore.Scripts.UIModule.ScreenFlow.BaseScreen.View;
    using GameFoundationCore.Scripts.UIModule.ScreenFlow.Manager;

    public static class ScreenHelper
    {
        public static string GetScreenId<TView>() where TView : IScreenView
        {
            return $"{SceneDirector.CurrentSceneName}/{typeof(TView).Name}";
        }
    }
}