using System;

namespace BenFatto.Domain.Entities
{
    public class Log
    {
        string Ip { get; set; }
        DateTime Ocurrencies { get; set; }
        string HttpCommand { get; set; }
        string HttpProtocol { get; set; }
        string Adresss { get; set; }
        int HttPResponsa { get; set; }
        int Port { get; set; }
    }
}
