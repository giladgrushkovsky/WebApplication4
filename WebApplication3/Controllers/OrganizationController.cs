using MessageServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication3.Controllers
{
    public class OrganizationController : Controller
    {

        private IOrganizationservice _Organizationservice;

        public OrganizationController(IOrganizationservice organizationservice)
        {
            _Organizationservice = organizationservice;
        }

        [HttpGet]
        [AllowAnonymous]
        public JsonResult GetWorkers()
        {
            return Json(_Organizationservice.GetWorkerList().ToList(), JsonRequestBehavior.AllowGet);

        }

        
    }
}