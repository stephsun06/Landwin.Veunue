using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandWin.Venues.DataCollection.Services.ProcessManager
{
    public interface IDataCollectionManager
    {
      void Run(string merchant);
    }
}
