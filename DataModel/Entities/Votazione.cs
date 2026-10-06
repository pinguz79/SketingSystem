using System.Diagnostics;

namespace DataModel.Entities
{
    [DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
    public class Votazione
    {
        public Guid Id { get; set; }
        public Guid GaraId { get; set; }
        public virtual Gara Gara { get; set; }
        public Guid PartecipanteId { get; set; }
        public virtual Partecipante Partecipante { get; set; }
        public Guid GiudiceId { get; set; }
        public virtual Giudice Giudice { get; set; }
        public double Tecnica { get; set; }
        public double Interpretazione { get; set; }
        public double Show { get; set; }
        public double Totale => Tecnica + Interpretazione + Show;

        private string GetDebuggerDisplay() => ToString();
        override public string ToString() => $"{Partecipante} ({Gara} - {Giudice}): Tecnica: {Tecnica:f1}, Interpretazione: {Interpretazione:f1}, Show: {Show:f1}, Totale: {Totale:f1}";
    }
}
