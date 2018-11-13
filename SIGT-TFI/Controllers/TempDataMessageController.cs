using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SIGT_TFI.Controllers
{

    public static class TempDataMessage
    {

        public static void AddMessage(this Controller controller, string identifier, string message)
        {
            if (controller.TempData.ContainsKey("messages"))
            {
                (controller.TempData["messages"] as Dictionary<string, string>).Add(identifier, message);
            }
            else
            {
                controller.TempData["messages"] = new Dictionary<string, string>
                {
                    [identifier] = message
                };
            }
        }

        public static void AddMessageFixed(this Controller controller, string identifier, string message)
        {
            if (controller.TempData.ContainsKey("messagesFixed"))
            {
                (controller.TempData["messagesFixed"] as Dictionary<string, string>).Add(identifier, message);
            }
            else
            {
                controller.TempData["messagesFixed"] = new Dictionary<string, string>
                {
                    [identifier] = message
                };
            }
        }
    }
}
