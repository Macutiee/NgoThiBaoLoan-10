using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week01_KeThua
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            List<Student> students = new List<Student>()
            {
                new Student("SV01", "Nguyen Ban Mai", 8.5, "CNTT"),
                new Student("SV02", "Ngo Van Bao", 9.5, "Marketing"),
                new Student("SV03", "Nguyen Thuy Linh", 2.0, "Tài chính"),
                new Student("SV04", "Tran Tuyet Tung", 7.75, "CNTT"),
                new Student("SV05", "Vu Hong Ngoc", 6.25, "Ngân hàng"),
                new Student("SV06", "Mai Khang", 4.5, "Marketing"),
            };

            List<Teacher> teachers = new List<Teacher>()
            {
                new Teacher("GV01", "Tran Van Duc", "Phước Long, Quận 9"),
                new Teacher("GV02", "Nguyen Minh Huy", "Thủ Đức"),
                new Teacher("GV03", "Phan Le Ha", "Quận 9"),
                new Teacher("GV04", "Bui Tran", "Bình Thạnh"),
                new Teacher("GV05", "Phan Do Quyen", "Phú Nhuận"),
                new Teacher("GV06", "Ngo Quang Thanh", "Phú Nhuận"),
            };

            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("---- MENU ----");
                Console.WriteLine("1. Thêm sinh viên");
                Console.WriteLine("2. Thêm giáo viên");
                Console.WriteLine("3. Xuất danh sách sinh viên");
                Console.WriteLine("4. Xuất danh sách giáo viên");
                Console.WriteLine("5. Số lượng từng danh sách");
                Console.WriteLine("6. Hiển thị sinh viên thuộc khoa (tự nhập)");
                Console.WriteLine("7. Giáo viên có địa chỉ chứa 'Quận 9'");
                Console.WriteLine("8. Sinh viên điểm TB cao nhất theo khoa (tự nhập)");
                Console.WriteLine("9. Số lượng từng xếp loại");
                Console.WriteLine("0. Thoát");
                Console.Write("Chọn chức năng: ");

                string c = Console.ReadLine();
                Console.WriteLine();

                switch (c)
                {
                    case "1":
                        AddStudent(students);
                        break;

                    case "2":
                        AddTeacher(teachers);
                        break;

                    case "3":
                        DisplayStudents(students);
                        break;

                    case "4":
                        DisplayTeachers(teachers);
                        break;

                    case "5":
                        Console.WriteLine($"Tổng sinh viên: {students.Count}");
                        Console.WriteLine($"Tổng giáo viên: {teachers.Count}");
                        break;

                    case "6":
                        Console.Write("Nhập khoa: ");
                        string f1 = Console.ReadLine();
                        DisplayStudentsByFaculty(students, f1);
                        break;

                    case "7":
                        var teachersInQ9 = teachers.Where(t => !string.IsNullOrEmpty(t.address) && t.address.IndexOf("Quận 9", StringComparison.OrdinalIgnoreCase) >= 0).ToList();
                        DisplayTeachers(teachersInQ9);
                        break;

                    case "8":
                        Console.Write("Nhập khoa: ");
                        string f2 = Console.ReadLine();
                        DisplayTopStudentsByFaculty(students, f2);
                        break;
                    case "9":
                        CountRank(students);
                        break;

                    case "0":
                        exit = true;
                        break;

                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ!");
                        break;
                }

                Console.WriteLine();
            }
        }

        static void AddStudent(List<Student> list)
        {
            Student s = new Student();
            s.Input();
            list.Add(s);
        }

        static void AddTeacher(List<Teacher> list)
        {
            Teacher t = new Teacher();
            t.Input();
            list.Add(t);
        }

        static void DisplayStudents(List<Student> list)
        {
            if (!list.Any())
            {
                Console.WriteLine("Danh sách trống.");
                return;
            }

            Console.WriteLine($"{"Mã SV",-10} | {"Họ tên",-20} | {"Khoa",-15} | {"Điểm TB",-10} | {"Xếp loại",-12}");

            foreach (var s in list)
            {
                Console.WriteLine($"{s.Id,-10} | {s.fullName,-20} | {s.faculty,-15} | {s.averageScore,-10:F2} | {s.Rank(),-12}");
            }
        }

        static void DisplayTeachers(List<Teacher> list)
        {
            if (!list.Any())
            {
                Console.WriteLine("Danh sách trống.");
                return;
            }

            Console.WriteLine($"{"Mã GV",-10} | {"Họ tên",-20} | {"Địa chỉ",-20}");

            foreach (var t in list)
            {
                Console.WriteLine($"{t.Id,-10} | {t.fullName,-20} | {t.address,-20}");
            }

        }

        static void CountRank(List<Student> list)
        {
            var groups = list.GroupBy(s => s.Rank());

            Console.WriteLine("---- Thống kê theo xếp loại ----");
            foreach (var g in groups)
            {
                Console.WriteLine($"{g.Key}: {g.Count()} sinh viên");
            }
        }
        static void DisplayStudentsByFaculty(List<Student> list, string faculty)
        {
            var result = list
                .Where(s => s.faculty.Equals(faculty, StringComparison.OrdinalIgnoreCase))
                .ToList();

            if (!result.Any())
            {
                Console.WriteLine("Không có sinh viên thuộc khoa này.");
                return;
            }

            DisplayStudents(result);
        }
        static void DisplayTopStudentsByFaculty(List<Student> list, string faculty)
        {
            var result = list
                .Where(s => s.faculty.Equals(faculty, StringComparison.OrdinalIgnoreCase))
                .ToList();

            if (!result.Any())
            {
                Console.WriteLine("Không có sinh viên thuộc khoa này.");
                return;
            }

            double maxScore = result.Max(s => s.averageScore);
            var topStudents = result.Where(s => s.averageScore == maxScore).ToList();

            DisplayStudents(topStudents);
        }
    }
}
