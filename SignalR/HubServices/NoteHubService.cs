using Application.Services.Hubs;
using Microsoft.AspNetCore.SignalR;
using SignalR.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.HubServices;
public class NoteHubService : INoteHubService
{
    readonly IHubContext<NoteHub> _hubContext;

    public NoteHubService(IHubContext<NoteHub> hubContext)
    {
        _hubContext = hubContext;
    }

    public async Task NoteUpdatedMessageAsync(string message)
    {
       await _hubContext.Clients.All.SendAsync(ReceiveFunctionNames.NotesUpdatedMessage, message);
    }
}
