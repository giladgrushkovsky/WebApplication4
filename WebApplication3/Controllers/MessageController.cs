using MessageServices;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http.Cors;
using System.Web.Mvc;


namespace WebApplication3.Controllers
{
    public class MessgeInfo
    {
        public int Id { get; set; }
        public string message { get; set; }
    }
    [EnableCors(origins: "", headers: "", methods: "*")]
    public class MessageController : Controller
    {


        private IMessageService _messageService;
        public MessageController(IMessageService MessageService )
        {
            _messageService = MessageService;
          

        }

        [HttpGet]

        public JsonResult getMessages(int id)
        {
            var data = _messageService.GetMessages(id);
            if(data == null)
            {
                data = new List<string>();
            }
            return Json(data,JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult sendMessage([System.Web.Http.FromBody] MessgeInfo info)
        {
            _messageService.SendMessage(info.Id,info.message);
            return new HttpStatusCodeResult( HttpStatusCode.OK);
        }
        
        
    }
}
