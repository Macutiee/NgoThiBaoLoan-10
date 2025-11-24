using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week01_QLSV
{
    internal class Student
    {

        public string studentId { get; set; }
        public string fullName { get; set; }
        public double averageScore { get; set; }
        public string faculty { get; set; }

        public Student() { }
        public Student(string studentId, string fullName, double averageScore, string faculty)
        {
            this.studentId = studentId;
            this.fullName = fullName;
            this.averageScore = averageScore;
            this.faculty = faculty;
        }
        public void Input()
        {
            Console.Write("Nhập MSSV:");
            studentId = Console.ReadLine();
            Console.Write("Nhập họ tên:");
            fullName = Console.ReadLine();
            Console.Write("Nhập điểm trung bình (0–10):");
            averageScore = double.Parse(Console.ReadLine()); 

            Console.Write("Nhập khoa:");
            faculty = Console.ReadLine();
        }
        public void Show()
        {
            Console.WriteLine($"MSSV: {studentId,-4}  |  Họ tên: {fullName, -20}  |  Khoa: {faculty, -10}  |  Điểm trung bình: {averageScore, -4}");
        }
        public string Rank()
        {
            if (averageScore >= 9) return "Xuất sắc";
            else if (averageScore >= 8) return "Giỏi";
            else if (averageScore >= 7) return "Khá";
            else if (averageScore >= 5) return "Trung bình";
            else if (averageScore >= 4) return "Yếu";
            else return "Kém";
        }
    }
}
