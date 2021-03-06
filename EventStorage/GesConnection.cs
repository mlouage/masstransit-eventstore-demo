﻿using System.Net;
using Domain;
using EventStore.ClientAPI;

namespace EventStorage
{
    public static class GesConnection
    {
        private const int Defaultport = 1113;

        public static IEventStoreConnection Create()
        {
            var settings = ConnectionSettings.Create()
               .UseConsoleLogger();

            var connection = EventStoreConnection.Create(settings, new IPEndPoint(IPAddress.Loopback, Defaultport));

            connection.ConnectAsync().Wait();

            return connection;
        }
    }
}
