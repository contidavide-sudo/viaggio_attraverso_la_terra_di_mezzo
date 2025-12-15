namespace viaggio_attraverso_la_terra_di_mezzo
{
    internal class Program
    {

        static string SceltaPersonaggio(string pers)
        {
            Console.WriteLine("Scelgli un personaggio per intraprendere la storia, digita il numero per scegliere: ");
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
        static int LancioDado(int contatoreCav)
        {
            Random rnd = new Random();
            int lancio = rnd.Next(1, 5);

            if (contatoreCav > 0)
            {
                return lancio = lancio + 1;
            }
            else
            {
                return lancio;
            }            
        }

        static int EventoCasuale()
        {

            Random lancio = new Random();
            return lancio.Next(1, 4);

        }

        static int Combattimento(int puntiVita, int dannoBase, string[] inv)
        {
            int vitaNem = 6;
            int sceltaArma;
            
            while (vitaNem > 0 && puntiVita > 0)
            {                
                do
                {
                    Console.WriteLine("Cosa vuoi utilizzare per combattere?");

                    for (int i = 0; i < inv.Length; i++)
                    {

                        Console.Write("[" + (i+1) + ")" + inv[i] + "]");

                    }
                    sceltaArma = Convert.ToInt32(Console.ReadLine());

                } while (sceltaArma >= inv.Length );

                int danno = dannoBase;

                if(sceltaArma == 1)//spada
                {
                    danno = danno + 1;

                    vitaNem = vitaNem - danno;
                }
                else if(sceltaArma == 2)//arco magico
                {
                    danno = danno + 2;

                    vitaNem = vitaNem - danno;
                }
                else if (sceltaArma == 3)//pozione del fuoco
                {
                    danno = danno + 3;

                    vitaNem = vitaNem - danno;
                }
                else if(sceltaArma == 4)//pozione della morte
                {
                    danno = vitaNem;

                    vitaNem = vitaNem - danno;
                }
                else if(sceltaArma == 6)//mani nude
                {
                    vitaNem = vitaNem - danno;
                }
                else if(sceltaArma == 5)//pozione di cura
                {
                    if (puntiVita + 5 > 10)
                    {
                        puntiVita = 10;
                    }
                    else
                    {
                        puntiVita = puntiVita + 5;
                    }
                }

                puntiVita = puntiVita - 2;

                Console.WriteLine();
                Console.WriteLine("Vita propia: " + puntiVita);
                Console.WriteLine();
                if (vitaNem >= 0)
                {
                    Console.WriteLine("Vita del nemico: " + vitaNem);
                }else if (vitaNem <= 0)
                {
                    Console.WriteLine("Vita del nemico: 0");
                }
                
            }        

            return puntiVita;
        }

        static string Fuga(string pers)
        {

            Random rnd = new Random();
            int lancio = rnd.Next(1, 11);

            string risultatoFuga;

            if (pers == "3" && lancio < 6)
            {
                risultatoFuga = "Sei riuscito a scappare, per fortuna";
            }
            else if(pers == "3" && lancio > 6)
            {
                risultatoFuga = "Non sei riuscito a scappare, dovrai combattere!!!";
            }
            else if(pers!="3" && lancio < 5)
            {
                risultatoFuga = "Sei riuscito a scappare, per fortuna";
            }
            else
            {
                risultatoFuga = "Non sei riuscito a scappare, dovrai combattere!!!";
            }

            return risultatoFuga;

        }

        static int Incontro()
        {
            Random rnd = new Random();
            int incontro = rnd.Next(1, 3);

            return incontro;
        }

        static int Oggetto()
        {
            Random rnd = new Random();
            int ogg = rnd.Next(1, 9);

            return ogg;
        }

        static void Main(string[] args)
        {
            int vita = 10, danno = 2, scelta = 0, avanzamento, indice = 0, evento, sceltaNem, aura = 0, sceltaGand, contCur = 0,contCav = 0; 
            string personaggio = "";

            string[] Luogo = { "La Contea", "Bosco Atro", "Casa di Tom Bombadil", "Brea", "Colle Vento", "Gran Burrone", "Moria", "Lothlórien", "Fiume Anduin", "Amon Hen", "Fangorn", "Rohan", "Fosso di Helm", "Isengard", "Osgiliath", "Minas Morgul", "Minas Tirith", "Campi del Pelennor", "Cirith Ungol", "Monte Fato" };

            string[] inventario = { "Spada", "x", "x", "x", "x" };

            personaggio = SceltaPersonaggio(personaggio);

            Console.WriteLine("Hai scelto " + personaggio);

            if (personaggio == "1")
            {
                vita = vita + 5;
            }
            else if(personaggio == "2")
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
                    avanzamento = LancioDado(contCav);

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

                            vita = Combattimento(vita, danno, inventario);

                            if (vita <= 0)
                            {
                                Console.WriteLine("GAME OVER!!!");
                                Console.WriteLine("sei stato ucciso da un Nazgul");
                            }
                            else
                            {
                                Console.WriteLine("Hai vinto il combattimento");
                                aura = aura + 1;
                            }

                        }
                        else if(sceltaNem == 2)
                        {
                            string esitoFuga = Fuga(personaggio);

                            Console.WriteLine(esitoFuga);

                            if (esitoFuga == "Non sei riuscito a scappare, dovrai combattere!!!")
                            {
                                vita = Combattimento(vita, danno, inventario);

                                if (vita <= 0)
                                {
                                    Console.WriteLine("GAME OVER!!!");
                                    Console.WriteLine("sei stato ucciso da un Nazgul");
                                }
                                else
                                {
                                    Console.WriteLine("Hai vinto il combattimento");
                                }
                            }
                            
                        }

                    }
                    else if(evento == 2)
                    {
                        int Inc = Incontro();

                        if (Inc == 1)
                        {
                            Console.WriteLine();
                            Console.WriteLine("Durante il tuo viaggio hai incontrato Gandalf ");
                            Console.WriteLine();
                            Console.WriteLine("GANDALF: 'Salve giovane eroe, ti ringrazio ancora per il coraggio che stai dimostrando nella missione che stai svolgendo." +
                                "Sono venuto qua in tuo aiuto, se hai abbastanza aura(almeno 3 punti aura) ti curero le ferite e rigenererò la tua vita al massimo," +
                                " oppure ti aumenterò il danno base di 2, lascio a te la scelta! Ora controllerò quanta aura hai!' ");
                            Console.WriteLine();
                            if (aura < 3)
                            {
                                Console.WriteLine("GANDALF: 'Che peccato ragazzo percepisco che non hai abbastanza aura, sarà per la prossima volta!'");
                            }
                            else
                            {
                                Console.WriteLine();
                                Console.WriteLine("GANDALF: 'Bravissimo guerriero hai abbastanza aura! ora lascio a te la scelta '");
                                Console.WriteLine("------------------------------------");
                                Console.WriteLine("|1) Aumento la vita di 2 punti      |");
                                Console.WriteLine("|2) Aumento il danno base di 2 punti|");
                                Console.WriteLine("------------------------------------");

                                Console.WriteLine();

                                sceltaGand = Convert.ToInt32(Console.ReadLine());

                                Console.WriteLine();

                                if (sceltaGand == 1)
                                {
                                    if (personaggio == "1" && vita == 15)
                                    {
                                        Console.WriteLine("La vita è gia al massimo");
                                    }
                                    else if (personaggio == "1" && vita + 5 < 15)
                                    {
                                        vita = 15;
                                        Console.WriteLine("La vita è stata rigenerata a 15");
                                    }
                                    else if (personaggio != "1" && vita + 5 == 10)
                                    {
                                        Console.WriteLine("La vita è gia al massimo");
                                    }
                                    else
                                    {
                                        vita = 10;
                                        Console.WriteLine("La vita è stata rigenerata a 10");
                                    }

                                    Console.WriteLine();                                   
                                    
                                }
                                else
                                {
                                    danno = danno + 2;
                                    Console.WriteLine();
                                    Console.WriteLine("Danno: " + danno);
                                    Console.WriteLine("Il danno è stato aumentato!!");
                                }

                                if (aura - 3 < 0)
                                {
                                    aura = 0;
                                }
                                else
                                {
                                    aura = aura - 3;
                                }
                                
                            }

                        }
                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine("Durante il tuo viaggio hai incontrato Legolas, il re degli elfi arcieri ");
                            Console.WriteLine();
                            Console.WriteLine("LEGOLAS: 'Salve giovane avventuriero, per la tua tederminazione ti regalerò un antico arco magico che puo infliggere ben 2 punti danno! Ti sara utile " +
                                "contro i Nazgul!'");                            

                            inventario[1] = "arco magico";

                            Console.WriteLine();

                            for (int i = 0; i<inventario.Length; i++)
                            {
                                
                                Console.Write("[" + inventario[i] + "]");

                            }

                            Console.WriteLine();

                            Console.WriteLine("L'arco magico è stato aggiunto all'inventario (corrisponde allo slot 2)");

                            Console.WriteLine();

                        }
                       
                    } 
                    else
                    {
                        int oggetto = Oggetto();

                        if (oggetto <= 3)
                        {                            
                            contCur=contCur + 1;

                            if (contCur > 0)
                            {
                                Console.WriteLine("Durante il viaggio rovistando tra i rovi hai trovato una pozione di cura");
                                Console.WriteLine();
                                Console.WriteLine("L'oggetto è già equipaggiato nell'inventario");
                                Console.WriteLine();
                            }
                            else
                            {
                                Console.WriteLine("Durante il viaggio rovistando tra i rovi, per proseguire per un sentiero tortuoso," +
                                    " hai trovato una pozione di cura, che è stata aggiunta all' inventario (corrisponte allo slot 4)");
                                Console.WriteLine("Ora la potrai usare per curarti durante il viaggio, oppure durante una battaglia, però per un turno non attaccherai per curarti e subirai un colpo " +
                                    "nemico");

                                inventario[4] = "pozione di cura";

                                Console.WriteLine();

                                for (int i = 0; i < inventario.Length; i++)
                                {

                                    Console.Write("[" + inventario[i] + "]");

                                }

                                Console.WriteLine();
                            }
                            
                        }
                        else if (oggetto <= 5) 
                        {
                            int contFuo = 0;

                            contFuo = contFuo + 1;

                            if (contFuo > 0)
                            {
                                Console.WriteLine("Durante il viaggio rovistando tra le rovine di un laboratorio di un  mago hai trovato una pozione del fuoco");
                                Console.WriteLine();
                                Console.WriteLine("L'oggetto è già equipaggiato nell'inventario");
                                Console.WriteLine();
                            }
                            else
                            {
                                Console.WriteLine("Durante il viaggio rovistando tra le rovine antiche di un laboratorio di un mago, " +
                                    "distrutrutte dal tempo, hai trovato una pozione del fuoco, che è stata aggiunta all' inventario (corrisponte allo slot 2)");
                                Console.WriteLine("E' una pozione che infiammera i nemici per un breve periodo generando danni!!");

                                inventario[2] = "pozione del fuoco";

                                Console.WriteLine();

                                for (int i = 0; i < inventario.Length; i++)
                                {

                                    Console.Write("[" + inventario[i] + "]");

                                }

                                Console.WriteLine();

                            }                           

                        }
                        else if(oggetto <= 6)
                        {
                            int contMor = 0;

                            contMor = contMor + 1;

                            if (contMor > 0)
                            {
                                Console.WriteLine("Durante il viaggio rovistando in una locanda di maghi losca hai trovato una pozione di della morte");
                                Console.WriteLine();
                                Console.WriteLine("L'oggetto è già equipaggiato nell'inventario");
                                Console.WriteLine();
                            }
                            else
                            {
                                Console.WriteLine("Durante il viaggio rovistando in una locanda di maghi losca," +
                                    "piena di strani maghi pericolosi e intrugli strani, hai trovato una pozione della morte, che è stata aggiunta all' inventario (corrisponte allo slot 3)");
                                Console.WriteLine("E' una pozione rara e molto potente che riesce ad uccidere con un solo colpo i nemici!!");

                                inventario[3] = "pozione della morte";

                                Console.WriteLine();

                                for (int i = 0; i < inventario.Length; i++)
                                {

                                    Console.Write("[" + inventario[i] + "]");

                                }

                                Console.WriteLine();
                            }

                        }
                        else
                        {                            
                            contCav = contCav + 1;

                            if (contCav > 0)
                            {
                                Console.WriteLine("Durante il viaggio hai incontarto un cavallo, ma hai gia una cavalcatura, quindi prosegui per la tua strada");
                                Console.WriteLine();
                            }
                            else
                            {
                                Console.WriteLine("Durante il viaggio, nelle praterie della terra di mezzo, delle vaste pianure piene di erbe e con" +
                                    "qualche collina qua e il la, ti sei imbattuto in un bel cavallo di razza" +
                                    " e sei riuscito a domarlo dopo tanta fatica, questo velocizzera il tuo viaggio di 1 casella per ogni tiro");                                   
                            }
                        }
                       
                    }

                }
                else if(scelta == 2)
                {
                    Console.WriteLine("Vita: " + vita);
                    Console.WriteLine("Danno: " + danno);
                    Console.WriteLine("Aura: " + aura);

                }
                else if(scelta == 3)
                {
                    for(int i = 0; i < inventario.Length; i++)
                    {
                        Console.Write("[" + inventario[i] + "]"); 
                    }

                }
                else if(scelta == 4)
                {
                    if (contCur > 0)
                    {
                        Console.WriteLine("Hai usato la pozione di cura per rigenerare la vita(5 punti vita, se la vita raggiunge il massimo non aggiungera punti)");

                        if(personaggio == "1" && vita + 5 >= 15)
                        {
                            vita = 15;
                            Console.WriteLine("Vita: " + vita);
                        }else if(personaggio == "1" && vita + 5 <= 15)
                        {
                            vita = vita + 5;
                            Console.WriteLine("Vita: " + vita);
                        }
                        else if (personaggio != "1" && vita + 5 >= 10)
                        {
                            vita = 10;
                            Console.WriteLine("Vita: " + vita);
                        }
                        else
                        {
                            vita = vita + 5;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Non hai nessun oggetto da usare");
                    }

                }
                else if(scelta == 5)
                {
                    vita = 0;
                    Console.WriteLine("Sei uscito dal gioco");
                }
            }


            
        }
    }
}
 