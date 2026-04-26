using System;
using System.IO;
using System.Text.Json;

namespace TP_MODUL9_103022400043
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string json = File.ReadAllText("covid_config.json");
            CovidConfig config = JsonSerializer.Deserialize<CovidConfig>(json);

            Console.WriteLine("Berapa suhu badan anda saat ini? Dalam nilai " + config.satuan_suhu);
            double suhu = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Berapa hari yang lalu (perkiraan) anda terakhir memiliki gejala demam?");
            int hari = Convert.ToInt32(Console.ReadLine());

            bool suhuNormal = false;

            if (config.satuan_suhu.ToLower() == "celcius")
            {
                if (suhu >= 36.5 && suhu <= 37.5)
                    suhuNormal = true;
            }
            else
            {
                if (suhu >= 97.7 && suhu <= 99.5)
                    suhuNormal = true;
            }

            if (suhuNormal && hari < config.batas_hari_demam)
                Console.WriteLine(config.pesan_diterima);
            else
                Console.WriteLine(config.pesan_ditolak);

            config.UbahSatuan();

            Console.WriteLine("Satuan suhu sekarang: " + config.satuan_suhu);
        }
    }
}