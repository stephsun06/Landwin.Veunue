
using LandWin.Venues.Domain.Dapper.Entities;
using System;
using System.Collections.Generic;


namespace LandWin.Venues.Domain.Dapper.Repositories
{
    public interface ISystemRepository
    {
        IEnumerable<SystemValue> GetSystemValues();
    }
}
