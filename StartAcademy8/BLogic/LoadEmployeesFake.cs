using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DbHandler.DataModels;

namespace StartAcademy8.BLogic
{
    public static class LoadEmployeesData
    {
        public static List<Employee> Get()
        {
            var employeeData = new[]
            {
                "I001; Mario Rossi; Impiegato; Ufficio Acquisti; 49; Largo Uvia 69; Roma; Roma; 00000; 123456789",
                "P001; Sigismondo Della Rotula; Operario; Assemblaggio Motore; 40; Via dell'Acino 341; Milano; MI; 11111; 9809876",
                "F021; Erminia Satollà; Impiegato; Ufficio Controllo Qualità; 37; Piazza Plutone 12; Milano; MI; 00001; 11223344",
                "F022; Eloisia Significata; Operaio; Addetta Servizio Mensa; 51; Piazza Salamandra 29; Milano; MI; 00002; 4433",
                "R002; Geppo Il Folle; Operaio; Addetto Servizio Mensa; 45; Cala delle Sirene 44; Messina; ME; 03000; 12039124",
                "R025; Porfirio Cecato; Impiegato; Contabilita; 38; Viale Guerrieri della Galassia 8; Bergamo; BG; 20002; 39335",
                "M154; Jenny Sapone; Impiegato; Contabilita; 47; Piazzetta dei Puffi 721; Venezia; Venezia; 00003; 00998810",
                "T098; Vespasiano Titillo; Operaio; Manutenzione; 42; Viottolo delle CImici Profumate 1000; Roma; Roma; 00000; 3303942",
                "S027; Gianno Pocuciu; Operaio; Manutenzione; 50; Via dei Licantropi Spaventati 8887; Matera; MT; 01000; 28230"
            };


            var workDayData = new[]
                    {
                "07/10/2023; Pre Festivo; 4; I001",
                "09/10/2023; Ufficio; 10; I001",
                "10/10/2023; Ufficio; 8; I001",
                "11/10/2023; Ferie; 4; I001",
                "12/10/2023; Ufficio; 8; I001",
                "13/10/2023; Ufficio; 9; I001",
                "07/10/2023; Pre Festivo; 6; P001",
                "09/10/2023; Ferie; 9; P001",
                "10/10/2023; Ufficio; 8; P001",
                "11/10/2023; Ufficio; 8; P001",
                "12/10/2023; Trasferta; 13; P001",
                "13/10/2023; Trasferta; 9; P001",
                "09/10/2023; Sede; 8; F022",
                "10/10/2022; Sede; 8; F022",
                "11/10/2022; Sede; 8; F022",
                "12/10/2022; Sede; 8; F022",
                "13/10/2023; Sede; 8; F022"
            };


            var employees = employeeData.Select(data =>
            {
                var parts = data.Split(';').Select(p => p.Trim()).ToArray();
                return new Employee
                {
                    Enrollment = parts[0],
                    FullName = parts[1],
                    Role = parts[2],
                    Department = parts[3],
                    Age = int.Parse(parts[4]),
                    Address = parts[5],
                    City = parts[6],
                    Province = parts[7],
                    Cap = parts[8],
                    Phone = parts[9],
                    WorkDays = []
                };
            }).ToList();


            var workDays = workDayData.Select((data, index) =>
            {
                var parts = data.Split(';').Select(p => p.Trim()).ToArray();
                return new WorkDay
                {
                    ID = index + 1,
                    ActivityDate = DateTime.ParseExact(parts[0], "dd/MM/yyyy", null),
                    JobType = parts[1],
                    TotalHours = int.Parse(parts[2]),
                    Enrollment = parts[3]
                };
            }).ToList();


            //LinQ

            foreach (var employee in employees)
            {
                employee.WorkDays = [.. workDays.Where(wd => wd.Enrollment == employee.Enrollment)];
            }

            return employees;
        }
    }
}
