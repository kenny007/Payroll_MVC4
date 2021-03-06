﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Payroll_Mvc.Helpers;
using Payroll_Mvc.Attributes;

namespace Payroll_Mvc.Areas.User.Controllers
{
    [Authorize]
    [AuthUser]
    public class UserController : Controller
    {
        //
        // GET: /User/User/

        public ActionResult Index()
        {
            object id = Session["employee_id"];
            ViewBag.employee_salary = EmployeesalaryHelper.Find(id);
            ViewBag.pay_type = ViewBag.employee_salary.Paytype;

            return View();
        }
    }
}
