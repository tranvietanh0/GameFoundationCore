namespace GameFoundationCore.Scripts.DI.VContainer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using GameFoundationCore.DI.Submodules.GameFoundationCore.Scripts.DI;
    using UnityEngine;
    using UnityEngine.Scripting;
    using global::VContainer.Internal;

    public sealed class VContainerAdapter : global::VContainer.Unity.IStartable, global::VContainer.Unity.ITickable, global::VContainer.Unity.ILateTickable, global::VContainer.Unity.IFixedTickable, IDisposable
    {
        private readonly IReadOnlyList<IInitializable>  initializables;
        private readonly IReadOnlyList<ITickable>       tickables;
        private readonly IReadOnlyList<ILateTickable>   lateTickables;
        private readonly IReadOnlyList<IFixedTickable>  fixedTickables;
        private readonly IReadOnlyList<ILateDisposable> lateDisposables;

        [Preserve]
        public VContainerAdapter(
            ContainerLocal<IEnumerable<IInitializable>>  initializables,
            ContainerLocal<IEnumerable<ITickable>>       tickables,
            ContainerLocal<IEnumerable<ILateTickable>>   lateTickables,
            ContainerLocal<IEnumerable<IFixedTickable>>  fixedTickables,
            ContainerLocal<IEnumerable<ILateDisposable>> lateDisposables
        )
        {
            this.initializables  = initializables.Value.ToArray();
            this.tickables       = tickables.Value.ToArray();
            this.lateTickables   = lateTickables.Value.ToArray();
            this.fixedTickables  = fixedTickables.Value.ToArray();
            this.lateDisposables = lateDisposables.Value.ToArray();
        }

        void global::VContainer.Unity.IStartable.Start()
        {
            SafeForEach(this.initializables, initializable => initializable.Initialize());
        }

        void global::VContainer.Unity.ITickable.Tick()
        {
            SafeForEach(this.tickables, tickable => tickable.Tick());
        }

        void global::VContainer.Unity.ILateTickable.LateTick()
        {
            SafeForEach(this.lateTickables, lateTickable => lateTickable.LateTick());
        }

        void global::VContainer.Unity.IFixedTickable.FixedTick()
        {
            SafeForEach(this.fixedTickables, fixedTickable => fixedTickable.FixedTick());
        }

        void IDisposable.Dispose()
        {
            SafeForEach(this.lateDisposables, lateDisposable => lateDisposable.LateDispose());
        }

        private static void SafeForEach<T>(IEnumerable<T> enumerable, Action<T> action)
        {
            foreach (var item in enumerable)
            {
                try
                {
                    action(item);
                }
                catch (Exception e)
                {
                    Debug.LogException(e);
                }
            }
        }
    }
}