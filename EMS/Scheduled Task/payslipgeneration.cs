using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Quartz;
using System.Net.Http;
using System.Threading.Tasks;

namespace EMS.Scheduled_Task
{
    public class payslipgeneration : IJob
    {
        public static List<EMPLOYEE> employees;
        public static List<ALLOCATEDALLOWANCES> allocallowances;
        public static List<ALLOWANCES> allowances;
        public static List<JOBTITLE> jobtitle;
        public static List<ATTENDANCE> attendance;
        



        public void Execute(IJobExecutionContext context)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(Global.URIstring);


            var responseTaskAllocated = client.GetAsync("AllocatedAllowances");
            responseTaskAllocated.Wait();

            var resultAllocated = responseTaskAllocated.Result;
            if (resultAllocated.IsSuccessStatusCode)
            {

                var readTaskAllocated = resultAllocated.Content.ReadAsAsync<ALLOCATEDALLOWANCES[]>();
                readTaskAllocated.Wait();

                allocallowances = readTaskAllocated.Result.ToList();
            }

            var responseTaskEmployee = client.GetAsync("Employees");
            responseTaskEmployee.Wait();

            var resultEmployee = responseTaskEmployee.Result;
            if (resultEmployee.IsSuccessStatusCode)
            {

                var readTaskEmployee = resultEmployee.Content.ReadAsAsync<EMPLOYEE[]>();
                readTaskEmployee.Wait();

                employees = readTaskEmployee.Result.ToList();
            }


            var responseTaskJobTitle = client.GetAsync("JobTitle");
            responseTaskJobTitle.Wait();

            var resultJobTitle = responseTaskJobTitle.Result;
            if (resultJobTitle.IsSuccessStatusCode)
            {

                var readTaskJobTitle = resultJobTitle.Content.ReadAsAsync<JOBTITLE[]>();
                readTaskJobTitle.Wait();

                jobtitle = readTaskJobTitle.Result.ToList();
            }

            var responseTaskAttendance = client.GetAsync("Attendance");
            responseTaskAttendance.Wait();

            var resultAttendance = responseTaskAttendance.Result;
            if (resultAttendance.IsSuccessStatusCode)
            {

                var readTaskAttendance = resultAttendance.Content.ReadAsAsync<ATTENDANCE[]>();
                readTaskAttendance.Wait();

                attendance = readTaskAttendance.Result.ToList();
            }

            var responseTaskAllowances = client.GetAsync("Allowances");
            responseTaskAllowances.Wait();

            var resultAllowances = responseTaskAllowances.Result;
            if (resultAllowances.IsSuccessStatusCode)
            {

                var readTaskAllowances = resultAllowances.Content.ReadAsAsync<ALLOWANCES[]>();
                readTaskAllowances.Wait();

                allowances = readTaskAllowances.Result.ToList();
            }
            foreach (EMPLOYEE e in employees)
            {
                PAYMENTRECORD pr = new PAYMENTRECORD();

                pr.PaymentMonth = DateTime.Today.Month;
                pr.PaymentYear = DateTime.Today.Year;
                pr.EmployeeId =e.EmployeeId;
                pr.JobTitle = jobtitle.Find(jt =>jt.JobTitleId == e.JobtitleId).JobTitleName;

                int basicallowanceid = allowances.Find(al => al.AllowanceName.Equals("Basic") && al.JobTitleId == e.JobtitleId).AllowanceId;
                int basicSalary = allocallowances.Find(al => al.AllowanceId == basicallowanceid && al.EmployeeId.Equals(e.EmployeeId)).Salary.Value;
                
                int hrallowanceid = allowances.Find(al => al.AllowanceName.Equals("House Rent") && al.JobTitleId == e.JobtitleId).AllowanceId;
                int hrSalary = allocallowances.Find(al => al.AllowanceId == hrallowanceid && al.EmployeeId.Equals(e.EmployeeId)).Salary.Value;

                int travelallowanceid = allowances.Find(al => al.AllowanceName.Equals("Travel") && al.JobTitleId == e.JobtitleId).AllowanceId;
                int travelSalary = allocallowances.Find(al => al.AllowanceId == travelallowanceid && al.EmployeeId.Equals(e.EmployeeId)).Salary.Value;

                pr.BasicPay = basicSalary;
                pr.HRA =hrSalary;
                pr.TA =travelSalary;
                pr.OtherAllowances =0;
                pr.EPF = 5 * basicSalary/100;
                if (basicSalary > 50000)
                    pr.Tax = basicSalary*10/100;
                else
                    pr.Tax = 0;
                pr.Absence =0;

                var postTask = client.PostAsJsonAsync<PAYMENTRECORD>("PaymentRecord",pr);
                postTask.Wait();

                var result = postTask.Result;
            }

        }
    }
}