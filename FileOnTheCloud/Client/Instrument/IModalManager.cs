using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileOnTheCloud.Client.Instrument
{
    public interface IModalManager
    {
        Task<bool> ConfirmationAsync(string title, string message);
        Task ShowMessageAsync(string title, string message);
    }
}
