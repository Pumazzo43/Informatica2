using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.Lessons.Domain.DiceRollerWithInterface
{
    public class DiceRoller
    {
        // Usiamo un'interfaccia invece di "Random" direttamente.
        // Questo permette di testare la classe con numeri prevedibili se necessario.
        private IRandomProvider _randomProvider;

        // Costruttore: riceve il generatore di numeri (Dependency Injection).
        public DiceRoller(IRandomProvider randomProvider)
        {
            _randomProvider = randomProvider;
        }

        // Metodo che lancia i dadi 'numberOfRolls' volte e conta i risultati.
        public Dictionary<int, int> GetRollStatistics(int numerOfRolls)
        {
            int roll;
            // Dizionario: Chiave (Faccia del dado) -> Valore (Quante volte è uscita).
            Dictionary<int, int> stats = new Dictionary<int, int>(){
                {1,0 },{2,0},{3,0},{4,0},{5,0},{6,0}
            };

            // CICLO PRINCIPALE:
            // Simile a quando dovrai scorrere le celle vuote del cruciverba per riempirle.
            for (int i = 0; i < numerOfRolls; i++)
            {
                // Genera un numero tra 1 e 6.
                // Nell'esercizio cruciverba userai: rnd.Next('A', 'Z' + 1);
                roll = _randomProvider.Next(1, 6);

                // Se il numero è valido (esiste nelle chiavi del dizionario), incrementa il contatore.
                if (stats.ContainsKey(roll))
                {
                    stats[roll]++;
                }
            }

            return stats;
        }
    }
}