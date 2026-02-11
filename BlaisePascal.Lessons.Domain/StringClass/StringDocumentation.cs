using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.Lessons.Domain.StringClass
{
    public class StringDocumentation
    {
        public static void ShowDocumentation()
        {
            //Il tipo char rappresenta un carattere Unicode a 2 byte
            char c = 'A';
            //Sequenze di escape: sequenze che non vanno interpretate letteralmente
            char newLine = '\n';
            char backSlash = '\\';

            /*
             Sequenze di escape più utilizzate
             \' singolo apice
             \" virgolette
             \t Tab orizzontale
             */

            // L'unico Cast implicito da char a ushort (viene convertito nel numerico Unicode corrispondente)
            ushort s = 'a'; // 97 è il valore Unicode di 'a'
            ushort g = '1'; // 49 è il valore Unicode di '1'
            char x13 = (char)(s + 1);
            string msg = "Il carattere successivo è: " + x13);

            //Char definisce un'insieme di metodi statici per lavorare con i caratteri
            //Eccone alcuni a titolo di esempio
            msg = System.Char.ToUpper('c').ToString(); // C
            msg = System.Char.IsWhiteSpace('\t').ToString(); // True
            msg = System.Char.IsNumber('a').ToString();   //False - tutte le cifre numeriche
            msg = System.Char.IsLetter('a').ToString();   //True  A-Z, a-z e lettere degli altri alfabeti
            msg = System.Char.IsDigit('1').ToString();    //True  0-9 + le cifre degli altri alfabeti

            //---- STRING TYPE ----
            // System.String è una sequenza immutabile di caratteri

            //--- Costruire stringhe
            string s1 = "Hello";
            string s2 = "First line\nSecond Line";
            //Tutte le volte che ho bisogno di inserire letteralmente il simbolo \ all'interno della stringa
            //devo raddopiare il simbolo backslash
            //Esempio per rappresentare "\\server\fileshare\helloworld.cs" devo scrivere:
            string a1 = "\\\\server\\fileshare\\helloworld.cs";
            //in alternativa posso definire una stringa VERBATIM apponendo il simbolo @
            //in questo caso le sequenze di escape non vengono considerate
            string a2 = @"\\server\fileshare\helloworld.cs";


            // per scrivere le virgolette all'interno di una Verbatim string dobbiamo raddoppiarle ogni volta
            string xml = @"<customer id=""123""></customer>"; // id = "123"

            //Se la stringa è una sequenza di caratteri ripetuti
            string str20 = new string('#', 5); // #####
            msg = new string('*', 10);     // **********

            //Si può anche costruire una stringa a partire da un char array
            // Il metodo ToCharArray() esegue il contrario
            string s25 = null;
            //char[] ca1 = s25.ToCharArray(); //NullReferenceException

            char[] ca = "Hello".ToCharArray(); // Metodo NON statico
            // ca[0] <-- 'H'
            // ca[1] <-- 'e'
            // ...
            foreach (char c13 in ca)
                msg += (c13 + "-");  // H-e-l-l-o-

            string str = new string(ca);          // str="Hello"

            //Null and empty strings
            string empty = "";
            bool res = (empty == ""); //True
            res = (empty == string.Empty);   //True
            res = (empty.Length == 0);       //True

            // le stringhe sono reference type per cui possono essere anche null
            string nullString = null;
            res = (nullString == null); //True
            res = (nullString == string.Empty);   //False
            //res = (nullString.Length == 0);       

            // Il metodo statico string.IsNullOrEmpty è un'interessante shortcut per testare 
            // se una stringa è nulla o vuota
            res = (string.IsNullOrEmpty(empty));         //True
            res = (string.IsNullOrEmpty(nullString));    //True
            res = (string.IsNullOrEmpty("ab"));          //False

            //Assegnare un carattere partendo da una stringa mediante un indicizzatore
            string str1 = "abcde";
            char letter = str1[1];   // letter='b'
            //str[3] = 'f'; //ERRORE perchè la stringa è immodificabile e str[i] è di sola lettura

            //string implementa anche l'interfaccia IEnumerable<char> così puoi utilizzare 
            // il foreach sui suoi caratteri
            string s24 = "123";
            foreach (char e in s24)
                msg += (e + ",");     // 1,2,3,

            // Concatenazione di stringhe
            string str2 = "a" + "b";   // str2="ab"
            string str3 = "a" + 5;      // str3="a5" -- viene fatto implicit casting

            //L'operatore + non è il modo più efficiente di concatenare
            // Si utilizza il tipo StringBuilder del namespace System.Text
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < 10; i++)
            {
                sb.Append(i);
                sb.Append(",");
            }
            string str12 = sb.ToString(); // 0,1,2,3,4,5,6,7,8,9,
                                          //AppendLine realizza un Append che introduce anche la sequenza di newLIne (in Windows \r\n)

            // Utilizzo di segnaposto all'interno di una stringa
            int lato1 = 5, lato2 = 3, lato3 = 7;
            Console.WriteLine("Lato1: {0} Lato2: {1} Lato3: {2}", lato1, lato2, lato3);
            //Interpolazione di stringhe
            //Una stringa preceduta dal carattere $ si chiama stringa interpolata
            int x = 4;
            msg = $"Un quadrato ha {x} lati";
            string s6 = $"255 in esadecimale è {byte.MaxValue:X3}";     // 255 in esadecimale è 0FF
            // X2 = 2 cifre esadecimali -- si può indicare il formato mettendo carattere ':' seguito dalla format string
            // L'elenco di tutte le format string si vedrà quando analizzeremo String.Format

            // Cercare dentro una stringa
            string str123 = "quick brown fox";
            Console.WriteLine(str123.EndsWith("fox"));       //True
            Console.WriteLine("quick brown fox".StartsWith("quick"));   //True
            Console.WriteLine("quick brown fox".Contains("bro"));       //True

            //IndexOf ritorna la prima posizione di un dato carattere o sottostringa (-1 se non lo/la trova)
            Console.WriteLine("abcde".IndexOf("cd"));   //2
            Console.WriteLine("abcde".IndexOf("ac"));   //-1

            // Si può anhe specificare la posizione dalla quale cominciare con la ricerca
            Console.WriteLine("abcdefgcd".IndexOf("cd", 4));   //7 


            //IndexOfAny ritorna la prima posizione tra i caratteri di un insieme
            Console.WriteLine("ab,cd ef".IndexOfAny(new char[] { ' ', ',' }));  //2
            Console.WriteLine("ab,cd ef".IndexOfAny(new char[] { 'e', ',' }));  //2
            Console.WriteLine("pas5w0rd".IndexOfAny("0123456789".ToCharArray()));  //3 {'0','1','2',...,'9'}

            int posNum = -1;
            posNum = "pas5w0rd".IndexOfAny("0123456789".ToCharArray());
            if (posNum >= 0)
                Console.WriteLine("Il numero è presente");

            //Manipolare stringhe
            //Tutti i metodi che manipolano le stringhe ne ritornano una nuova, lasciando l'originale non toccata
            // stessa cosa si può dire per una ri-assegnazione di un valore ad una stringa

            //Substring(pos,offset) estrae una porzione di stringa partendo dalla posizione pos 
            // e contando offset caratteri
            string left3 = "12345".Substring(0, 3);     // left3="123";
            string mid3 = "12345".Substring(1, 3);     // mid3="234";

            string s8 = "helloworld".Insert(5, ", ");   // s8="hello, world"
            string s9 = s8.Remove(5, 2);                // s9="helloworld"

            //PadLeft e PadRight riempiono una stringa fino ad una lung. data, con una sequenza di un carattere specifico
            // (spazi se il carattere non è specificato)
            Console.WriteLine("12345".PadLeft(9, '*'));     // ****12345
            Console.WriteLine("12345".PadLeft(9));          //     12345   -- 4 spazi a sinistra

            //TrimStart TrimEnd eliminano specifi caratteri dall'inizio o dalla fine di una stringa
            // Trim rimuove da entrambi. Di default elimano spazi bianchi (inclusi tab, new lines, cr,...)
            Console.WriteLine("   abc \t\r\n ".Trim().Length);  // 3

            //Replace sostituisce tutte le occorrenze di un carattere (o sottostringa) con un altro carattere (o sottostringa)
            Console.WriteLine("to be done".Replace(" ", " | "));     // to | be | done
            Console.WriteLine("to be done".Replace(" ", ""));       // tobedone

            //ToUpper e ToLower ritornano una versione maiuscola o minuscola della stringa
            Console.WriteLine("aBcdefg".ToUpper());

            //Splitting e joining di stringhe
            // Split divide una stringa in pezzi. Di default usa il carattere whitespace come delimitatore
            string[] words = "The quick brown fox".Split();
            foreach (string word in words)
                Console.Write(word + "|");

            //Si può anche impostare come delimitatore un char oppure una stringa
            string[] stringhe = "Mario;Rossi;12;Milano".Split(';');
            foreach (string stringa in stringhe)
                Console.Write(stringa + "|");

            // Il metodo statico Join effettua il contrario di Split. Richiede un delimitatore ed un array di stringhe
            string together = string.Join(" ", words);

            // String Format
            // Il metodo statico Format fornisce un metodo utile per costruire stringhe che contengono variabili
            // Le variabili possono essere di qualsiasi tipo
            // La stringa che include le variabili si chiama composite format string
            string composite = "It's {0} degrees in {1} on this {2} morning";
            string s12 = string.Format(composite, 35, "Cesena", DateTime.Now.DayOfWeek);
            Console.WriteLine(s12);

            // Il numero dentro le graffe indica la posizione dell'argomento e quest'ultimo può essere seguito
            // da: virgola ed una larghezza minima (se <0 allora il dato è allineato a sx altrimenti a dx
            // ":" seguito da un format string
            string composite1 = "Name={0,-20} Credit Limit={1,15:C}";
            Console.WriteLine(string.Format(composite1, "Mary", 500));
            Console.WriteLine(string.Format(composite1, "Elizabeth", 20000));

            //  Name=Mary                Credit Limit=        $500.00
            //  Name=Elizabeth           Credit Limit=     $20,000.00

            //Equivalentemente
            string s15 = "Name=" + "Mary".PadRight(20) + " Credit Limit=" + 500.ToString("C").PadLeft(15);
            Console.WriteLine(s15);

            // Confrontare stringhe
            Console.WriteLine("Boston".CompareTo("Austin"));    //1
            Console.WriteLine("Boston".CompareTo("Boston"));    //0
            Console.WriteLine("Boston".CompareTo("Chicago"));   //-1

            //Confronto case-insensitive con metodo static string.Compare
            Console.WriteLine(string.Compare("foo", "FOO", true)); // 0


            //Semplici esercizi
            // Numero di occorrenze di una sotto-stringa in una stringa
            string strCompleta = "aba sdfaba";
            int idx = -1, cont = -1;
            do
            {
                cont++;
                idx = strCompleta.IndexOf("a", idx + 1);
            } while (idx != -1);
            Console.WriteLine($@"La sottostringa ""aba"" è presente {cont} volte");


        }
    }
}
