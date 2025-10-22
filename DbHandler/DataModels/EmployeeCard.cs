using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbHandler.DataModels;


namespace DbHandler.DataModels
{
    public class EmployeeCard
    {
        public Tuple<string, string, string, int, int, DateTime?> Get(List<Employee> employees, string enrollment)
        {
            // metodi "standard" per la soluzione delle attività del giorno 07.10.2025
            //Employee employee1 = new Employee();

            //foreach (Employee emp in employees)
            //{
            //    if (emp.Enrollment == enrollment)
            //    {
            //        employee1 = emp;
            //        break;
            //    }
            //}

            //if (employee1 == null)
            //    return null;

            //int totalHoursWorked = 0;
            //foreach (var workDay in employee1.WorkDays)
            //{
            //    totalHoursWorked += workDay.TotalHours;
            //}

            //int daysAttended = employee1.WorkDays.Count;
            //// COme posso, tramite iterazione trovare la data più alta, ovvero l'ultima data di lavoro?
            //// Sfida?

            //int daysAttendance1 = 0;
            //foreach (var workDay in employee1.WorkDays)
            //{
            //    daysAttendance1++;
            //}

            Employee employee = employees.Find(e => e.Enrollment == enrollment);
            
            if (employee != null)
            {
                int daysAttendance = employee?.WorkDays.Count ?? 0;
                int totalHours = employee?.WorkDays.Sum(wd => wd.TotalHours) ?? 0;
                DateTime? lastDayWork = employee?.WorkDays
                    .OrderByDescending(wd => wd.ActivityDate)
                    .FirstOrDefault()?.ActivityDate;

                return new Tuple<string, string, string, int, int, DateTime?>(
                    employee.Enrollment,
                    employee.FullName,
                    employee.Role,
                    daysAttendance,
                    totalHours,
                    lastDayWork
                );
            }
            else
                return null;
        }
    }
}
