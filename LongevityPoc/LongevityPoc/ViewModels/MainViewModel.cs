using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Avalonia.Controls;
using Avalonia.Controls.Models.TreeDataGrid;

namespace LongevityPoc.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public MainViewModel()
        {
            var people = new List<Person> 
            {
                new Person("Neil", "Armstrong"),
                new Person("Buzz", "Lightyear"),
                new Person("James", "Kirk")
            };

            var items = new FlatTreeDataGridSource<Person>(people)
            {
                Columns =
                {
                    new TextColumn<Person, string>("First Name", x => x.FirstName),
                    new TextColumn<Person, string>("Last Name", x => x.LastName),
                }
            };

            Source = items;
        }

        private FlatTreeDataGridSource<Person> _source;
        public FlatTreeDataGridSource<Person> Source
        {
            get => _source;
            set
            {
                _source = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class Person
    {
        public Person(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public string FirstName { get; }
        public string LastName { get; }
    }
}
