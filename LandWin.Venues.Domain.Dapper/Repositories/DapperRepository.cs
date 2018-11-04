﻿using Dapper;
using System;
using System.Data;
using System.Transactions;

namespace LandWin.Venues.Domain.Dapper.Repositories
{
    public class DapperRepository : RepositoryBase
    {

        public DapperRepository(IDbTransaction unitofWork) : base(unitofWork) { }

        public void SqlExecute(string storedProd, DynamicParameters p, bool returnError = false)
        {
            if (returnError)
            {
                p.Add("frk_strErrorText", dbType: DbType.String, direction: ParameterDirection.Output, size: 100);
                p.Add("frk_n4ErrorCode", dbType: DbType.Int32, direction: ParameterDirection.Output);

                Connection.Execute(storedProd, p, commandType: CommandType.StoredProcedure);

                if (p.Get<int>("frk_n4ErrorCode") != 0)
                {
                    throw new Exception(string.Format("ErrorCode : {0} , ErrorMessage : {1}", p.Get<int>("frk_n4ErrorCode"), p.Get<string>("frk_strErrorText")));
                }
            }
            else
                Connection.Execute(storedProd, p, commandType: CommandType.StoredProcedure);

            
        }
    }
}