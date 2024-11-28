﻿using Application.Services.Hubs;
using Microsoft.Extensions.DependencyInjection;
using SignalR.HubServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR;
public static class SignalRServiceRegistration
{
    public static void AddSignalRServices(this IServiceCollection collection)
    {
        collection.AddTransient<INoteHubService, NoteHubService>();
        collection.AddSignalRCore();
    }
}