
using LandWin.Venues.Domain.Dapper;
using LandWin.Venues.Domain.Dapper.Entities;
using LandWin.Venues.Domain.Dapper.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandWin.Venues.DataCollection.Services.Infra
{
    public class SystemConfiguration : ISystemConfiguration
    {
        private List<SystemValue> values = new List<SystemValue>();

        public SystemConfiguration(ISystemRepository systemRepository)
        {
            if (systemRepository == null) throw new ArgumentNullException("systemRepository");

            values = systemRepository.GetSystemValues().ToList();
        }

        public string DataApiUrl
        {
            get { return values.FirstOrDefault(x=>x.Code =="ApiUrl").CodeValue; }
        }

        public string ApiToken
        {
            get { return values.FirstOrDefault(x => x.Code == "BearerToken").CodeValue; }
        }

        public string FtpUserName
        {
            get { return values.FirstOrDefault(x => x.Code == "FtpUserName").CodeValue; }
        }

        public string FtpPassword
        {
            get { return values.FirstOrDefault(x => x.Code == "FtpPassword").CodeValue; }
        }

        public string FtpUrl
        {
            get { return values.FirstOrDefault(x => x.Code == "FtpUrl").CodeValue; }
        }
    }
}
