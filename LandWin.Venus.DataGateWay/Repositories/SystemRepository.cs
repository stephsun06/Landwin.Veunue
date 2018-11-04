
using Dapper;
using LandWin.Venus.DataGateWay.Models;
using System.Collections.Generic;
using System.Data;

namespace LandWin.Venus.DataGateWay.Repositories
{
    public class SystemRepository : DapperRepository, ISystemRepository 
    {
        public SystemRepository(IUnitOfWork unitOfWork) : base(unitOfWork) { }


        public IEnumerable<Merchant> GetMerchants()
        {
            return Connection.Query<Merchant>("GetMerchants", commandType: CommandType.StoredProcedure);
        }

        public IEnumerable<SystemValue> GetSystemValues()
        {
            return Connection.Query<SystemValue>("GetSystemValues", commandType: CommandType.StoredProcedure);
        }
    }
}
