namespace KbsMobile.Services.Connectivity;

public class ConnectivityService : IConnectivityService
{
    public bool IsConnected => Connectivity.NetworkAccess == NetworkAccess.Internet;
}
