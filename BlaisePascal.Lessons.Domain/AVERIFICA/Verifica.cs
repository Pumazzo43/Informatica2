using System;
using System.Collections.Generic; // Fondamentale per usare le Liste (List<T>)

namespace EsercitazioneVerifica
{
    // ==================================================================================
    // ESERCIZIO 1: COMPAGNIA TELEFONICA
    // Obiettivo: Incrociare dati da 3 matrici diverse per calcolare i costi.
    // ==================================================================================

    // Classe semplice per trasportare i risultati (ID Cliente e Totale da pagare).
    public class Bolletta
    {
        public int IdCliente;
        public double Totale;
    }

    public class GestoreTelefonico
    {
        public List<Bolletta> CalcolaBollette(double[,] clienti, double[,] traffico, double[,] tariffe)
        {
            List<Bolletta> risultati = new List<Bolletta>();

            // 1. SCORRIAMO I CLIENTI (Righe della tabella clienti)
            // GetLength(0) ci dice quante righe ha la matrice.
            for (int i = 0; i < clienti.GetLength(0); i++)
            {
                int idCliente = (int)clienti[i, 0]; // Colonna 0: ID Cliente (cast a int necessario)
                double sommaCosti = 0; // Accumulatore per il costo totale

                // 2. CERCHIAMO LE CHIAMATE DI QUESTO CLIENTE NEL TRAFFICO
                for (int j = 0; j < traffico.GetLength(0); j++)
                {
                    int idChiamante = (int)traffico[j, 4]; // Colonna 4: ID di chi chiama

                    if (idChiamante == idCliente)
                    {
                        // Abbiamo trovato una chiamata!
                        double durataSec = traffico[j, 0]; // Colonna 0: Durata

                        // TRUCCO: Convertiamo tutto in "minuti dalla mezzanotte" per confrontare gli orari.
                        // (Ora * 60) + Minuti.
                        int minutiInizio = ((int)traffico[j, 1] * 60) + (int)traffico[j, 2];

                        double costoAlMinuto = 0;

                        // 3. TROVIAMO LA TARIFFA GIUSTA
                        for (int k = 0; k < tariffe.GetLength(0); k++)
                        {
                            int inizioFascia = ((int)tariffe[k, 0] * 60) + (int)tariffe[k, 1];
                            int fineFascia = ((int)tariffe[k, 2] * 60) + (int)tariffe[k, 3];

                            // Se l'orario della chiamata cade in questa fascia
                            if (minutiInizio >= inizioFascia && minutiInizio <= fineFascia)
                            {
                                costoAlMinuto = tariffe[k, 4]; // Colonna 4: Costo
                                break; // Tariffa trovata, usciamo dal ciclo tariffe
                            }
                        }

                        // Calcoliamo il costo: (Secondi / 60) * Costo al minuto
                        sommaCosti += (durataSec / 60.0) * costoAlMinuto;
                    }
                }

                // Salviamo il risultato per questo cliente
                Bolletta b = new Bolletta();
                b.IdCliente = idCliente;
                b.Totale = sommaCosti;
                risultati.Add(b);
            }
            return risultati;
        }
    }

    // ==================================================================================
    // ESERCIZIO 2: STUDENTI E EMAIL (Gestione Stringhe e Omonimie)
    // Obiettivo: Parsare una stringa "sporca" e generare email uniche.
    // Input: "1;mario;rossi;2;luca;verdi;3;mario;rossi..."
    // ==================================================================================

    public class GestoreEmail
    {
        public List<string> GeneraEmailStudenti(string datiInput)
        {
            List<string> listaEmail = new List<string>();

            // 1. DIVIDERE LA STRINGA (Parsing)
            // Split(';') spezza la stringa ogni volta che trova un punto e virgola.
            // Crea un array: [0]="1", [1]="mario", [2]="rossi", [3]="2", ecc...
            string[] parti = datiInput.Split(';');

            // 2. CICLO SUI DATI
            // I dati sono a gruppi di 3 (ID, Nome, Cognome).
            // Quindi incrementiamo i di 3 alla volta (i += 3).
            for (int i = 0; i < parti.Length; i += 3)
            {
                // Controllo di sicurezza: verifichiamo di avere abbastanza pezzi per leggere nome e cognome
                if (i + 2 >= parti.Length) break;

                // Leggiamo Nome (posizione i+1) e Cognome (posizione i+2).
                // ToLower() è fondamentale perché le mail sono minuscole.
                string nome = parti[i + 1].ToLower().Trim();
                string cognome = parti[i + 2].ToLower().Trim();

                // 3. GENERAZIONE MAIL BASE
                // Formato richiesto: nome.cognome.stud@dominio.it
                string baseEmail = nome + "." + cognome;
                string dominio = ".stud@dominio.it";

                // Tentativo 1: proviamo la mail normale
                string emailFinale = baseEmail + dominio;

                // 4. GESTIONE DUPLICATI (OMONIMIA)
                // Se la lista contiene già questa mail, dobbiamo aggiungere il numero.
                if (listaEmail.Contains(emailFinale))
                {
                    int contatore = 1;

                    // Continuiamo a provare numeri finché non ne troviamo uno libero.
                    while (true)
                    {
                        // Creiamo il suffisso numerico.
                        // contatore.ToString("00") converte 1 in "01", 2 in "02", ecc.
                        string numero = contatore.ToString("00");

                        // Nuova mail candidata: nome.cognome.01.stud@dominio.it
                        string emailConNumero = baseEmail + "." + numero + dominio;

                        // Se questa NON esiste, è valida!
                        if (!listaEmail.Contains(emailConNumero))
                        {
                            emailFinale = emailConNumero;
                            break; // Usciamo dal while
                        }

                        // Se esiste anche questa, incrementiamo e riproviamo (01 -> 02)
                        contatore++;
                    }
                }

                // Aggiungiamo la mail definitiva alla lista
                listaEmail.Add(emailFinale);
            }

            return listaEmail;
        }
    }

    // ==================================================================================
    // ESERCIZIO 3: CRUCIVERBA (WORD SEARCH)
    // Obiettivo: Gestire matrice char, Random e logica spaziale.
    // ==================================================================================

    public class WordSearchGame
    {
        private char[,] _grid; // La matrice di gioco

        public WordSearchGame(int size)
        {
            _grid = new char[size, size]; // Inizializza tutto a '\0' (carattere nullo)
        }

        // METODO A: Riempimento Casuale
        public void FillRandom()
        {
            Random rnd = new Random();

            for (int r = 0; r < _grid.GetLength(0); r++) // Righe
            {
                for (int c = 0; c < _grid.GetLength(1); c++) // Colonne
                {
                    // Se la cella è vuota...
                    if (_grid[r, c] == '\0')
                    {
                        // ...inseriamo una lettera a caso tra A e Z.
                        // 'A' + numero(0-25) -> convertito in char.
                        _grid[r, c] = (char)('A' + rnd.Next(0, 26));
                    }
                }
            }
        }

        // METODO B: Inserimento Parola
        public void InsertString(string word, int row, int col, bool horizontal)
        {
            for (int i = 0; i < word.Length; i++)
            {
                if (horizontal)
                {
                    // Scrittura Orizzontale: riga fissa, colonna variabile (col + i).
                    // Controllo: non uscire dalla griglia a destra.
                    if (col + i < _grid.GetLength(1))
                    {
                        _grid[row, col + i] = word[i];
                    }
                }
                else
                {
                    // Scrittura Verticale: colonna fissa, riga variabile (row + i).
                    // Controllo: non uscire dalla griglia in basso.
                    if (row + i < _grid.GetLength(0))
                    {
                        _grid[row + i, col] = word[i];
                    }
                }
            }
        }
    }

    // ==================================================================================
    // ESERCIZIO 4: ANAGRAMMI
    // Obiettivo: Logica sulle stringhe. Se ordini le lettere, gli anagrammi sono uguali.
    // ==================================================================================

    public class GestoreTesto
    {
        public bool SonoAnagrammi(string s1, string s2)
        {
            // Pulizia: via spazi, tutto minuscolo
            s1 = s1.Trim().ToLower();
            s2 = s2.Trim().ToLower();

            // Se lunghezze diverse, impossibile siano anagrammi
            if (s1.Length != s2.Length) return false;

            // Trasformiamo in array per poter ordinare le lettere
            char[] c1 = s1.ToCharArray();
            char[] c2 = s2.ToCharArray();

            // Ordiniamo (es. "polenta" -> "aelnopt")
            Array.Sort(c1);
            Array.Sort(c2);

            // Confrontiamo lettera per lettera
            for (int i = 0; i < c1.Length; i++)
            {
                if (c1[i] != c2[i]) return false;
            }

            return true;
        }
    }

    // ==================================================================================
    // ESERCIZIO 5: SEQUENZA PERFETTA
    // Obiettivo: Logica matematica sugli array.
    // Regola: Tra due numeri 'N' ci sono 'N' spazi. Distanza indici = N + 1.
    // ==================================================================================

    public class AnalizzatoreSequenza
    {
        public bool IsSequenzaPerfetta(int[] seq)
        {
            // Controllo richiesto: lunghezza deve essere 27
            if (seq.Length != 27) return false;

            // Controlliamo ogni numero da 1 a 9
            for (int n = 1; n <= 9; n++)
            {
                int pos1 = -1, pos2 = -1, pos3 = -1; // Per salvare gli indici
                int contatore = 0;

                // Cerchiamo dove si trova il numero n nell'array
                for (int i = 0; i < seq.Length; i++)
                {
                    if (seq[i] == n)
                    {
                        contatore++;
                        if (contatore == 1) pos1 = i;
                        else if (contatore == 2) pos2 = i;
                        else if (contatore == 3) pos3 = i;
                    }
                }

                // Deve esserci esattamente 3 volte
                if (contatore != 3) return false;

                // Verifica distanze:
                // Se ho il numero 2, tra il primo e il secondo '2' devono esserci 2 numeri.
                // Indici: 0 e 3 -> 3-0 = 3. La formula è Distanza = n + 1.
                if ((pos2 - pos1) != (n + 1)) return false;
                if ((pos3 - pos2) != (n + 1)) return false;
            }

            return true;
        }
    }
}