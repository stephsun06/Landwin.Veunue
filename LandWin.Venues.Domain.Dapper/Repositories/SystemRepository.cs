
using Dapper;
using LandWin.Venues.Domain.Dapper.Entities;
using System.Collections.Generic;
using System.Data;

namespace LandWin.Venues.Domain.Dapper.Repositories
{
    public class SystemRepository : DapperRepository, ISystemRepository 
    {
        public SystemRepository(IDbTransaction unitOfWork) : base(unitOfWork) { }
        
        public IEnumerable<SystemValue> GetSystemValues()
        {
            return Connection.Query<SystemValue>("GetSystemValues", commandType: CommandType.StoredProcedure);
        }
    }
}
