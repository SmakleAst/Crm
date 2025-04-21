using Crm.Persistence;

namespace Crm.Tests.Common
{
    public  abstract class TestCommandBase : IDisposable
    {
        protected readonly CrmDbContext Context;

        public TestCommandBase()
        {
            Context = CrmContextFactory.Create();
        }

        public void Dispose()
        {
            CrmContextFactory.Destroy(Context);
        }
    }
}
