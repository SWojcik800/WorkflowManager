using StorageManager.App.Commons.IoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageManager.App
{
    public class TestSingletomService : ITestSingletomService
    {
        private Guid Guid;
        public TestSingletomService()
        {
            Guid = Guid.NewGuid();
        }
        public Guid GetGuid()
            => Guid;
    }

    public interface ITestSingletomService : ISingleton
    {
        Guid GetGuid();
    }
}
