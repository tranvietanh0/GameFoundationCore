namespace GameFoundationCore.Scripts
{
    using GameFoundationCore.Scripts.AssetLibrary;
    using GameFoundationCore.Scripts.Signals;
    using GameFoundationCore.Scripts.UIModule;
    using UnityEngine;
    using VContainer;

    public static class GameFoundationVContainer
    {
        public static void RegisterGameFoundation(this IContainerBuilder builder, Transform transform)
        {
            builder.RegisterSignalBus();
            builder.RegisterScreenManager();

            builder.Register<GameAssets>(Lifetime.Singleton).AsImplementedInterfaces();
        }
    }
}