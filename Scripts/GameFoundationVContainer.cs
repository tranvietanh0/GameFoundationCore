namespace GameFoundationCore.Scripts
{
    using GameFoundationCore.Scripts.AssetLibrary;
    using GameFoundationCore.Scripts.DI.VContainer;
    using GameFoundationCore.Scripts.Signals;
    using GameFoundationCore.Scripts.UIModule;
    using GameFoundationCore.Scripts.Utilities.UserData;
    using UniT.Logging.DI;
    using UnityEngine;
    using VContainer;

    public static class GameFoundationVContainer
    {
        public static void RegisterGameFoundation(this IContainerBuilder builder, Transform transform)
        {
            builder.Register<VContainerWrapper>(Lifetime.Scoped).AsImplementedInterfaces();
            builder.Register<VContainerAdapter>(Lifetime.Scoped).AsImplementedInterfaces();

            builder.RegisterSignalBus();
            builder.RegisterScreenManager();

            builder.RegisterLoggerManager();

            builder.Register<GameAssets>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<HandleLocalUserDataServices>(Lifetime.Singleton).AsImplementedInterfaces();

            builder.DeclareSignal<UserDataLoadedSignal>();
        }
    }
}