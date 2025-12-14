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
            Console.WriteLine("|2) Sam: +1 danno                   |");
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

        static int EventoCasuale()
        {

            Random lancio = new Random();
            return lancio.Next(1, 4);

        }

        static int Combattimento(int puntiVita, int dannoBase, string[] inv)
        {
            int vitaNem = 8;

            while (vitaNem > 0 || puntiVita > 0)
            {
                Console.WriteLine("Cosa vuoi utilizzare per combattere?");

                for (int i = 0; i < inv.Length; i++) {

                    Console.WriteLine("[" + inv[i] + "]");
                
                }
              
            }        
        }
        static void Main(string[] args)
        {
            int vita = 10, danno = 2, scelta = 0, avanzamento, indice = 0, evento, sceltaNem;
            string personaggio = "";

            string[] Luogo = { "La Contea", "Bosco Atro", "Casa di Tom Bombadil", "Brea", "Colle Vento", "Gran Burrone", "Moria", "Lothlórien", "Fiume Anduin", "Amon Hen", "Fangorn", "Rohan", "Fosso di Helm", "Isengard", "Osgiliath", "Minas Morgul", "Minas Tirith", "Campi del Pelennor", "Cirith Ungol", "Monte Fato" };

            string[] inventario = { "Spada", "x", "x", "x", "x" };

            personaggio = SceltaPersonaggio(personaggio);

            Console.WriteLine("Hai scelto " + personaggio);

            if (personaggio == "Frodo")
            {
                vita = vita + 5;
            }
            else if(personaggio == "Sam")
            {
                danno = danno + 1;
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

                    evento = EventoCasuale();

                    if(evento == 1)
                    {

                        Console.WriteLine("Un Nazgul ti ha trovato e ti sta attaccando, vuoi ingaggiare un combattimento(1) o tentare la fuga(2)?"); 
                        sceltaNem=Convert.ToInt32(Console.ReadLine());

                        if(sceltaNem == 1)
                        {

                        }



                    }
                    else if(evento == 2)
                    {
                        Console.WriteLine("Durante il tuo viaggio hai incontrato ");
                    } 
                    else
                    {
                        Console.WriteLine("Hai trovato un oggetto");
                    }

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
