using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace week01_KeThua
{
    internal class Teacher : Person
    {
        public string address { get; set; }

        public Teacher() { }

        public Teacher(string id, string name, string address) : base(id, name)
        {
            this.address = address;
        }

        public void Input()
        {
            Console.Write("Nhập mã giáo viên: ");
            Id = Console.ReadLine();

            Console.Write("Nhập họ tên: ");
            fullName = Console.ReadLine();

            Console.Write("Nhập địa chỉ: ");
            address = Console.ReadLine();
        }
    }
}
