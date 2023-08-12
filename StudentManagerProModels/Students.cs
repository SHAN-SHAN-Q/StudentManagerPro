using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagerProModels
{
    /// <summary>
    /// 学员实体类
    /// </summary>
    public class Students
    {
        private int studentId;

        private string studentName;

        private DateTime birthday;

        private string gender;

        private string studentIdNo;

        private int age;

        private string stuImage;

        private string phoneNumber;

        private string studentAddress;

        private string carNo;

        private int classId;

        private string className;

        public int StudentId { get => studentId; set => studentId = value; }
        public string StudentName { get => studentName; set => studentName = value; }
        public DateTime Birthday { get => birthday; set => birthday = value; }
        public string Gender { get => gender; set => gender = value; }
        public string StudentIdNo { get => studentIdNo; set => studentIdNo = value; }
        public int Age { get => age; set => age = value; }
        public string StuImage { get => stuImage; set => stuImage = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public string StudentAddress { get => studentAddress; set => studentAddress = value; }
        public string CarNo { get => carNo; set => carNo = value; }
        public int ClassId { get => classId; set => classId = value; }
        public string ClassName { get => className; set => className = value; }
    }
}
