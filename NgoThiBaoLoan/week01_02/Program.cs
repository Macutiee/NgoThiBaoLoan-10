using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace week01_QLSV
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            List<Student> studentList = new List<Student>()
            {
                new Student ("SV01", "Nguyen Ban Mai", 8.5, "CNTT"),
                new Student ("SV02", "Ngo Van Bao", 9.5, "Marketing"),
                new Student ("SV03", "Nguyen Thuy Linh", 2.0, "Tài chính"),
                new Student ("SV04", "Tran Tuyet Tung", 7.75, "CNTT"),
                new Student ("SV05", "Vu Hong Ngoc", 6.25, "Ngân hàng"),
                new Student ("SV06", "Mai Khang", 4.5, "Marketing"),
            };

            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("---- MENU ----");
                Console.WriteLine("1. Thêm sinh viên");
                Console.WriteLine("2. Hiển thị danh sách sinh viên");
                Console.WriteLine("3. Hiển thị sinh viên theo khoa(tự nhập)");
                Console.WriteLine("4. Hiển thị sinh viên có điểm trung bình >= 5");
                Console.WriteLine("5. Sắp xếp sinh viên theo điểm trung bình tăng dần");
                Console.WriteLine("6. Hiển thị sinh viên điểm trung bình >= 5 và khoa (tự nhập)");
                Console.WriteLine("7. Hiển thị sinh viên điểm trung bình cao nhất theo khoa (tự nhập)");
                Console.WriteLine("8. Thống kê theo xếp loại [Xuất sắc, Giỏi, Khá, Trung bình, Yếu, Kém]");
                Console.WriteLine("0. Thoát");
                Console.Write("Chọn chức năng (0-8): ");

                string choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        AddStudent(studentList);
                        break;

                    case "2":
                        DisplayStudentList(studentList);
                        break;

                    case "3":
                        Console.Write("Nhập tên khoa cần tìm: ");
                        string faculty = Console.ReadLine();
                        DisplayStudentsByFaculty(studentList, faculty);
                        break;

                    case "4":
                        DisplayStudentsScore5(studentList);
                        break;

                    case "5":
                        SortStudentsByScore(studentList);
                        break;

                    case "6":
                        Console.Write("Nhập khoa: ");
                        string f1 = Console.ReadLine();
                        DisplayScore5AndFaculty(studentList, f1);
                        break;

                    case "7":
                        Console.Write("Nhập khoa: ");
                        string f2 = Console.ReadLine();
                        DisplayMaxScoreByFaculty(studentList, f2);
                        break;

                    case "8":
                        CountRank(studentList);
                        break;

                    case "0":
                        exit = true;
                        Console.WriteLine("Kết thúc chương trình.");
                        break;

                    default:
                        Console.WriteLine("Tùy chọn không hợp lệ!");
                        break;
                }

                Console.WriteLine();
            }
        }

        static void AddStudent(List<Student> studentList)
        {
            Console.WriteLine("---- Nhập thông tin sinh viên ----");
            Student student = new Student();
            student.Input();
            studentList.Add(student);
            Console.WriteLine("Thêm sinh viên thành công!");
        }

        static void DisplayStudentList(List<Student> list)
        {
            if (list.Count == 0)
            {
                Console.WriteLine("Danh sách rỗng.");
                return;
            }

            Console.WriteLine("---- Danh sách sinh viên ----");
            foreach (Student student in list)
            {
                student.Show();
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

            DisplayStudentList(result);
        }

        static void DisplayStudentsScore5(List<Student> list)
        {
            var result = list.Where(s => s.averageScore >= 5).ToList();
            DisplayStudentList(result);
        }

        static void SortStudentsByScore(List<Student> list)
        {
            var sorted = list.OrderBy(s => s.averageScore).ToList();
            DisplayStudentList(sorted);
        }

        static void DisplayScore5AndFaculty(List<Student> list, string faculty)
        {
            var result = list
                .Where(s => s.averageScore >= 5 && s.faculty.Equals(faculty, StringComparison.OrdinalIgnoreCase)).ToList();

            DisplayStudentList(result);
        }

        static void DisplayMaxScoreByFaculty(List<Student> list, string faculty)
        {
            var sameFaculty = list
                .Where(s => s.faculty.Equals(faculty, StringComparison.OrdinalIgnoreCase))
                .ToList();

            if (!sameFaculty.Any())
            {
                Console.WriteLine("Không có sinh viên thuộc khoa này.");
                return;
            }

            double maxScore = sameFaculty.Max(s => s.averageScore);
            var top = sameFaculty.Where(s => s.averageScore == maxScore).ToList();

            Console.WriteLine($"--- Sinh viên có điểm TB cao nhất khoa {faculty} ---");
            DisplayStudentList(top);
        }

        static void CountRank(List<Student> list)
        {
            var groups = list.GroupBy(s => s.Rank());

            Console.WriteLine("---- Thống kê theo xếp loại ----");
            Console.WriteLine("[10 đến 9]: Xuất sắc \n(9 đến 8]: Giỏi \n(8 đến 7]: Khá \n(7 đến 5]: Trung bình \n(5 đến 4]: Yếu \n(Dưới 4,0): Kém\n\n");
            foreach (var g in groups)
            {
                Console.WriteLine($"{g.Key}: {g.Count()} sinh viên");
            }
        }
    }
}
