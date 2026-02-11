using BlaisePascal.Lessons.Domain.OrchestraInterface;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.Lessons.Domain.OrchestraInterface
{
    internal class Orchestra
    {
        // Questa lista contiene tutti gli oggetti che sanno "fare un suono".
        // Nell'esercizio verifica, avrai una List<RisultatoCliente> o simile.
        List<ISoundMaker> SoundMakers;

        public Orchestra()
        {
            // Inizializza la lista vuota.
            SoundMakers = new List<ISoundMaker>();
        }

        public void addDrum(Drum d)
        {
            // Aggiunge un oggetto specifico alla lista generica.
            SoundMakers.Add(d);

            // Attenzione: qui nel codice originale viene aggiunto un SoundMaker generico.
            // Assicurati che SoundMaker implementi l'interfaccia/classe corretta per non rompere il loop sotto.
            SoundMakers.Add(new SoundMaker("nome", 12));
        }

        public void addPiano(Piano p)
        {
            SoundMakers.Add(p);
        }

        // Questo metodo scorre tutta la lista e produce un output unico.
        // Simile a: "Calcola il costo totale per ogni cliente e stampalo".
        public string PlayAll()
        {
            StringBuilder sb = new StringBuilder();

            // POLIMORFISMO:
            // Qui trattiamo tutti gli oggetti come "Instrument" (o ISoundMaker).
            // Non ci importa se è un Piano o un Drum, chiamiamo .Play() e lui sa cosa fare.
            foreach (Instrument i in SoundMakers)
            {
                // Appende il risultato del suono alla stringa finale.
                sb.AppendLine(i.Play());
            }
            return sb.ToString();
        }
    }
}