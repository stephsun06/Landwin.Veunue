using LandWin.Venus.DataGateWay.Models;
using System;
using System.Collections.Generic;


namespace LandWin.Venus.DataGateWay.Repositories
{
    public interface ISystemRepository
    {
        IEnumerable<Merchant> GetMerchants();
        IEnumerable<SystemValue> GetSystemValues();
    }
}
