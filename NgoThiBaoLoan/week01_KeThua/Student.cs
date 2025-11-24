using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace week01_KeThua
{
    internal class Student : Person
    {
        public double averageScore { get; set; }
        public string faculty { get; set; }

        public Student() { }

        public Student(string id, string name, double averageScore, string faculty) : base(id, name)
        {
            this.averageScore = averageScore;
            this.faculty = faculty;
        }

        public void Input()
        {
            Console.Write("Nhập mã số sinh viên: ");
            Id = Console.ReadLine();

            Console.Write("Nhập họ tên: ");
            fullName = Console.ReadLine();

            Console.Write("Nhập điểm trung bình (0–10): ");
            averageScore = double.Parse(Console.ReadLine());

            Console.Write("Nhập khoa: ");
            faculty = Console.ReadLine();
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
