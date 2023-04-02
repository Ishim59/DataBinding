using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace tp3
{
    public class Employee: INotifyPropertyChanged
    {
        private int id;
        private string name;
        private DateTime date;
        private double experience;
        private float hours;

        [DisplayName("Номер")]
        public int Id
        {
            get => id; 
            set
            {
                id = value;
                OnPropertyChanged(nameof(Id));
            }
        }

        [DisplayName("Имя")]
        public string Name
        {
            get => name;
            set
            {
                name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        [DisplayName("Дата рождения")]
        public DateTime Date
        {
            get => date;
            set
            {
                date = value;
                OnPropertyChanged(nameof(Date));
            }
        }

        [DisplayName("Опыт работы")]
        public double Experience
        {
            get => experience;
            set
            {
                experience = value;
                OnPropertyChanged(nameof(Experience));
            }
        }

        [DisplayName("Кол-во часов в неделю")]
        public float HoursWorked
        {
            get => hours;
            set
            {
                hours = value;
                OnPropertyChanged(nameof(HoursWorked));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public Employee Clone() => new Employee()
        {
            Id = this.Id,
            Name = this.Name,
            Date = this.Date,
            HoursWorked = this.HoursWorked,
            Experience = this.Experience,
        };
    }
}
