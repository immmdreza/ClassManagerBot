using System;
using System.Collections.Generic;
using System.Text;

namespace CManagerBot.Datebases
{
    class Objects
    {
        public class SuperAdmin
        {
            public int Id { get; set; }
            public int Telegramid { get; set; }
        }
        /// <summary>
        /// A class object
        /// </summary>
        public class Class
        {
            public int Id { get; set; }
            public int OwnerId { get; set; }
            public string Name { get; set; }
            public DateTime StartTime { get; set; }
            public DateTime EndTime { get; set; }
            public bool IsOpen { get; set; }
            public List<Student> Students { get; set; }
            public List<Section> Sections { get; set; }
            public Teacher Teacher { get; set; }
        }
        /// <summary>
        /// A student informations
        /// </summary>
        public class Student
        {
            //public int StudentId { get; set; }
            public string Fullname { get; set; }
            public int TelegramId { get; set; }
            public string TelegramUsername { get; set; }
            public bool StartingPresent { get; set; }
            public bool EndingPresent { get; set; }
            public bool ExtraPoint { get; set; }
        }
        /// <summary>
        /// The teacher of section or class
        /// </summary>
        public class Teacher
        {
            //public int TeacherId { get; set; }
            public string Fullname { get; set; }
            public int TelegramId { get; set; }
            public string TelegramUsername { get; set; }
        }
        /// <summary>
        /// Every Section of a class
        /// </summary>
        public class Section
        {
            //public int SectionId { get; set; }
            public string SectionName { get; set; }
            public string Descriptions { get; set; }
            public Teacher teacher { get; set; }
            public int DownloadTime { get; set; }
            public List<Content> Contents { get; set; }
        }
        /// <summary>
        /// Contents of a sections that may contains files
        /// </summary>
        public class Content
        {
            //public int ContentId { get; set; }
            public string ContentName { get; set; }
            public string Text { get; set; }
            public string FileID { get; set; }
            public string Type { get; set; }
        }
    }
}
