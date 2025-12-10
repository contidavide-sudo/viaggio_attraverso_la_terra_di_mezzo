namespace viaggio_attraverso_la_terra_di_mezzo
{
    internal class Program
    {

        static string SceltaPersonaggio(string pers)
        {
            Console.WriteLine("Scelgli un personaggio per intraprendere la storia: ");
            Console.WriteLine();
            Console.WriteLine("------------------------------------");
            Console.WriteLine("|1) Frodo: +5 punti vita            |");
            Console.WriteLine("|2) Sam: +1 danno base              |");
            Console.WriteLine("|3) Merry: +1 probablità di fuga    |");
            Console.WriteLine("------------------------------------");

            pers = Console.ReadLine();

            return pers;

        }

        static int SceltaPerAvanzare(int decisione)
        {
            Console.WriteLine("Digita il numero dell' opzione per scegliere");
            Console.WriteLine();
            Console.WriteLine("------------------------------------------------------------------");
            Console.WriteLine("|1) Tira il dado (puoi avanzare di massimo 4 caselle)            |");
            Console.WriteLine("|2) Mostra status                                                |");
            Console.WriteLine("|3) Mostra inventario                                            |");
            Console.WriteLine("|4) Usa oggetto                                                  |");
            Console.WriteLine("|5) Esci                                                         |");
            Console.WriteLine("------------------------------------------------------------------");

            decisione = Convert.ToInt32(Console.ReadLine());

            return decisione;
        }
        static int LancioDado()
        {
            Random lancio = new Random();
            return lancio.Next(1, 5);
        }
        static void Main(string[] args)
        {
            int vita = 10, scelta = 0, avanzamento, indice = 0 ;
            string personaggio = "";

            string[] Luogo = { "La Contea", "Bosco Atro", "Casa di Tom Bombadil", "Brea", "Colle Vento", "Gran Burrone", "Moria", "Lothlórien", "Fiume Anduin", "Amon Hen", "Fangorn", "Rohan", "Fosso di Helm", "Isengard", "Osgiliath", "Minas Morgul", "Minas Tirith", "Campi del Pelennor", "Cirith Ungol", "Monte Fato" };

            string[] inventario = { "x", "x", "x", "x", "x" };

            personaggio = SceltaPersonaggio(personaggio);

            Console.WriteLine("Hai scelto " + personaggio);

            if (personaggio == "Frodo")
            {
                vita = vita + 5;
            }

            Console.WriteLine();

            Console.WriteLine("Ti trovi a la Contea dove bilbo ti affida l'anello e la missione di distruggerlo al monte fato");

            Console.WriteLine();

            while (vita > 0)
            {
                Console.WriteLine("Cosa vuoi fare ?");

                scelta = SceltaPerAvanzare(scelta);

                Console.WriteLine("Hai scelto opzione " + scelta);

                if (scelta == 1 )
                {
                    avanzamento = LancioDado();

                    Console.WriteLine("Avanzi di " + avanzamento + " caselle");

                    indice = indice + avanzamento;

                    Console.WriteLine();

                    Console.WriteLine("Sei riuscito ad avanzare fino a " + Luogo[indice]);

                }else if(scelta == 2)
                {
                    Console.WriteLine("Vita: " + vita);

                }else if(scelta == 3)
                {
                    for(int i = 0; i < inventario.Length; i++)
                    {
                        Console.Write("[" + inventario[i] + "]"); 
                    }

                }else if(scelta == 4)
                {

                }else if(scelta == 5)
                {
                    vita = 0;
                    Console.WriteLine("Sei uscito dal gioco");
                }
            }


            
        }
    }
}
