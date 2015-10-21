using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using App.Models;
using App.Data;
using App.Services.Ahs;
using App.Models;

namespace App.Web.Areas.Backoffice.Controllers
{
    [Area("Backoffice")]
    public abstract class CommonController : Controller
    {
        [FromServices]
        public LibraryDbContext _libraryContext { get; set; }
        
        [FromServices]
        public IMediatheekService _mediatheekService { get; set; }
        
        public void Success(string message, bool dismissable = false)
        {
            AddAlert(AlertType.Success, message, dismissable);
        }

        public void Information(string message, bool dismissable = false)
        {
            AddAlert(AlertType.Info, message, dismissable);
        }
    
        public void Warning(string message, bool dismissable = false)
        {
            AddAlert(AlertType.Warning, message, dismissable);
        }
    
        public void Danger(string message, bool dismissable = false)
        {
            AddAlert(AlertType.Error, message, dismissable);
        }
    
        private void AddAlert(AlertType alertType, string message, bool dismissable)
        {
            var alerts = TempData.ContainsKey("SRVALERT")
                ? (List<Alert>)TempData["SRVALERT"]
                : new List<Alert>();
    
            alerts.Add(new Alert
            {
                Type = alertType,
                Message = message,
                Dismissable = dismissable
            });
    
            TempData["SRVALERT"] = alerts;
        }
        
        private string MSGCREATEOK = "Created the {0} {1} in the database! {2}";
        private string MSGCREATENOK = "Could not creat the {0} {1} in the database! {2}";
        private string MSGEDITOK = "Updated the {0} {1} in the database! {2}";
        private string MSGEDITNOK = "Could not update the {0} {1} in the database! {2}";
        private string MSGDELETEOK = "Deleted the {0} {1} in the database! {2}";
        private string MSGDELETENOK = "Could not delete the {0} {1} in the database! {2}";
        private string MSGSOFTDELETEOK = "Soft-deleted the {0} {1} in the database! {2}";
        private string MSGSOFTDELETENOK = "Could not soft-delete the {0} {1} in the database! {2}";
        private string MSGSOFTUNDELETEOK = "Soft-undeleted the {0} {1} in the database! {2}";
        private string MSGSOFTUNDELETENOK = "Could not soft-undelete the {0} {1} in the database! {2}";
        private string MSGENABLETWOFACTOROK = "Enabled Two Factor for the {0} {1} in the database! {2}";
        private string MSGENABLETWOFACTORNOK = "Could not enable Two Factor for the {0} {1} in the database! {2}";
        private string MSGDISABLETWOFACTOROK = "Disabled Two Factor for the {0} {1} in the database! {2}";
        private string MSGDISABLETWOFACTORNOK = "Could not disable Two Factor for the {0} {1} in the database! {2}";
        
        protected string CreateMessage(ControllerActionType actionType, string type, Object id, Exception ex = null)
        {
            var msg = "";

            switch (actionType)
            {
                case ControllerActionType.Create:default:
                    msg = (ex == null) ? MSGCREATEOK : MSGCREATENOK;break;
                case ControllerActionType.Edit:
                    msg = (ex == null) ? MSGEDITOK : MSGEDITNOK; break;
                case ControllerActionType.Delete:
                    msg = (ex == null) ? MSGDELETEOK : MSGDELETENOK; break;
                case ControllerActionType.SoftDelete:
                    msg = (ex == null) ? MSGSOFTDELETEOK : MSGSOFTDELETENOK; break;
                case ControllerActionType.SoftUnDelete:
                    msg = (ex == null) ? MSGSOFTUNDELETEOK : MSGSOFTUNDELETENOK; break;
                case ControllerActionType.EnableTwoFactor:
                    msg = (ex == null) ? MSGENABLETWOFACTOROK : MSGENABLETWOFACTORNOK; break;
                case ControllerActionType.DisableTwoFactor:
                    msg = (ex == null) ? MSGDISABLETWOFACTOROK : MSGDISABLETWOFACTORNOK; break;
            }

            msg = String.Format(msg, type, id, ((ex != null)?ex.ToString():""));

            return msg;
        }
    }
    
    public enum ControllerActionType
    {
        Index = 0,
        Create = 1,
        Edit = 2,
        Delete = 3,
        SoftDelete = 4,
        SoftUnDelete = 5,
        Lock = 6,
        UnLock = 7,
        EnableTwoFactor = 8,
        DisableTwoFactor = 9
    }
}
