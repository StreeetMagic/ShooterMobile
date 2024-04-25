using NUnit.Framework;
using Zenject.OptionalExtras.TestFramework;
using Zenject.Source.Binding.Binders.Factory.FactoryFromBinder;
using Zenject.Source.Binding.BindInfo;
using Zenject.Source.Factories;
using Zenject.Source.Factories.Pooling;
using Assert = Zenject.Source.Internal.Assert;

#pragma warning disable 219

namespace Zenject.OptionalExtras.UnitTests.Editor.MemoryPool
{
    [TestFixture]
    public class TestMemoryPoolCustomFactory : ZenjectUnitTestFixture
    {
        [Test]
        public void TestFromBinding()
        {
            Container.BindMemoryPool<Qux, Qux.Pool>().FromIFactory(b => b.To<CustomFactory>().AsCached());

            var pool = Container.Resolve<Qux.Pool>();

            var qux = pool.Spawn();

            Assert.IsEqual(pool.NumTotal, 1);
        }

        [Test]
        public void TestFromRuntime()
        {
            var settings = new MemoryPoolSettings(0, int.MaxValue, PoolExpandMethods.OneAtATime);

            var pool = Container.Instantiate<Qux.Pool>(new object[] { settings, new CustomFactory() });

            var qux = pool.Spawn();

            Assert.IsEqual(pool.NumTotal, 1);
        }

        class CustomFactory : IFactory<Qux>
        {
            public Qux Create()
            {
                return new Qux();
            }
        }

        class Qux
        {
            public class Pool : MemoryPool<Qux>
            {
            }
        }
    }
}


