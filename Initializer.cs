using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace lab1core
{
    public class Initializer
    {
        public static void Initialize(CheckContext db)
        {
            if (db.Interprises.Any())
            {
                return;
            }

            Random rnd = new Random();


            string[] names = {"Александр", "Алексей", "Анатолий", "Андрей", "Антон", "Аркадий",
            "Артём", "Богдан", "Борис", "Вадим", "Валентин", "Валерий", "Василий", "Виктор", "Виталий", "Владимир",
            "Владислав", "Вячеслав", "Гавриил", "Геннадий", "Георгий", "Глеб", "Григорий", "Даниил", "Данила", "Денис",
            "Дмитрий", "Евгений", "Егор", "Кирилл", "Иван", "Игорь", "Илья", "Иннокентий", "Лев", "Леонид", "Максим",
            "Матвей", "Михаил", "Никита", "Николай", "Олег", "Павел", "Пётр", "Роман", "Ростислав", "Руслан", "Семён",
            "Святослав", "Сергей", "Станислав", "Степан", "Тимофей", "Тимур", "Фёдор", "Филипп", "Эдуард", "Юрий", "Яков", "Ярослав" };
           
            string[] surnames = { "Смирнов", "Иванов", "Кузнецов", "Новиков", "Морозов", "Петров", "Павлов",
            "Семёнов", "Богданов", "Воробьёв", "Тарасов", "Белов", "Киселёв", "Макаров", "Андреев", "Ковалёв", "Ильин",
            "Гусев", "Титов", "Кузьмин", "Кудрявцев", "Баранов", "Куликов", "Алексеев", "Степанов", "Яковлев", "Сорокин",
            "Сергеев", "Романов", "Захаров", "Борисов", "Королёв", "Герасимов", "Пономарёв", "Григорьев", "Лазарев", "Ершов",
            "Никитин", "Соболев", "Рябов", "Цветков", "Данилов", "Журавлёв", "Николаев", "Крылов", "Максимов", "Сидоров",
            "Осипов", "Белоусов", "Федотов", "Дорофеев", "Егоров", "Матвеев", "Бобров", "Дмитриев", "Анисимов", "Антонов",
            "Тимофеев", "Никифоров", "Веселов", "Филиппов", "Марков", "Большаков", "Суханов", "Миронов", "Ширяев", "Александров",
            "Коновалов", "Шестаков", "Казаков", "Громов", "Фомин", "Давыдов", "Мельников", "Щербаков", "Блинов", "Колесников",
            "Афанасьев", "Власов", "Исаков", "Тихонов", "Аксёнов", "Родионов", "Котов", "Зуев", "Панов", "Рыбаков", "Абрамов",
            "Воронов", "Мухин", "Архипов", "Трофимов", "Горшков", "Овчинников", "Панфилов", "Копылов", "Лобанов", "Лукин", "Беляков",
            "Потапов" };

            string[] unit = {"Первое", "Второе", "Главное", "Запасное", "Поддержка" };

            string[] nameViolation = {"Антисанитария", "неуплата налогов", "нарушение ТБ", "нарушение пожарной безопастности", "нарушение условий труда" };

            string[] nameInterprise = { "ОАО\'Бергамот\'", "ОАО\"Мория\"", "ОАО \"Августовский\"", "ОАО \"Последний шанс\"", "ООО \"Какие люди\"", "ООО \"Моя оборона\"", "ООО \"Паньки\"", "ООО \"Откат\"" };

            string[] formOfOwership = {"Государственная","Коллективная","Частная" };

            string[] adress = { "пр. Октября", "пр. Речицкий", "ул. Барыкина", "пр. Ленина", "ул. Советская", "ул. Косарева", "ул. Веры Хоружей", "ул. Бабушкина" };

            string[] bossInfo = { "Адекватный", "Неадекватный", "Можно договориться"," слишком честный", "недалекий", "хитрый", "осторожный", "порядочный"};

            int countInspectors = 10;
            string name;
            string surname;
            string unitt; 

            for (int i = 0; i < countInspectors; i++)
            {
               
                name = names[rnd.Next(names.Length)];
                surname = surnames[rnd.Next(surnames.Length)];
                unitt = unit[rnd.Next(unit.Length)];

                db.Inspectors.Add(new Modules.Inspector { InspectorName = name, InspectorSurname = surname, Unit = unitt });
            }
            db.SaveChanges();

            int violationCount = 10;
            string nv;

            for (int i = 0; i < violationCount; i++)
            {
                DateTime start = new DateTime(2018, 1, 1);
                int range = (DateTime.Today - start).Days;

                nv = nameViolation[rnd.Next(nameViolation.Length)];

                db.Violations.Add(new Modules.Violation
                {
                    NameViolation = nv,
                    Fine = rnd.Next(500),
                    CorrectionPeriod = start.AddDays(rnd.Next(range)),
                });
            }
            db.SaveChanges();

            int coutnInterprise = 10;

            for (int i = 0; i < coutnInterprise; i++)
            {

                db.Interprises.Add(new Modules.Interprise
                {
                    NameInterprise = nameInterprise[rnd.Next(nameInterprise.Length)],
                    FormOfOwership = formOfOwership[rnd.Next(formOfOwership.Length)],
                    Adress = adress[rnd.Next(adress.Length)] + ((rnd.Next(150) + 10).ToString()),
                    BossInfo = bossInfo[rnd.Next(bossInfo.Length)]
                    
                });
            }
            db.SaveChanges();

            int countCheck = 10;

            for (int i = 0; i < countCheck; i++)
            {
                DateTime start = new DateTime(2018, 1, 1);
                int range = (DateTime.Today - start).Days;

                db.Checks.Add(new Modules.Check
                {
                    InspectorId = rnd.Next(1, countInspectors - 1),
                    InterpriseId = rnd.Next(1, coutnInterprise - 1),
                    ViolationId = rnd.Next(1, violationCount - 1),
                    Date = start.AddDays(rnd.Next(range)),
                    ProtocolNumber = rnd.Next(150),
                    Responsible = names[rnd.Next(names.Length)] + surnames[rnd.Next(surnames.Length)],
                    Fine = rnd.Next(1500),
                    CorrectionPeriod = start.AddDays(rnd.Next(range))

                });
            }
            db.SaveChanges();



        }

    }
}
