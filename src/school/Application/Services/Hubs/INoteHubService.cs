using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Hubs;
public interface INoteHubService
{
    Task NoteUpdatedMessageAsync(string message);
}
