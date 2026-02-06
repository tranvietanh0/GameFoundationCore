namespace GameFoundationCore.Scripts.Utilities.ApplicationServices
{
    using GameFoundationCore.Scripts.Signals;
    using GameFoundationCore.Scripts.Utilities.UserData;
    using UnityEngine;
    using VContainer;
    using VContainer.Unity;

    public static class ApplicationServicesVContainer
    {
        public static void RegisterApplicationServices(this IContainerBuilder builder, Transform rootTransform)
        {
            builder.RegisterComponentOnNewGameObject<MinimizeAppService>(Lifetime.Singleton).UnderTransform(rootTransform);
            builder.RegisterBuildCallback(container => container.Resolve<MinimizeAppService>().Construct(container.Resolve<SignalBus>(), container.Resolve<IHandleUserDataServices>()));

            builder.DeclareSignal<ApplicationPauseSignal>();
            builder.DeclareSignal<ApplicationQuitSignal>();
            builder.DeclareSignal<UpdateTimeAfterFocusSignal>();
        }
    }
}