using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Quartz;
using System.Net.Http;
using System.Threading.Tasks;

namespace EMS.Scheduled_Task
{
    public class Job : IJob
    {
        public static EMPLOYEE[] employees;
        public static HOLIDAYS[] holidays;
        public static LEAVES[] leaves;
        public static EMPLOYEELEAVES[] empleaves;
        public void Execute( IJobExecutionContext context)
        {
            int flag = 0;
            var client = new HttpClient();
            client.BaseAddress = new Uri(Global.URIstring);

            
            
            //HTTP GET method for holiday
            var responseTaskHoliday = client.GetAsync("Holiday");
            responseTaskHoliday.Wait();

            var resultHoliday = responseTaskHoliday.Result;
            if (resultHoliday.IsSuccessStatusCode)
            {

                var readTaskHoliday = resultHoliday.Content.ReadAsAsync<HOLIDAYS[]>();
                readTaskHoliday.Wait();

                holidays = readTaskHoliday.Result;
            }


            //update holiday_date if it repeat annually on next day after holiday 
            foreach(var holiday in holidays)
            {
                if((holiday.HolidayDate < DateTime.Today) && (holiday.RepeatedAnnually > 0))
                {
                    holiday.HolidayDate = holiday.HolidayDate.AddYears(1);
                    var updateTask = client.PutAsJsonAsync("Holiday/" + holiday.HolidayId.ToString(), holiday);
                    updateTask.Wait();

                    var result = updateTask.Result;
                }
                if (holiday.HolidayDate == DateTime.Today)
                    flag = 1;
            }



            //HTTP GET method for employee
            var responseTaskEmployee = client.GetAsync("Employees");
            responseTaskEmployee.Wait();

            var resultEmployee = responseTaskEmployee.Result;
            if (resultEmployee.IsSuccessStatusCode)
            {

                var readTaskEmployee = resultEmployee.Content.ReadAsAsync<EMPLOYEE[]>();
                readTaskEmployee.Wait();

                employees = readTaskEmployee.Result;
            }
            //mark all employee's attendance as absent at begining of every day

            //  if(flag==0)
            //  {
            foreach (var employee in employees)
            {
                ATTENDANCE attendance = new EMS.ATTENDANCE();
                attendance.EmployeeId = employee.EmployeeId;
                attendance.PunchInDate = DateTime.Today;
                attendance.WorkingHours = 0;

                var postTask = client.PostAsJsonAsync("Attendance", attendance);
                postTask.Wait();

                var result = postTask.Result;
            }
            //  }


            
            
            //HTTP GET method for holiday
            var responseTaskLeave = client.GetAsync("Leave");
            responseTaskLeave.Wait();

            var resultLeave = responseTaskLeave.Result;
            if (resultLeave.IsSuccessStatusCode)
            {

                var readTaskLeave = resultLeave.Content.ReadAsAsync<LEAVES[]>();
                readTaskLeave.Wait();

                leaves = readTaskLeave.Result;
            }

            foreach(var leave in leaves)
            {
                if(leave.StartDate==DateTime.Today && (leave.LeaveStatus.Equals("Approved") || leave.LeaveStatus.Equals("Pending")))
                {
                    if (leave.LeaveStatus.Equals("Approved"))
                        leave.LeaveStatus = "Consumed";
                    else if (leave.LeaveStatus.Equals("Pending"))
                        leave.LeaveStatus = "Cancelled";
                    if(leave.LeaveStatus.Equals("Cancelled"))
                    {
                        
                        var responseTask = client.GetAsync("EmployeeLeaves?employeeid=" + leave.EmployeeId +"&leavetypeid=" + leave.LeavetypeId.ToString());
                        responseTask.Wait();

                        var result = responseTask.Result;
                        if (result.IsSuccessStatusCode)
                        {

                            var readTask = result.Content.ReadAsAsync<EMPLOYEELEAVES[]>();
                            readTask.Wait();

                            empleaves = readTask.Result;
                        }
                        foreach(var empleave in empleaves)
                        {
                            if(empleave.EmployeeId.Equals(leave.EmployeeId) && empleave.LeaveTypeId==leave.LeavetypeId )
                            {
                                empleave.NumberOfLeaves = empleave.NumberOfLeaves - leave.NumberOfDays;
                                //HTTP PUT
                                string url = "EmployeeLeaves?employeeid=" + empleave.EmployeeId + "&leavetypeid=" + empleave.LeaveTypeId;
                                var update = client.PutAsJsonAsync(url, empleave);
                                update.Wait();

                                var r = update.Result;
                                break;
                            }
                        }
                        
                    }
                    var updateTask = client.PutAsJsonAsync("Leave?leaveid=" + leave.LeaveId, leave);
                    updateTask.Wait();

                    var updateresult = updateTask.Result;
                }
            }
            
            
            
            
            
            
        }
    }       
}

