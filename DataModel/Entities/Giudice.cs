using System.Diagnostics;

namespace DataModel.Entities
{
    [DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
    public class Giudice
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public virtual ICollection<Votazione> Votazioni { get; set; } = [];


        private string GetDebuggerDisplay() => ToString();
        public override string ToString() => $"{Nome}";
    }
}
