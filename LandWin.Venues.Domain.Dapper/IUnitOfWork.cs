using LandWin.Venues.Domain.Dapper.Repositories;
using System;
using System.Data;

namespace LandWin.Venues.Domain.Dapper
{
    public interface IUnitOfWork : IDisposable
    {
        ISystemRepository SystemRepository { get; }
        IVenueProductRepository VenueProductRepository { get; }
        IMerchantRepository MerchantRepository { get; }

        void Commit();
    }
}

