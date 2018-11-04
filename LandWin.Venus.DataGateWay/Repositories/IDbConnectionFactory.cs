using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandWin.Venus.DataGateWay.Repositories
{
    public interface IDbConnectionFactory
    {
        IDbConnection GetOpenConnection();
    }
}
