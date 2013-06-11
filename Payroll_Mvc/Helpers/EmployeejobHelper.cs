﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Domain.Model;
using Payroll_Mvc.Models;

namespace Payroll_Mvc.Helpers
{
    public class EmployeejobHelper
    {
        public static Employeejob GetObject(Employee e, FormCollection fc)
        {
            string paramJoindate = GetParam("join_date", fc);
            DateTime joindate = CommonHelper.GetDateTime(paramJoindate);

            string paramConfirmdate = GetParam("confirm_date", fc);
            DateTime confirmdate = CommonHelper.GetDateTime(paramConfirmdate);

            string paramDesignationid = GetParam("designation_id", fc);
            Designation des = string.IsNullOrEmpty(paramDesignationid) || paramDesignationid == "0" ? null : new Designation();

            string paramDepartmentid = GetParam("department_id", fc);
            Department dept = string.IsNullOrEmpty(paramDepartmentid) || paramDepartmentid == "0" ? null : new Department();

            string paramEmploymentstatusid = GetParam("employment_status_id", fc);
            Employmentstatus es = string.IsNullOrEmpty(paramEmploymentstatusid) || paramEmploymentstatusid == "0" ? null : new Employmentstatus();

            string paramJobcategoryid = GetParam("job_category_id", fc);
            Jobcategory jobcat = string.IsNullOrEmpty(paramJobcategoryid) || paramJobcategoryid == "0" ? null : new Jobcategory();

            if (des != null)
                des.Id = Convert.ToInt32(paramDesignationid);

            if (dept != null)
                dept.Id = Convert.ToInt32(paramDepartmentid);

            if (es != null)
                es.Id = Convert.ToInt32(paramEmploymentstatusid);

            if (jobcat != null)
                jobcat.Id = Convert.ToInt32(paramJobcategoryid);

            Employeejob o = e.Employeejob;

            if (o == null)
            {
                o = new Employeejob();
                o.Id = e.Id;
            }

            o.Designation = des;
            o.Department = dept;
            o.Employmentstatus = es;
            o.Jobcategory = jobcat;
            o.Joindate = joindate;
            o.Confirmdate = confirmdate;

            return o;
        }

        public static bool IsEmptyParams(FormCollection fc)
        {
            if (GetParam("designation_id", fc) == "0" && GetParam("department_id", fc) == "0" &&
                GetParam("employment_status_id", fc) == "0" && GetParam("job_category_id", fc) == "0" &&
                string.IsNullOrEmpty(GetParam("join_date", fc)) &&
                string.IsNullOrEmpty(GetParam("confirm_date", fc)))
                return true;

            return false;
        }

        private static string GetParam(string key, FormCollection fc)
        {
            return fc.Get(string.Format("employee_job[{0}]", key));
        }
    }
}