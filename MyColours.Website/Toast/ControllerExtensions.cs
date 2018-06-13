using CQRS.Core.Commands;
using MyColours.Website.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyColours.Website.Toast
{
    public static class ControllerExtensions
    {
        public static ToastMessage AddToastMessage(this Controller controller, string title, string message, ToastType toastType = ToastType.Info)
        {
            Toastr toastr = controller.TempData["Toastr"] as Toastr;
            toastr = toastr ?? new Toastr();

            var toastMessage = toastr.AddToastMessage(title, message, toastType);
            controller.TempData["Toastr"] = toastr;
            return toastMessage;
        }

        public static ToastMessage AddToastMessage(this Controller controller, ICommandResult commandResult)
        {
            Toastr toastr = controller.TempData["Toastr"] as Toastr;
            toastr = toastr ?? new Toastr();

            var toastMessage = toastr.AddToastMessage(commandResult.Title, commandResult.Message, (ToastType)commandResult.MessageType);
            controller.TempData["Toastr"] = toastr;
            return toastMessage;
        }
    }
}