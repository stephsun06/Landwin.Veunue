

namespace LandWin.Venues.DataCollection.Services.Infra
{
    public interface ISystemConfiguration
    {
        string DataApiUrl { get; }
        string ApiToken { get; }
        string FtpUserName { get; }
        string FtpPassword { get; }
        string FtpUrl { get; }
    }
}
