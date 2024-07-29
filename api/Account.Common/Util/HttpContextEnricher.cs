using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using Microsoft.AspNetCore.Http;
using Serilog.Core;
using Serilog.Events;

namespace Account.Common.Util;

public class HttpContextEnricher : ILogEventEnricher
{
    private readonly IHttpContextAccessor _contextAccessor;

    public HttpContextEnricher() : this(new HttpContextAccessor()) { }

    private HttpContextEnricher(IHttpContextAccessor contextAccessor)
    {
        _contextAccessor = contextAccessor;
    }

    public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
    {
        var ip = GetLocalIpAddresses()?.ToString();

        var userName = _contextAccessor.HttpContext?.User?.Identity?.Name;

        logEvent.AddOrUpdateProperty(propertyFactory.CreateProperty("CreateUser", userName));
        logEvent.AddOrUpdateProperty(propertyFactory.CreateProperty("Ip", ip));
        //Prov: UAParser package to get Browser full detail
        logEvent.AddOrUpdateProperty(propertyFactory.CreateProperty("Browser", _contextAccessor.HttpContext?.Request.Headers["User-Agent"].ToString()));
    }

    private IPAddress GetLocalIpAddresses(NetworkInterfaceType networkInterfaceType = NetworkInterfaceType.Ethernet)
    {
        IPAddress returnAddress = null;

        // Get a list of all network interfaces (usually one per network card, dialup, and VPN connection)
        var networkInterfaces = NetworkInterface.GetAllNetworkInterfaces()
                                                // Filter networks by parameter and other conditions
                                                .Where(x =>
                                                           x.NetworkInterfaceType == networkInterfaceType &&
                                                           x.OperationalStatus == OperationalStatus.Up &&
                                                           !x.Description.ToLower().Contains("virtual") &&
                                                           !x.Description.ToLower().Contains("pseudo"));

        foreach (var network in networkInterfaces)
        {
            // Read the IP configuration for each network
            var properties = network.GetIPProperties();

            // Each network interface may have multiple IP addresses
            foreach (var address in properties.UnicastAddresses)
            {
                if
                (
                    // We're only interested in IPv4 addresses for now
                    address.Address.AddressFamily != AddressFamily.InterNetwork ||
                    // Ignore loopback addresses (e.g., 127.0.0.1)    
                    IPAddress.IsLoopback(address.Address)
                )
                    continue;

                returnAddress = address.Address;
            }
        }

        return returnAddress;
    }
}
