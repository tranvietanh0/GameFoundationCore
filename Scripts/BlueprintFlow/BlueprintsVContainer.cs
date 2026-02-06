using BlueprintConfig = BlueprintFlow.BlueprintControlFlow.BlueprintConfig;
using BlueprintDownloader = BlueprintFlow.APIHandler.BlueprintDownloader;
using BlueprintReaderManager = BlueprintFlow.BlueprintControlFlow.BlueprintReaderManager;
using FetchBlueprintInfo = BlueprintFlow.APIHandler.FetchBlueprintInfo;
using IGenericBlueprintReader = BlueprintFlow.BlueprintReader.IGenericBlueprintReader;
using PreProcessBlueprintMobile = BlueprintFlow.BlueprintControlFlow.PreProcessBlueprintMobile;

namespace GameFoundationCore.Scripts.BlueprintFlow
{
    using GameFoundationCore.Scripts.BlueprintFlow.Signals;
    using GameFoundationCore.Scripts.Models;
    using GameFoundationCore.Scripts.Signals;
    using UniT.Extensions;
    using VContainer;

    public static class BlueprintsVContainer
    {
        public static void RegisterBlueprints(this IContainerBuilder builder)
        {
            builder.Register<PreProcessBlueprintMobile>(Lifetime.Singleton);
            builder.Register<FetchBlueprintInfo>(Lifetime.Singleton);
            builder.Register<BlueprintDownloader>(Lifetime.Singleton);
            builder.Register<BlueprintReaderManager>(Lifetime.Singleton);
            builder.Register(container => container.Resolve<GDKConfig>().GetGameConfig<BlueprintConfig>(), Lifetime.Singleton);

            typeof(IGenericBlueprintReader).GetDerivedTypes().ForEach(type => builder.Register(type, Lifetime.Singleton).AsImplementedInterfaces().AsSelf());

            builder.DeclareSignal<ReadBlueprintProgressSignal>();
            builder.DeclareSignal<LoadBlueprintDataProgressSignal>();
            builder.DeclareSignal<LoadBlueprintDataSucceedSignal>();
        }
    }
}