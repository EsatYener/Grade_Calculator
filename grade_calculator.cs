using System;
using System.Linq;

namespace consoleapp7
{
    class exam
    {
        static void Main(string[] args)
        {
            bool a = true;
            while (a)
            {
                Console.Write("Giriş için H,h ya da çıkış için E,e: "); //H,h:işlem yapmak için, E,e:Çıkış yapmak için
                string islem = Console.ReadLine();
                if (islem == "H" || islem == "h")
                {
                    Console.Write("Ders adı: ");
                    string lesson_name = Console.ReadLine();
                    Console.Write("Kaç sınav: ");
                    string sinavstr = Console.ReadLine();
                    int sinav;
                    while (!int.TryParse(sinavstr, out sinav) || (sinav <= 0))
                    {
                        Console.Write("Sınav sayısı 0 veya 0'dan küçük olamaz.Yeniden giriniz: ");
                        sinavstr = Console.ReadLine();
                    }
                    int notes = 0;
                    int total_percentage = 0;
                    int[] percentage_list = new int[sinav];
                    int[] notes_list = new int[sinav];
                    for (int i = 0; i < sinav - 1; i++)
                    {
                        Console.WriteLine(lesson_name.ToUpper() + " " + $"Percentage {i + 1}: ");
                        string percstr = Console.ReadLine();
                        int percentage;

                        while (!int.TryParse(percstr, out percentage) || (percentage < 0) || (total_percentage + percentage >= 100) || ((i + 1 != sinav && percentage + total_percentage == 99)))
                        {
                            Console.Write("Yüzde değeriniz 100'den büyük, yeniden giriniz:  ");
                            percstr = Console.ReadLine();
                        }
                        Console.WriteLine(lesson_name.ToUpper() + " " + $"Notes {i + 1}: ");
                        percentage_list[i] = percentage;
                        total_percentage += percentage;
                        string kosul = Console.ReadLine();
                        while (!int.TryParse(kosul, out notes) || (notes > 101 || notes < 0))
                        {
                            Console.Write("101'den küçük bir değer veya 0'dan büyük bir değer giriniz: ");
                            kosul = Console.ReadLine();
                        }
                        notes_list[i] = notes;
                    }

                    Console.WriteLine(lesson_name.ToUpper() + " " + $"Notes {sinav}: ");
                    percentage_list[sinav - 1] = 100 - total_percentage;

                    string kosul1 = Console.ReadLine();
                    while (!int.TryParse(kosul1, out notes) || (notes > 101 || notes < 0))
                    {
                        Console.WriteLine("101'den küçük bir değer veya 0'dan büyük bir değer giriniz: ");
                        kosul1 = Console.ReadLine();
                    }
                    notes_list[sinav - 1] = notes;


                    int sum1 = 0; //YÜZDELERİN TOPLAMI
                    foreach (int item in percentage_list)
                    {
                        sum1 += item;
                    }

                    if (sum1 != 100)
                    {
                        string kosul2 = Console.ReadLine();
                        while (!int.TryParse(kosul2, out sum1) || (sum1 != 100))
                        {
                            Console.WriteLine("Yüzde toplamınız:" + sum1 + "." + "Yüzde 100'e eşit olmalıdır.");
                            kosul2 = Console.ReadLine();
                        }
                    }

                    int sum2 = 0; //SON TOPLAM

                    for (int i = 0; i < notes_list.Length; i++)
                    {
                        sum2 += (percentage_list[i] * notes_list[i]) / 100;
                    }
                    string grade = "";

                    if (sum2 >= 95)
                    {
                        grade = "A1";
                    }
                    if (sum2 >= 90 && sum2 < 95)
                    {
                        grade = "A2";
                    }
                    if (sum2 >= 85 && sum2 < 90)
                    {
                        grade = "A3";
                    }
                    if (sum2 >= 80 && sum2 < 85)
                    {
                        grade = "B1";
                    }
                    if (sum2 >= 75 && sum2 < 80)
                    {
                        grade = "B2";
                    }
                    if (sum2 >= 70 && sum2 < 75)
                    {
                        grade = "B3";
                    }
                    if (sum2 >= 65 && sum2 < 70)
                    {
                        grade = "C1";
                    }
                    if (sum2 >= 60 && sum2 < 65)
                    {
                        grade = "C2";
                    }
                    if (sum2 >= 55 && sum2 < 60)
                    {
                        grade = "C3";
                    }
                    if (sum2 >= 50 && sum2 < 55)
                    {
                        grade = "D";
                    }
                    if (sum2 < 50)
                    {
                        grade = "F";
                    }
                    if (sum2 >= 50)
                    {
                        Console.WriteLine("Son not toplamı: " + sum2 + "," + "Harf notunuz: " + grade +"geçti");

                    }
                    else if (sum2 < 50)
                    {
                        Console.WriteLine("Son not toplamı: " + sum2 + "," + "Harf notunuz: " + grade + "kaldı");

                    }
                }

                else if (islem == "E" || islem == "e")
                {
                    Console.WriteLine("Çıkış yapılıyor.");
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("Hatalı giriş, lütfen tekrar giriniz. Giriş için H,h ya da çıkış için E,e: ");
                }
            }

        }
    }
}