using Blazored.Modal;
using Blazored.Modal.Services;
using FileOnTheCloud.Client.CustomComponents.Modal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileOnTheCloud.Client.Instrument
{
    public class ModalManager : IModalManager
    {
        private readonly IModalService modalService;

        public ModalManager(IModalService modalService)
        {
            this.modalService = modalService;
        }

        public async Task ShowMessageAsync(string title, string message)
        {
            ModalParameters modalParameters = new();
            modalParameters.Add("Message", message);

            var modelref = this.modalService.Show<ShowMessagepPopup>(title, modalParameters);

            await modelref.Result;
        }

        public async Task<bool> ConfirmationAsync(string title, string message)
        {
            ModalParameters modalParameters = new();
            modalParameters.Add("Message", message);

            var modelref = this.modalService.Show<ConfirmationPopup>(title, modalParameters);

            var modelresult = await modelref.Result;

            return !modelresult.Cancelled;
        }


    }
}
