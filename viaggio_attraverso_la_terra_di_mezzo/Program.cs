namespace viaggio_attraverso_la_terra_di_mezzo
{
    internal class Program
    {
        //Funzione per la scelta del personaggio
        static string SceltaPersonaggio(string pers)
        {
            Console.WriteLine();
            Console.WriteLine("Scelgli un personaggio per intraprendere la storia, digita il numero per scegliere: ");
            Console.WriteLine();
            Console.WriteLine("------------------------------------");
            Console.WriteLine("|1) Frodo: +5 punti vita            |");
            Console.WriteLine("|2) Sam: +1 danno                   |");
            Console.WriteLine("|3) Merry: +1 probablità di fuga    |");
            Console.WriteLine("------------------------------------");
            Console.WriteLine();

            pers = Console.ReadLine();

            Console.WriteLine();

            return pers;

        }

        //Funzione per la scelta dell'azione da svolgere nel turno fi gioco
        static int SceltaPerAvanzare(int decisione)
        {
            Console.WriteLine();
            Console.WriteLine("Digita il numero dell' opzione per scegliere");
            Console.WriteLine();
            Console.WriteLine("------------------------------------------------------------------");
            Console.WriteLine("|1) Tira il dado (puoi avanzare di massimo 4 caselle)            |");
            Console.WriteLine("|2) Mostra status                                                |");
            Console.WriteLine("|3) Mostra inventario                                            |");
            Console.WriteLine("|4) Usa oggetto                                                  |");
            Console.WriteLine("|5) Esci                                                         |");
            Console.WriteLine("------------------------------------------------------------------");
            Console.WriteLine();

            decisione = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine();

            return decisione;
        }

        //Funzione per il lancio casuale del dado da 1 a 4 per avanzare di caselle
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

        //Funzione per l'estrazione dell'evento casuale che accadrà in ogni luogo raggiunto (combattere con i nemici, incontrare Gandalf o Legolas, trovare oggetti magici)
        static int EventoCasuale()
        {

            Random lancio = new Random();
            return lancio.Next(1, 4);

        }

        //Funzione per il meccanismo di combattimento a turni con scelta dell'arma dall'inventario
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
                    Console.WriteLine();
                }
                else if (vitaNem <= 0)
                {
                    Console.WriteLine("Vita del nemico: 0");
                    Console.WriteLine();
                }
                
            }        

            return puntiVita;
        }

        //Funzione per la probabilita di fuggire da un nemico, Merry ha una probabilità in piu di fuggire
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

        //Funzione per l'incontro casuale tra Gandalf o Legolas
        static int Incontro()
        {
            Random rnd = new Random();
            int incontro = rnd.Next(1, 3);

            return incontro;
        }

        //Funzione per l'estrazione di un oggetto casuale o una cavalcatura trovato durande il gioco
        static int Oggetto()
        {
            Random rnd = new Random();
            int ogg = rnd.Next(1, 9);

            return ogg;
        }

        static void Main(string[] args)
        {
            int vita = 10, danno = 2, scelta = 0, avanzamento, indice = 0, evento, sceltaNem, aura = 0, sceltaGand, contCur = 0, contCav = 0, fine = 0, contaArco = 0; 
            string personaggio = "";

            string[] Luogo = { "La Contea", "Bosco Atro", "Casa di Tom Bombadil", "Brea", "Colle Vento", "Gran Burrone", "Moria", "Lothlórien", "Fiume Anduin", "Amon Hen", "Fangorn", "Rohan", "Fosso di Helm", "Isengard", "Osgiliath", "Minas Morgul", "Minas Tirith", "Campi del Pelennor", "Cirith Ungol", "Monte Fato" };

            string[] inventario = { "Spada", "x", "x", "x", "x" };

            //Introduzione
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("Ti trovi nelle terre di della Contea del leggendario Bilbo Baggins, il possessore dell'anello magico che" +
                "puo donare l'invisibilità, ma porta alla corruzione e alla pazia, bilbo ti chiederà di intraprendere un viaggio " +
                "attrverso la terra di mezzo per raggiungere il Monte Fato per bruciare l'anello, ma durante questa avventura" +
                "andrai in contro a i Nazgul che vorranno impossessarti dell'anello e ucciderti quindi dovrai combatterli, ma ti verra " +
                "in aiuto Gandal e Legolas. In questo viaggio troverai oggetti magici luoghi incredibili e situazioni pericolose");
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");

            //Richiamo della funzione per la scelta del personaggio
            personaggio = SceltaPersonaggio(personaggio);           

            if (personaggio == "1")
            {
                vita = vita + 5;
            }
            else if(personaggio == "2")
            {
                danno = danno + 1;
            }

            Console.WriteLine();

            Console.WriteLine("Ti trovi nella Contea dove bilbo ti affida l'anello e la missione di distruggerlo al monte fato");

            Console.WriteLine();

            //While per lo scorrimento dei turni di gioco che terminera se la vita esaurisce, se si raggiunge il monte fato o se si sceglie di abbandonare la partita
            while (vita > 0 && fine!=1)
            {              

                Console.WriteLine("Cosa vuoi fare ?");

                scelta = SceltaPerAvanzare(scelta);

                Console.WriteLine();

                Console.WriteLine("Hai scelto opzione " + scelta);

                //Controllo della scelta dell'azkone del turno di gioco
                if (scelta == 1 )//Lancio del dado e avanzamento nelle caselle
                {
                    avanzamento = LancioDado(contCav);//Richiamo della funzione per il lancio del dado

                    Console.WriteLine();

                    Console.WriteLine("Avanzi di " + avanzamento + " caselle");

                    indice = indice + avanzamento;

                    Console.WriteLine();

                    if(indice < Luogo.Length)
                    {
                        Console.WriteLine("Sei riuscito ad avanzare fino a " + Luogo[indice]);

                        evento = EventoCasuale();//Richiamo della funzione per l'evento casuale del luogo in cui ci troviamo

                        //Controllo dell' evento casuale
                        if (evento == 1)
                        {
                            Console.WriteLine();

                            Console.WriteLine("Un Nazgul ti ha trovato e ti sta attaccando, vuoi ingaggiare un combattimento(1) o tentare la fuga(2)?");
                            sceltaNem = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine();

                            if (sceltaNem == 1)
                            {

                                vita = Combattimento(vita, danno, inventario);//Richiamo della funzione oer il meccanismo di combattimento

                                if (vita <= 0)
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("GAME OVER!!!");
                                    Console.WriteLine("sei stato ucciso da un Nazgul");
                                    Console.WriteLine();
                                }
                                else
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("Hai vinto il combattimento");
                                    Console.WriteLine();
                                    aura = aura + 1;
                                }

                            }
                            else if (sceltaNem == 2)
                            {
                                string esitoFuga = Fuga(personaggio);//richiamo della funzione per la probabilità di fuga

                                Console.WriteLine(esitoFuga);

                                if (esitoFuga == "Non sei riuscito a scappare, dovrai combattere!!!")
                                {
                                    vita = Combattimento(vita, danno, inventario);

                                    if (vita <= 0)
                                    {
                                        Console.WriteLine();
                                        Console.WriteLine("GAME OVER!!!");
                                        Console.WriteLine("sei stato ucciso da un Nazgul");
                                        Console.WriteLine();
                                    }
                                    else
                                    {
                                        Console.WriteLine();
                                        Console.WriteLine("Hai vinto il combattimento");
                                        Console.WriteLine();
                                    }
                                }

                            }

                        }
                        else if (evento == 2)
                        {
                            int Inc = Incontro();//Richiamo della funzione dell' incontro casuale

                            //Controllo dell'incontro casuale
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
                                    Console.WriteLine();
                                    Console.WriteLine("GANDALF: 'Che peccato ragazzo percepisco che non hai abbastanza aura, sarà per la prossima volta!'");
                                    Console.WriteLine();
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
                                        Console.WriteLine();
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
                                if (contaArco > 0)
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("Durante il tuo viaggio hai incontrato Legolas, il re degli elfi arcieri ");
                                    Console.WriteLine();
                                    Console.WriteLine("LEGOLAS: 'Salve giovane avventuriero, vedo che ti ho gia dato il mio infallibile arco,ma curerò le tue ferite, ti auguro buon viaggio");

                                    if (personaggio == "1")
                                    {
                                        vita = 15;
                                    }
                                    else
                                    {
                                        vita = 10;
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

                                    for (int i = 0; i < inventario.Length; i++)
                                    {

                                        Console.Write("[" + inventario[i] + "]");

                                    }

                                    Console.WriteLine();

                                    Console.WriteLine("L'arco magico è stato aggiunto all'inventario (corrisponde allo slot 2)");

                                    Console.WriteLine();
                                }

                            }

                        }
                        else
                        {
                            int oggetto = Oggetto();//Richiamo funzione per il ritrovamento di un oggetto amgico casuale o della cavalcatura

                            //Controllo del ritrovamento dell'oggetto e dell'aggiunta all'inventario
                            if (oggetto <= 3)
                            {                           

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

                                contCur = contCur + 1;

                            }
                            else if (oggetto <= 5)
                            {
                                int contFuo = 0;                              

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

                                contFuo = contFuo + 1;

                            }
                            else if (oggetto <= 6)
                            {
                                int contMor = 0;                          

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

                                contMor = contMor + 1;

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
                    else//Condizione di uscita dal while per la vittoria del gioco
                    {
                        Console.WriteLine("Siamo giunti alla fine di questo magnifico viaggio attraverso terre incantate, sei riuscito a raggiungere il monte fato e distruggere" +
                            "l'anello, devi essere fiero di questa gloriosa impresa che verra ricordata nei secoli!!!");
                        Console.WriteLine("HAI VINTOOO!!!");

                        fine = fine + 1;
                    }

                }
                else if(scelta == 2)//Mostra status
                {
                    Console.WriteLine();
                    Console.WriteLine("---------------------");
                    Console.WriteLine("|Vita: " + vita +   "|");
                    Console.WriteLine("|Danno: " + danno+  "|");
                    Console.WriteLine("|Aura: " + aura +  " |");
                    Console.WriteLine("---------------------");
                    Console.WriteLine();

                }
                else if(scelta == 3)//Mostra inventario
                {
                    for(int i = 0; i < inventario.Length; i++)
                    {
                        Console.Write("[" + inventario[i] + "]"); 
                    }
                    Console.WriteLine();

                }
                else if(scelta == 4)//Utilizzo della pozione curativa (se trovata)
                {
                    if (contCur > 0)
                    {
                        Console.WriteLine("Hai usato la pozione di cura per rigenerare la vita (rigenera la vita al massimo)");

                        if(personaggio == "1" && vita == 15)
                        {
                            Console.WriteLine("Vita già al massimo ");

                        }else if(personaggio == "1" && vita < 15)
                        {
                            vita = 15;
                            Console.WriteLine("Vita rigenerata " );
                        }
                        else if (personaggio != "1" && vita == 10)
                        {
                             Console.WriteLine("Vita gia al massimo ");
                        }
                        else
                        {
                            vita = 10;
                            Console.WriteLine("Vita rigenerata ");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Non hai nessun oggetto da usare");
                    }

                }
                else if(scelta == 5)//Abbandono della partita
                {
                    vita = 0;
                    Console.WriteLine("Sei uscito dal gioco");
                }
            }


            
        }
    }
}
 