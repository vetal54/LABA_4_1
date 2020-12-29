using System;
using System.IO;
using System.Threading.Tasks;

namespace LR4Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            string s1;
            string s2;
            int a;
            int b;
            int tempMultiply=new Int32();
            long sum=0;
            int nGood=0;
            for (int i = 10; i < 30; i++)
            {
                string path = @"C:\Users\user\source\repos\LR4Task1\LR4Task1\TXTs\" + i+".txt";
                try
                {
                    StreamReader f = new StreamReader(path);
                    s1 = f.ReadLine();
                    a = Convert.ToInt32(s1);
                    s2 = f.ReadLine();
                    b = Convert.ToInt32(s2);
                    checked
                    {
                        tempMultiply = a * b;
                    }
                    Console.WriteLine("Добуток чисел у файлі " + i + ".txt" + " становить: " + tempMultiply);
                    sum += tempMultiply;
                    nGood++;
                    f.Close();
                }
                catch (System.IO.FileNotFoundException)
                {
                    using (StreamWriter no_file = new StreamWriter(@"C:\Users\user\source\repos\LR4Task1\LR4Task1\TXTs\no_file.txt", true, System.Text.Encoding.Default))
                    {
                        no_file.WriteLine(i+".txt");
                    }
                }
                catch(System.FormatException)
                {
                    using (StreamWriter bad_data = new StreamWriter(@"C:\Users\user\source\repos\LR4Task1\LR4Task1\TXTs\bad_data.txt", true, System.Text.Encoding.Default))
                    {
                        bad_data.WriteLine(i + ".txt");
                    }
                }
                catch (System.OverflowException)
                {
                    using (StreamWriter overflow = new StreamWriter(@"C:\Users\user\source\repos\LR4Task1\LR4Task1\TXTs\overflow.txt", true, System.Text.Encoding.Default))
                    {
                        overflow.WriteLine(i + ".txt");
                    }
                }
                catch (System.IO.IOException)
                {
                   Console.WriteLine("Немає доступу до файлу. Можливо його вже було створено");
                   break;
                }
            }
            Console.WriteLine("Всього нормальних файлів {0}. Середнє арифметичне добутку двох чисел з цих файлів складає {1}", nGood, sum/(double)nGood);
            Console.ReadKey();
        }
    }
}
