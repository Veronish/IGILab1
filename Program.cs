using System;
using lab1core.Modules;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;


namespace lab1core
{
    class Program
    {
        static void Main(string[] args)
        {
            // CheckContext db = new CheckContext();
            // Initializer.Initialize(db); 

            //            Console.WriteLine("Hello World!");
            using (CheckContext db = new CheckContext())
            {
                Initializer.Initialize(db);
                var inspectors = db.Inspectors.ToList();
                Console.WriteLine("1.	Выборку всех данных из таблицы, стоящей в схеме базы данных нас стороне отношения «один» ");
                foreach (Inspector i in inspectors)
                {
                    PrintInspecror(i);
                }
                Console.WriteLine();

                var violation = db.Violations.Where(p => p.Fine >= 250).ToList();

                Console.WriteLine("2.	Выборку данных из таблицы, стоящей в схеме базы данных нас стороне отношения «один», отфильтрованные по определенному условию, налагающему ограничения на одно или несколько полей");
                foreach (Violation i in violation)
                {
                    PrintViolation(i);
                }
                Console.WriteLine();

                double task3 = db.Violations.Average(p => p.Fine);
                Console.WriteLine("3.	Выборку данных, сгруппированных по любому из полей данных с выводом какого-либо итогового результата (min, max, avg, сount или др.) по выбранному полю из таблицы," +
                    " стоящей в схеме базы данных нас стороне отношения «многие» ");
                Console.WriteLine("Штраф в среднем составляет: " + task3);
                Console.WriteLine();

                Console.WriteLine("4.	Выборку данных из двух полей двух таблиц, связанных между собой отношением «один-ко-многим» ");
                var task4 = from p in db.Inspectors
                            join c in db.Checks on p.InspectorId equals c.InspectorId
                            select new { Name = p.InspectorName, Numder = c.ProtocolNumber };
                foreach (var i in task4)
                {
                    Console.WriteLine("Сотрудник: " + i.Name + " ,номер протокола: " + i.Numder.ToString());
                }
                Console.WriteLine();

                Console.WriteLine("5.	Выборку данных из двух таблиц, связанных между собой отношением «один-ко-многим» и" +
                    " отфильтрованным по некоторому условию, налагающему ограничения на значения одного или нескольких полей ");
                var task5 = from p in db.Inspectors
                            join c in db.Checks on p.InspectorId equals c.InspectorId
                            where p.Unit == "Первое"
                            select new { Name = p.InspectorName, Numder = c.ProtocolNumber };
                foreach (var i in task5)
                {
                    Console.WriteLine("Сотрудник: " + i.Name + " ,номер протокола: " + i.Numder.ToString());
                }
                Console.WriteLine();

                Console.WriteLine("6.	Вставку данных в таблицы, стоящей на стороне отношения «Один»");
                db.Inspectors.Add(new Inspector { InspectorName = "Василий", InspectorSurname = "Крайний", Unit = "Второе" });
                db.SaveChanges();
                inspectors = db.Inspectors.ToList();
                foreach (Inspector i in inspectors)
                {
                    PrintInspecror(i);
                }
                Console.WriteLine();

                Console.WriteLine("7.	Вставку данных в таблицы, стоящей на стороне отношения «Многие» ");
                db.Checks.Add(new Check
                {
                    InspectorId = 1,
                    InterpriseId = 1,
                    ViolationId = 1,
                    Date = DateTime.Now,
                    ProtocolNumber = 99,
                    Responsible = "Ivanovish",
                    Fine = 500,
                    CorrectionPeriod = DateTime.Now 
                
                });
                db.SaveChanges();

                var task7 = db.Checks.ToList();
                foreach (Check i in task7)
                {
                    PrintCheck(i);
                }
                Console.WriteLine();

                Console.WriteLine("8.	Удаление данных из таблицы, стоящей на стороне отношения «Один»");
                db.Inspectors.Remove(db.Inspectors.LastOrDefault());
                db.SaveChanges();

                inspectors = db.Inspectors.ToList();
                foreach (Inspector i in inspectors)
                {
                    PrintInspecror(i);
                }
                Console.WriteLine();

                Console.WriteLine("9.	Удаление данных из таблицы, стоящей на стороне отношения «Многие»");
                db.Checks.Remove(db.Checks.LastOrDefault());
                db.SaveChanges();
                task7 = db.Checks.ToList();
                foreach (Check i in task7)
                {
                    PrintCheck(i);
                }
                Console.WriteLine();

                Console.WriteLine("10.	Обновление удовлетворяющих определенному условию записей в любой из таблиц базы данных ");
                violation = db.Violations.Where(p => p.Fine >= 250).ToList();
                foreach (Violation i in violation)
                {
                    i.Fine = 300;
                }
                db.SaveChanges();

                violation = db.Violations.ToList();
                foreach (Violation i in violation)
                {
                    PrintViolation(i);
                }
                Console.WriteLine();
                Console.ReadKey();
            }






             void PrintInspecror(Inspector inspector)
            {
                Console.WriteLine("Имя: " + inspector.InspectorName + inspector.InspectorSurname + " , Подразделение: " + inspector.Unit);
            }

             void PrintViolation(Violation violation)
            {
                Console.WriteLine("Название Проверки: " + violation.NameViolation +
                    " , Штраф : " + violation.Fine +
                    " , Время исправления: " + violation.CorrectionPeriod);
            }

             void PrintCheck(Check i)
            {
                Console.WriteLine("Инспектор: " + i.Inspector.InspectorName +
                        " ,место проверки: " + i.Interprise.NameInterprise +
                        " ,штраф: " + i.Fine);
            }
        }
    }
}
