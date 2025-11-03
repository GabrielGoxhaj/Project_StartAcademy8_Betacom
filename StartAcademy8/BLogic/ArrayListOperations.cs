using DbHandler.DataModels;
using DbHandler.Models;

namespace StartAcademy8.BLogic
{
    public class ArrayListOperations
    {

        public void Run(List<Employee> employees)
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

            Console.Clear();
            Console.WriteLine("Operazioni su List Interi");
            Console.WriteLine(new string('-', 50));

            List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };
            // Add an element
            numbers.Add(6);
            // Remove an element
            numbers.Remove(3);
            // Find an element
            bool containsFour = numbers.Contains(4);
            // Sort the list
            numbers.Sort();
            // Print the elements
            foreach (var number in numbers)
            {
                Console.WriteLine(number);
            }
            Employee? employee = new();
            employee = employees.Find(emp => emp.Enrollment.Equals(
                    "r025", StringComparison.CurrentCultureIgnoreCase));

            Console.WriteLine();
            Console.WriteLine($"Nominativo del Dipendente con Matricola R025: " +
                $"{employee.FullName} ");

            var foundMilanEmployee = employees.FindAll(emps =>
            emps.City.Contains("mila", StringComparison.CurrentCultureIgnoreCase));

            Console.WriteLine($"Totale Dipendenti Sede Milano: {foundMilanEmployee.Count}");

            foundMilanEmployee.ForEach(employees => Console.WriteLine(
                employees.FullName));

            var foundMilanEmployeeUnder40 = employees.FindAll(emps =>
            emps.City.Contains("mila", StringComparison.CurrentCultureIgnoreCase)
            && emps.Age <= 40);
            foundMilanEmployeeUnder40.ForEach(emps => Console.WriteLine(
                emps.FullName + " - " + emps.Age));

            Console.WriteLine("OK LE LISTE, E PER GLI ARRAY?");
            int[] myNumbers = { 10, 20, 30, 780, 131, 17, 51, 80, 40 };
            Console.WriteLine($"La somma dei numeri dell'array è: {myNumbers.Sum()}");
            Console.WriteLine($"La media dei numeri dell'array è: {myNumbers.Average()}");
            Console.WriteLine($"Numero min/max dei numeri dell'array è: {myNumbers.Min()} - {myNumbers.Max()}");
            List<int> pairNumbers = myNumbers.ToList().FindAll(num => (num % 2) == 0);
            Console.WriteLine($"Numeri pari dell'array: {string.Join(",", pairNumbers)}");

            Console.WriteLine(new string('-', 100));
            Console.WriteLine("RAGRUPPAMENTO DIPENDENTI CHE HANNO LAVORATO IL 13 OTTOBRE 2023");
            Console.WriteLine(new string('-', 100));

            DateTime dtWork = new(2023, 10, 13);
            var employeesByWorkedDate = employees.Where(emp => emp.WorkDays.Any(wd => wd.ActivityDate == dtWork));

            foreach (Employee emp in employeesByWorkedDate)
            {
                Console.WriteLine($"Matricola: {emp.Enrollment} - Nominativo: {emp.FullName} ");
                foreach (WorkDay workDay in emp.WorkDays.Where(wd => wd.ActivityDate == dtWork))
                {
                    Console.WriteLine($"Attività: {workDay.JobType} - Data reale: " +
                        $"{workDay.ActivityDate:dd/MM/yyyy HH:mm:ss} - {dtWork}");
                }
            }

            Console.WriteLine(new string('-', 100));
            Console.WriteLine("RAGRUPPAMENTO E CONTEGGIO DIPENDENTI PER CITTA' RESIDENZA");
            Console.WriteLine(new string('-', 100));
            var employeesByCity = employees.GroupBy(x => x.City).ToList();

            foreach (var group in employeesByCity)
            {
                Console.WriteLine($"Totale per gruppo: {group.Key} - {group.Count()}");
                foreach (Employee emp in group)
                {
                    Console.WriteLine($"Nominativo: {emp.FullName}");
                }
            }


            Console.WriteLine(new string('-', 100));
            Console.WriteLine("ESTRARRE I NOMINATIVI DI ETA' COMPRESA TRA I 40 E I 50 ANNI [MODO STANDARD]");
            Console.WriteLine(new string('-', 100));

            Console.WriteLine("1) Età 40–50:");
            for (int i = 0; i < employees.Count; i++)
            {
                var e = employees[i];
                if (e.Age >= 40 && e.Age <= 50)
                    Console.WriteLine("   - " + e.FullName);
            }

            Console.WriteLine(new string('-', 100));
            Console.WriteLine("ESTRARRE I NOMINATIVI DI ETA' COMPRESA TRA I 40 E I 50 ANNI");
            Console.WriteLine(new string('-', 100));

            var Employee40_50 = employees
           .FindAll(e => e.Age >= 40 && e.Age <= 50)
           .ConvertAll(e => e.FullName);
            Console.WriteLine("1) Età 40–50:");
            Employee40_50.ForEach(n => Console.WriteLine("   - " + n));

            Console.WriteLine(new string('-', 100));
            Console.WriteLine("ESTRARRE I NOMINATIVI DI COLORO CHE HANNO FATTO FERIE");
            Console.WriteLine(new string('-', 100));

            string jType = "Ferie";
            var employeesByHolliday = employees.Where(emp => emp.WorkDays.Any(wd => wd.JobType == jType));

            foreach (Employee emp in employeesByWorkedDate)
            {
                Console.WriteLine($"Matricola: {emp.Enrollment} - Nominativo: {emp.FullName} ");
                foreach (WorkDay workDay in emp.WorkDays.Where(wd => (wd.JobType ?? "").Trim().Equals(jType, StringComparison.OrdinalIgnoreCase)))
                {
                    Console.WriteLine($"{workDay.JobType} ({workDay.ActivityDate:dd/MM/yyyy})");
                }
            }

            Console.WriteLine(new string('-', 100));
            Console.WriteLine("ESTRARRE I NOMINATIVI DI COLORO CHE HANNO FATTO FERIE [VARIANTE DUE]");
            Console.WriteLine(new string('-', 100));

            Dictionary<string, List<WorkDay>> workDayByEnroll = new(StringComparer.OrdinalIgnoreCase);
            List<WorkDay> employeeWorkedDays;

            foreach (Employee employee1 in employees)
            {
                employeeWorkedDays = [];
                foreach (WorkDay workDay in employee1.WorkDays)
                {
                    employeeWorkedDays.Add(workDay);
                }
                workDayByEnroll.Add(employee1.Enrollment, employeeWorkedDays);
            }

            var hollidayNames = employees.FindAll(e =>
             workDayByEnroll.TryGetValue(e.Enrollment, out var days)
             && days.Exists(d => string.Equals((d.JobType ?? "").Trim(), "Ferie", StringComparison.OrdinalIgnoreCase))
            ).ConvertAll(e => e.FullName);
            Console.WriteLine("\n2) Hanno fatto FERIE:");
            hollidayNames.ForEach(n => Console.WriteLine("   - " + n));


            Console.WriteLine(new string('-', 100));
            Console.WriteLine("ESTRARRE I NOMINATIVI DI COLORO CHE HANNO FATTO FERIE [VARIANTE TRE]");
            Console.WriteLine(new string('-', 100));

            var hollidayNames3 = employees.FindAll(e =>
            workDayByEnroll.TryGetValue(e.Enrollment, out var days)
                && days.Exists(d =>
                string.Equals((d.JobType ?? "").Trim(), "Ferie", StringComparison.OrdinalIgnoreCase))
);

            Console.WriteLine("\n2) Hanno fatto FERIE:");
            foreach (var e in hollidayNames3)
            {
                Console.WriteLine($"   - {e.FullName}");

                // Estrae tutte le date di ferie di quell’impiegato
                if (workDayByEnroll.TryGetValue(e.Enrollment, out var days))
                {
                    var ferieDays = days.FindAll(d =>
                        string.Equals((d.JobType ?? "").Trim(), "Ferie", StringComparison.OrdinalIgnoreCase));
                    ferieDays.ForEach(d =>
                        Console.WriteLine($"       * {d.ActivityDate:dd/MM/yyyy}"));
                }
            }

            Console.WriteLine(new string('-', 100));
            Console.WriteLine("RAGGRUPPAMENTO E CONTEGGIO PER CITTA' E ATTIVITA'");
            Console.WriteLine(new string('-', 100));

            var countCityDept = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
            employees.ForEach(e =>
            {
                var key = (e.City ?? "ND") + " | " + (e.Department ?? "ND");
                if (!countCityDept.ContainsKey(key)) countCityDept[key] = 0;
                countCityDept[key]++;
            });
            Console.WriteLine("\n6) Count per Città + Attività");
            foreach (var kv in countCityDept)
                Console.WriteLine($"   - {kv.Key}: {kv.Value}");

            Console.WriteLine(new string('-', 100));
            Console.WriteLine("ESTRARRE ORE TOTALI IMPIEGATO PER ATTIVITA [VERSIONE UNO]");
            Console.WriteLine(new string('-', 100));

            var hoursByJobType = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);

            employees.ForEach(e =>
            {
                if (workDayByEnroll.TryGetValue(e.Enrollment, out var days))
                {
                    days.ForEach(d =>
                    {
                        var job = d.JobType ?? "ND";
                        if (!hoursByJobType.ContainsKey(job))
                            hoursByJobType[job] = 0;

                        hoursByJobType[job] += d.TotalHours;
                    });
                }
            });

            Console.WriteLine("\n7) Ore totali per JobType");
            foreach (var kv in hoursByJobType)
                Console.WriteLine($"   - {kv.Key}: {kv.Value}h");


            Console.WriteLine(new string('-', 100));
            Console.WriteLine("ESTRARRE ORE TOTALI IMPIEGATO PER ATTIVITA [VERSIONE DUE]");
            Console.WriteLine(new string('-', 100));

            var hoursByJobType2 = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
            var daysByJobType = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);

            employees.ForEach(e =>
            {
                if (workDayByEnroll.TryGetValue(e.Enrollment, out var days))
                {
                    days.ForEach(d =>
                    {
                        var job = d.JobType ?? "ND";

                        if (!hoursByJobType2.ContainsKey(job))
                            hoursByJobType2[job] = 0;
                        if (!daysByJobType.ContainsKey(job))
                            daysByJobType[job] = 0;

                        hoursByJobType2[job] += d.TotalHours;
                        daysByJobType[job] += 1;
                    });
                }
            });

            Console.WriteLine("\n7) Ore totali e giorni per JobType");
            foreach (var job in hoursByJobType.Keys)
            {
                var ore = hoursByJobType[job];
                var giorni = daysByJobType.TryGetValue(job, out var cnt) ? cnt : 0;
                Console.WriteLine($"   - {job}: {ore}h / {giorni} giorni");
            }

            //Console.WriteLine(new string('-', 100));
            //Console.WriteLine("ESTRARRE ORE TOTALI IMPIEGATO PER ATTIVITA [VERSIONE TRE]");
            //Console.WriteLine(new string('-', 100));

            Console.WriteLine(new string('-', 100));
            Console.WriteLine("RAGGRUPPAMENTO IMPIEGATI PER FASCIA ETA' (DA 20 A 70 ANNI, RANGE 10 ANNI)");
            Console.WriteLine(new string('-', 100));

            // 8) Raggruppamento per Fascia Età (20–70, step 10 anni)
            var peopleByAgeBand = new Dictionary<string, List<string>>(StringComparer.OrdinalIgnoreCase);
            employees.ForEach(e =>
            {
                var band = GetAgeBand(e.Age);
                if (band == "") return;
                if (!peopleByAgeBand.ContainsKey(band))
                    peopleByAgeBand[band] = new List<string>();
                peopleByAgeBand[band].Add(e.FullName);
            });

            Console.WriteLine("\n8) Fasce Età (20–70, step 10)");
            string[] order = { "20-29", "30-39", "40-49", "50-59", "60-69", "70" };
            Array.ForEach(order, b =>
            {
                if (peopleByAgeBand.TryGetValue(b, out var list))
                {
                    Console.WriteLine($"   - {b} ({list.Count})");
                    list.ForEach(name => Console.WriteLine("       * " + name));
                }
            });

            Console.WriteLine(new string('-', 100));
            Console.WriteLine(" ESTRARRE I NOMINATIVI DI COLORO CHE HANNO FATTO FERIE [LINQ PURO]");
            Console.WriteLine(new string('-', 100));

            var holidayEmployees =
                employees.Where(emp => emp.WorkDays.Any(wd => wd.Enrollment == emp.Enrollment
                && string.Equals(wd.JobType ?? "", "Ferie", StringComparison.CurrentCultureIgnoreCase)))
                .Select(e => e.FullName);

            foreach (string name in holidayEmployees)
            {
                Console.WriteLine($"Nominativo: {name}");
            }

            Console.WriteLine(new string('-', 100));
            Console.WriteLine(" ESTRARRE I NOMINATIVI, DATA, ORE DI COLORO CHE HANNO FATTO FERIE [LINQ PURO]");
            Console.WriteLine(new string('-', 100));


            var holidayEmployeesFull =
                employees
                .Select(emp => new
                {
                    emp.Enrollment,
                    emp.FullName,
                    wDetails = emp.WorkDays
                    .Where(wd => string.Equals(wd.JobType ?? "", "Ferie", StringComparison.CurrentCultureIgnoreCase))
                    .Select(wd => new
                    {
                        wd.ActivityDate,
                        wd.TotalHours,
                    })
                })
                .Where(emp => emp.wDetails.Any());

            foreach (var emp in holidayEmployeesFull)
            {
                Console.WriteLine($"Matricola: {emp.Enrollment} - Nominativo: {emp.FullName} ");
                foreach (var workDay in emp.wDetails)
                {
                    Console.WriteLine($"Data: {workDay.ActivityDate:dd/MM/yyyy} - Ore: {workDay.TotalHours}");
                }
            }

            Console.WriteLine(new string('-', 100));
            Console.WriteLine(" RAGGRUPPAMENTO LISTA     [LINQ PURO]");
            Console.WriteLine(new string('-', 100));

            //var EmployeesGroupCity =
            //    employees
            //    .GroupBy(emp => emp.City)
            //    .Select(e => new
            //        {
            //            e. }
            //    );



            var ics = from emps in employees
                      where emps != null
                      select emps;

            var ipsilon = from emps in employees
                          from wd in emps.WorkDays
                          where wd.JobType.ToLower() == "ferie"
                          select emps;
        }

        static string GetAgeBand(int age)
        {
            if (age < 20 || age > 70) return "";
            if (age == 70) return "70";
            int start = Math.Max(20, Math.Min(60, (age / 10) * 10));
            return $"{start}-{start + 9}";
        }


    }
}
