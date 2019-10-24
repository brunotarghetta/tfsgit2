using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BCR.Tests
{
    public abstract class TestClassBase<TTarget>
    {
        protected TTarget Target { get; set; }

        protected TestClassBase()
        {
        }

        [TestInitialize]
        public void Init()
        {
            this.OnInit();
        }

        protected virtual void OnInit()
        {
        }

        [TestCleanup]
        public void Cleanup()
        {
            this.OnCleanup();
        }

        protected virtual void OnCleanup()
        {
        }
    }
}
