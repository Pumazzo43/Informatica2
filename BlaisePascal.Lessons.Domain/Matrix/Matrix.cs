using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.Lessons.Domain.Matrix
{
    public class Matrix
    {
        // Usiamo un singolo array (vettore) per simulare una griglia 2D.
        // È più veloce e occupa meno memoria di un array di array (double[][]).
        protected double[] vector;
        private int rows, columns;

        // COSTRUTTORE: Definisce le dimensioni della tabella.
        // Esempio verifica: new Matrix(numeroClienti, 2); per la tabella Clienti.
        public Matrix(int numRows, int numColumns)
        {
            // Math.Abs evita dimensioni negative.
            rows = Math.Abs(numRows);
            columns = Math.Abs(numColumns);

            // Controllo di sicurezza: non ha senso una matrice con 0 celle.
            if ((rows * columns) == 0)
                throw new Exception($"Impossible to create a {rows} * {columns} matrix.");

            // Creiamo l'array che conterrà tutti i dati.
            vector = new double[rows * columns];

            // Inizializziamo tutto a 0.
            for (int i = 0; i < vector.Length; i++)
                vector[i] = 0.0;
        }

        // Proprietà per leggere quante righe e colonne ha la matrice dall'esterno.
        public int Rows => rows;
        public int Columns => columns;

        // INDICIZZATORE: Questo è il metodo più importante per la verifica.
        // Ti permette di scrivere: tabella[riga, colonna] = valore;
        public double this[int row, int column]
        {
            set // SCRITTURA
            {
                CheckDimensions(row, column); // Controlla se gli indici sono validi
                // FORMULA DI LINEARIZZAZIONE: (riga * numero_colonne) + colonna.
                // Trasforma le coordinate 2D (es. riga 1, col 2) in un indice 1D per l'array.
                vector[row * this.columns + column] = value;
            }
            get // LETTURA
            {
                CheckDimensions(row, column);
                return vector[row * this.columns + column];
            }
        }

        // Metodo helper per evitare errori "IndexOutOfRangeException".
        // Verifica che non stiamo cercando di leggere fuori dalla tabella.
        protected void CheckDimensions(int row, int column)
        {
            if (!((row >= 0) && (row < rows) && (column >= 0) && (column < columns)))
            {
                throw new OverflowException($"Impossible to access cell [{row}] [{column}].");
            }
        }

        // Metodo per visualizzare la matrice come stringa (utile per il debug/console).
        public override string ToString()
        {
            // StringBuilder è usato per efficienza quando si modificano stringhe in un loop.
            System.Text.StringBuilder result = new System.Text.StringBuilder("", 1000);
            for (int i = 0; i < vector.Length; i++)
            {
                // Se non siamo all'inizio E l'indice è multiplo delle colonne, andiamo a capo.
                if ((i > 0) && ((i % columns) == 0))
                    result.Append('\n');

                // Aggiunge il numero formattato (11 spazi, 4 decimali).
                result.AppendFormat("{0,11:f4}", vector[i]);
            }
            result.Append("\n");
            return result.ToString();
        }
    }
}