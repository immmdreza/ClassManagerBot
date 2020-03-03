using LiteDB;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static CManagerBot.Datebases.Objects;

namespace CManagerBot.Datebases
{
    class Methods
    {
        /// <summary>
        /// Main location of data base
        /// </summary>
        private static string DB_LOCATION = @"C:\Languege\ClassDB.db";

        public async static Task<SuperAdmin> AddNewSuperAdmin(int telegram_id)
        {
            return await Task.Run(() =>
            {
                using (var db = new LiteDatabase(DB_LOCATION))
                {
                    // Get a collection (or create, if doesn't exist)
                    var col = db.GetCollection<SuperAdmin>("classes");

                    if (col.FindOne(a => a.Telegramid == telegram_id) is SuperAdmin s)
                    {
                        return s;
                    }

                    // Create your new customer instance
                    var c = new SuperAdmin
                    {
                        Telegramid = telegram_id
                    };

                    // Insert new customer document (Id will be auto-incremented)
                    col.Insert(c);
                    return c;
                }
            });
        }

        public async static Task<bool> CheckSuperAdmin(int telegram_id)
        {
            return await Task.Run(() =>
            {
                using (var db = new LiteDatabase(DB_LOCATION))
                {
                    // Get a collection (or create, if doesn't exist)
                    var col = db.GetCollection<SuperAdmin>("classes");

                    // Insert new customer document (Id will be auto-incremented)
                    return col.Exists(x=>x.Telegramid == telegram_id);
                }
            });
        }


        /// <summary>
        /// Add new class to database
        /// </summary>
        /// <param name="owner_id">telegram id of it's owner</param>
        /// <param name="class_name">name of class</param>
        /// <param name="teacher">a teacher object</param>
        /// <param name="start_time">start time</param>
        /// <param name="is_open">is class contents are open yet or not</param>
        /// <returns></returns>
        public async static Task<Class> AddNewClass(int owner_id, string class_name, Teacher teacher, DateTime start_time, bool is_open = true)
        {
            return await Task.Run(() =>
            {
                using (var db = new LiteDatabase(DB_LOCATION))
                {
                    // Get a collection (or create, if doesn't exist)
                    var col = db.GetCollection<Class>("classes");

                    // Create your new customer instance
                    var c = new Class
                    {
                        OwnerId = owner_id,
                        StartTime = start_time,
                        Name = class_name,
                        IsOpen = is_open,
                        EndTime = start_time.AddHours(1).AddMinutes(30),
                        Sections = null,
                        Students = null,
                        Teacher = teacher
                    };

                    // Insert new customer document (Id will be auto-incremented)
                    col.Insert(c);
                    return c;
                }
            });
        }
        /// <summary>
        /// Get a class using it's name
        /// </summary>
        /// <param name="class_name">name of the class</param>
        /// <returns></returns>,
        public async static Task<Class> GetClass(string class_name)
        {
            return await Task.Run(() =>
            {
                using (var db = new LiteDatabase(DB_LOCATION))
                {
                    var col = db.GetCollection<Class>("classes");

                    return col.FindOne(x => x.Name == class_name);
                }
            });
        }
    }
}
