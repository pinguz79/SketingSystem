using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Linq;

namespace DataModel.Entities
{
    [DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
    public class Gara
    {
        public Guid Id { get; set; }
        public Guid DisciplinaId { get; set; }
        public virtual Disciplina Disciplina { get; set; }
        public Guid CategoriaId { get; set; }
        public virtual Categoria Categoria { get; set; }
        public virtual ICollection<Giudice> Giudici { get; set; } = [];
        public virtual ICollection<Votazione> Votazioni { get; set; } = [];

        // Proprietà calcolata per ottenere i partecipanti
        [NotMapped] public IEnumerable<Partecipante> Partecipanti => Disciplina?.Partecipanti?.Where(p => p.CategoriaId == CategoriaId);
        // Proprietà calcolata per ottenere i voti raggruppati per partecipante e giudice
        [NotMapped] public Dictionary<Partecipante, Dictionary<Giudice, Votazione>> Voti => Votazioni?.GroupBy(v => v.Partecipante)?.ToDictionary(g => g.Key, g => g.GroupBy(v => v.Giudice).ToDictionary(gg => gg.Key, gg => gg.SingleOrDefault()));

        private string GetDebuggerDisplay() => ToString();
        override public string ToString() => $"{Disciplina} - {Categoria}";
    }
}