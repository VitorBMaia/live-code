using Case.TorneioDeLutas.DBZ.App.Domain;
using Case.TorneioDeLutas.DBZ.App.Domain.Enums;
using Case.TorneioDeLutas.DBZ.App.Handlers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Case.TorneioDeLutas.DBZ.App
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Torneio de Lutas BDZ! yay");
            Console.WriteLine();

            const int LIMITE_DE_LUTADORES = 8;
            var lutadores = new List<Lutador>();
            lutadores.AddRange(GetHumanos());
            lutadores.AddRange(GetSayajins());
            lutadores.AddRange(GetNamekuseijins());

            var torneio = new Torneio(lutadores);
            var vencedor = torneio.ExecutarTorneio();

            Console.WriteLine("Vencedor do Torneio de Lutas - DBZ");

            Console.WriteLine(vencedor.Nome);
            Console.ReadKey();
        }
        private static IList<Lutador> GetHumanos()
        {
            using (var reader = new StreamReader(Path.Combine("json", "humanos.json")))
            {
                var json = reader.ReadToEnd();

                return JsonConvert.DeserializeObject<List<Lutador>>(json);
            }
        }

        private static IList<Lutador> GetSayajins()
        {
            using (var reader = new StreamReader(Path.Combine("json", "saiyajins.json")))
            {
                var json = reader.ReadToEnd();

                return JsonConvert.DeserializeObject<List<Lutador>>(json);
            }
        }

        private static IList<Lutador> GetNamekuseijins()
        {
            using (var reader = new StreamReader(Path.Combine("json", "namekuseijins.json")))
            {
                var json = reader.ReadToEnd();

                return JsonConvert.DeserializeObject<List<Lutador>>(json);
            }
        }

    }
}
