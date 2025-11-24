using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week01_DoanSo
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("---- Chương trình đoán số ----");
            Console.WriteLine("(Luật: Mỗi người chơi chỉ có 7 lượt đoán)\n");
            Random rd = new Random();
            int tgNum = rd.Next(100, 999);
            string tgString = tgNum.ToString();

            int temp = 1, MAX_GUESS = 7;
            string guess, fb = "";
            while (fb != "+++" && temp <= MAX_GUESS)
            {
                Console.WriteLine("Lần đoán thứ {0}: ", temp);  
                guess = Console.ReadLine();
                fb = getFeedback(tgString, guess);
                Console.WriteLine("Phản hồi: {0}", fb);
                temp++;
            }
            Console.WriteLine("Bạn đã dùng hết {0} lượt. Trò chơi kết thúc!", temp - 1);
            if (fb == "+++")
            {
                Console.WriteLine("Bạn đã thắng roài! Xin chúc mừng");
            }
            else
            {
                Console.WriteLine("Bạn thua rùi. Số phải đoán là: {0}", tgNum);
            }
            Console.ReadLine();
        }

        static string getFeedback(string tg, string guess)
        {
            if (guess.Length != tg.Length)
                return "---";

            string fb = "";
            for (int i = 0; i < tg.Length; i++)
            {
                if (tg[i] == guess[i])
                {
                    fb += "+";
                }
                else if (tg.Contains(guess[i]))
                {
                    fb += "?";
                }
                else
                {
                    fb += "-";
                }
            }
            return fb;
        }
    }
}
