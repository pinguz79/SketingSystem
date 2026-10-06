using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace DataModel.Entities
{
    [DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
    public class Categoria: INotifyPropertyChanged
    {
        public Guid Id { get; set; }
        private string _nome;

        public string Nome
        {
            get => _nome;

            set
            {
                if (_nome == value)
                    return;

                _nome = value;

                OnPropertyChanged();
            }
        }
        public virtual ICollection<Partecipante> Partecipanti { get; set; } = [];

        private string GetDebuggerDisplay() => ToString();
        public override string ToString() => $"{Nome}";

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
