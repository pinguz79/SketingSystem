using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace DataModel.Entities
{
    [DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
    public class Partecipante : INotifyPropertyChanged
    {
        [Browsable(false)]
        public Guid Id { get; set; }
        public string Nome { get; set; }
        [Browsable(false)]
        public Guid CategoriaId { get; set; }
        private Categoria _categoria;
        public virtual Categoria Categoria
        {
            get => _categoria;
            set
            {
                if (_categoria == value)
                    return;

                if (_categoria != null)
                    _categoria.PropertyChanged -= Categoria_PropertyChanged;

                _categoria = value;

                if ( _categoria != null )
                    _categoria.PropertyChanged += Categoria_PropertyChanged;
            }
        }

        private ICollection<Disciplina> _discipline = [];
        [Browsable(false)]
        public virtual ICollection<Disciplina> Discipline 
        { 
            get => _discipline; 
            set
            {
                if (_discipline == value)
                    return;
                foreach (var d in _discipline)
                    d.PropertyChanged -= Disciplina_PropertyChanged;
                _discipline = value;
                foreach (var d in _discipline)
                    d.PropertyChanged += Disciplina_PropertyChanged;
                OnPropertyChanged(nameof(Discipline));
                OnPropertyChanged(nameof(DisciplineFormatted));
            }
        }
        [NotMapped, DisplayName("Discipline")]
        public string DisciplineFormatted => Discipline?.Count switch
        {
            null => "",
            0 => "",
            1 => Discipline.First().Nome,
            _ => string.Join(", ", Discipline.Select(d => d.Nome))
        };
        [Browsable(false)]
        public virtual ICollection<Votazione> Votazioni { get; set; } = [];

        private void Categoria_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            OnPropertyChanged(nameof(Categoria));
            OnPropertyChanged(nameof(ToString));
        }
        private void Disciplina_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            OnPropertyChanged(nameof(Discipline));
            OnPropertyChanged(nameof(DisciplineFormatted));
        }

        public void InitializeNotifications()
        {
            if (_categoria != null)
            {
                _categoria.PropertyChanged -= Categoria_PropertyChanged;
                _categoria.PropertyChanged += Categoria_PropertyChanged;
            }
            Discipline.ToList().ForEach(d =>
            {
                d.PropertyChanged -= Disciplina_PropertyChanged;
                d.PropertyChanged += Disciplina_PropertyChanged;
            });
        }

        private string GetDebuggerDisplay() => ToString();
        public override string ToString() => $"{Nome} ({Categoria})";
        
        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
