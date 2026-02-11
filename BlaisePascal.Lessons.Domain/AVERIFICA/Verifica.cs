using System;
using System.Collections.Generic; // Serve per usare le Liste: List<T>
using System.Text;              // Serve per StringBuilder (usato nel Cruciverba)
using System.Linq;              // Utile per operazioni rapide sugli array (opzionale ma comodo)

namespace EsercitazioneVerifica
{


    // ==================================================================================
    // ESERCIZIO 1: COMPAGNIA TELEFONICA
    // Logica: Matrici, ricerca, calcoli matematici.
    // ==================================================================================

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

            // 1. SCORRO I CLIENTI (Righe tabella Clienti)
            // GetLength(0) restituisce il numero totale di righe della matrice.
            for (int i = 0; i < clienti.GetLength(0); i++)
            {
                int idCliente = (int)clienti[i, 0]; // Colonna 0: ID. Cast (int) obbligatorio su matrice double.
                double sommaCosti = 0; // Accumulatore per il totale da pagare.

                // 2. CERCO LE CHIAMATE DI QUESTO CLIENTE NEL TRAFFICO
                for (int j = 0; j < traffico.GetLength(0); j++)
                {
                    int idChiamante = (int)traffico[j, 4]; // Colonna 4: ID di chi ha chiamato.

                    if (idChiamante == idCliente)
                    {
                        // Trovata chiamata!
                        double durataSec = traffico[j, 0]; // Colonna 0: Durata in secondi.

                        // TRUCCO ORARIO: Converto tutto in "minuti dalla mezzanotte" per semplificare i confronti.
                        // Formula: (Ore * 60) + Minuti.
                        int minutiInizio = ((int)traffico[j, 1] * 60) + (int)traffico[j, 2];
                        double costoAlMinuto = 0;

                        // 3. TROVO LA TARIFFA GIUSTA
                        for (int k = 0; k < tariffe.GetLength(0); k++)
                        {
                            // Converto inizio e fine fascia oraria in minuti totali.
                            int inizioFascia = ((int)tariffe[k, 0] * 60) + (int)tariffe[k, 1];
                            int fineFascia = ((int)tariffe[k, 2] * 60) + (int)tariffe[k, 3];

                            // Se l'orario della chiamata è COMPRESO nella fascia...
                            if (minutiInizio >= inizioFascia && minutiInizio <= fineFascia)
                            {
                                costoAlMinuto = tariffe[k, 4]; // Colonna 4: Costo.
                                break; // Tariffa trovata, esco dal ciclo tariffe (ottimizzazione).
                            }
                        }

                        // Calcolo costo: (Secondi / 60.0) per avere i minuti precisi * tariffa.
                        sommaCosti += (durataSec / 60.0) * costoAlMinuto;
                    }
                }

                // Salvo il risultato nella lista
                Bolletta b = new Bolletta();
                b.IdCliente = idCliente;
                b.Totale = sommaCosti;
                risultati.Add(b);
            }
            return risultati;
        }
    }

    // ==================================================================================
    // ESERCIZIO 2: STUDENTI E EMAIL
    // Logica: String parsing (Split), gestione duplicati, cicli while.
    // ==================================================================================

    public class GestoreEmail
    {
        public List<string> GeneraEmailStudenti(string datiInput)
        {
            List<string> listaEmail = new List<string>();

            // 1. DIVIDERE LA STRINGA
            // Input: "1;Mario;Rossi;2;Luca..." -> Array: ["1", "Mario", "Rossi", "2", ...]
            string[] parti = datiInput.Split(';');

            // 2. CICLO A PASSI DI 3
            // Incremento i di 3 alla volta perché ogni studente occupa 3 posizioni (ID, Nome, Cognome).
            for (int i = 0; i < parti.Length; i += 3)
            {
                // Controllo sicurezza per non andare fuori array
                if (i + 2 >= parti.Length) break;

                // Prendo nome e cognome, pulisco spazi e metto minuscolo.
                string nome = parti[i + 1].ToLower().Trim();
                string cognome = parti[i + 2].ToLower().Trim();

                // Costruisco la base della mail: nome.cognome
                string baseEmail = nome + "." + cognome;
                string dominio = ".stud@dominio.it";
                string emailFinale = baseEmail + dominio;

                // 3. GESTIONE OMONIMIE (DUPLICATI)
                // Se la lista contiene già questa mail, devo aggiungere un numero.
                if (listaEmail.Contains(emailFinale))
                {
                    int contatore = 1;
                    while (true) // Continuo a provare finché non ne trovo una libera
                    {
                        // "00" formatta il numero: 1 diventa "01", 10 diventa "10".
                        string numero = contatore.ToString("00");
                        string emailConNumero = baseEmail + "." + numero + dominio;

                        if (!listaEmail.Contains(emailConNumero))
                        {
                            emailFinale = emailConNumero;
                            break; // Trovata! Esco dal while.
                        }
                        contatore++; // Provo il prossimo numero (01 -> 02...)
                    }
                }

                listaEmail.Add(emailFinale);
            }
            return listaEmail;
        }
    }

    // ==================================================================================
    // ESERCIZIO 3: CRUCIVERBA (WORD SEARCH) - COMPLETO
    // Logica: Matrici char, Random, StringBuilder, Validazione liste.
    // ==================================================================================

    public class WordSearchGame
    {
        private const int Size = 16; // Dimensione griglia fissa
        private char[,] _grid = new char[Size, Size];

        // Lista parole nascoste (simulata)
        private List<string> _wordsToFind = new List<string> { "INTERFACE", "CLASS", "OBJECT" };

        public WordSearchGame()
        {
            // Pulisce la griglia (mette '\0' ovunque)
            for (int i = 0; i < Size; i++)
                for (int j = 0; j < Size; j++)
                    _grid[i, j] = '\0';

            PlaceWords();      // Mette le parole
            FillRandom();      // Riempie i buchi
        }

        // METODO 1: RIEMPIMENTO CASUALE
        public void FillRandom()
        {
            Random rnd = new Random();
            for (int r = 0; r < Size; r++)
            {
                for (int c = 0; c < Size; c++)
                {
                    // Se la cella è vuota, metto una lettera a caso
                    if (_grid[r, c] == '\0')
                    {
                        // 'A' + numero(0-25) mi dà una lettera dell'alfabeto
                        _grid[r, c] = (char)('A' + rnd.Next(0, 26));
                    }
                }
            }
        }

        // METODO 2: INSERIMENTO PAROLA
        public void InsertString(string word, int row, int col, bool horizontal)
        {
            for (int i = 0; i < word.Length; i++)
            {
                if (horizontal)
                {
                    // Controllo bordi per non crashare
                    if (col + i < Size) _grid[row, col + i] = word[i];
                }
                else // Verticale
                {
                    if (row + i < Size) _grid[row + i, col] = word[i];
                }
            }
        }

        // METODO 3: FORMATTAZIONE GRIGLIA (Per visualizzazione)
        public string GetFormattedGrid()
        {
            // StringBuilder è efficiente per costruire testi lunghi
            StringBuilder sb = new StringBuilder();
            for (int r = 0; r < Size; r++)
            {
                for (int c = 0; c < Size; c++)
                {
                    sb.Append(_grid[r, c] + " "); // Aggiunge lettera + spazio
                }
                sb.AppendLine(); // Va a capo a fine riga
            }
            return sb.ToString();
        }

        // METODO 4: LISTA PAROLE
        public string GetWordsList()
        {
            // Unisce le parole della lista con una virgola in mezzo
            return string.Join(", ", _wordsToFind);
        }

        // METODO 5: VALIDAZIONE
        public bool ValidateWord(string word)
        {
            // Controlla se la parola esiste nella lista (ignorando maiuscole/minuscole)
            return _wordsToFind.Contains(word.ToUpper());
        }

        // Helper interno per posizionare parole di prova
        private void PlaceWords()
        {
            InsertString("INTERFACE", 0, 0, true);
        }
    }

    // ==================================================================================
    // ESERCIZIO 4: ANAGRAMMI
    // Logica: String -> CharArray -> Sort -> Compare
    // ==================================================================================

    public class GestoreTesto
    {
        public bool SonoAnagrammi(string s1, string s2)
        {
            // 1. Pulisco input (spazi e minuscolo)
            s1 = s1.Trim().ToLower();
            s2 = s2.Trim().ToLower();

            // 2. Controllo lunghezze
            if (s1.Length != s2.Length) return false;

            // 3. Converto in array per ordinare
            char[] c1 = s1.ToCharArray();
            char[] c2 = s2.ToCharArray();

            // 4. Ordino (Sorting)
            Array.Sort(c1);
            Array.Sort(c2);

            // 5. Confronto lettera per lettera
            for (int i = 0; i < c1.Length; i++)
            {
                if (c1[i] != c2[i]) return false;
            }
            return true;
        }
    }

    // ==================================================================================
    // ESERCIZIO 5: SEQUENZA PERFETTA
    // Logica: Array, conteggio occorrenze, calcolo distanze indici.
    // ==================================================================================

    public class AnalizzatoreSequenza
    {
        public bool IsSequenzaPerfetta(int[] seq)
        {
            if (seq.Length != 27) return false;

            // Controllo per ogni numero N da 1 a 9
            for (int n = 1; n <= 9; n++)
            {
                int pos1 = -1, pos2 = -1, pos3 = -1;
                int contatore = 0;

                // Cerco le posizioni del numero N nell'array
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

                // Regola 1: Deve apparire 3 volte esatte
                if (contatore != 3) return false;

                // Regola 2: Distanza tra le occorrenze = N + 1
                if ((pos2 - pos1) != (n + 1)) return false;
                if ((pos3 - pos2) != (n + 1)) return false;
            }
            return true;
        }
    }
}