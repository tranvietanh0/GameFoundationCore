namespace GameFoundationCore.Scripts.UIModule
{
    using GameFoundationCore.Scripts.UIModule.ScreenFlow.Manager;
    using VContainer;

    public static class ScreenManagerVContainer
    {
        public static void RegisterScreenManager(this IContainerBuilder builder)
        {
            builder.Register<ScreenManager>(Lifetime.Singleton).AsImplementedInterfaces();
        }
    }
}