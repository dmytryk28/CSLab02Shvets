using Lab01Shvets.Tools;
using Lab02Shvets.Model;
using Lab02Shvets.Tools;
using System.ComponentModel;
using System.Windows;

namespace Lab02Shvets.ViewModel
{
    internal class PersonViewModel : INotifyPropertyChanged
    {
        private Person _person;
        private string _firstName;
        private string _lastName;
        private string _email;
        private DateTime _birthDate = DateTime.Today;

        private RelayCommand<object> _addPersonCommand;
        private string _personInfo;
        private bool _interfaceIsEnable = true;
        private bool _buttonIsEnable = true;

        private async void AddPerson(object o)
        {
            InterfaceIsEnable = false;
            await Task.Run(() =>
            {
                try
                {
                    _person = new Person(FirstName, LastName, Email, BirthDate);
                    InterfaceIsEnable = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            });
            if (!InterfaceIsEnable)
            {
                InterfaceIsEnable = true;
                return;
            }
            PersonInfo = _person.Info();
            if (_person.IsBirthday)
                MessageBox.Show("Happy birthday!");
        }

        public RelayCommand<object> AddPersonCommand
        {
            get
            {
                return _addPersonCommand ??= new RelayCommand<object>(AddPerson,
                    (object o) => !HasEmptyFields());
            }
        }

        private bool HasEmptyFields()
        {
            return string.IsNullOrWhiteSpace(FirstName)
                || string.IsNullOrWhiteSpace(LastName)
                || string.IsNullOrWhiteSpace(Email)
                || BirthDate.IsIncorrect();
        }

        public bool ButtonIsEnable
        {
            get { return _buttonIsEnable; }
            set
            {
                _buttonIsEnable = value;
                OnPropertyChanged(nameof(ButtonIsEnable));
            }
        }

        public string FirstName
        {
            get { return _firstName; }
            set
            {
                _firstName = value;
                OnPropertyChanged(nameof(FirstName));
            }
        }

        public string LastName
        {
            get { return _lastName; }
            set
            {
                _lastName = value;
                OnPropertyChanged(nameof(LastName));
            }
        }

        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                OnPropertyChanged(nameof(Email));
            }
        }

        public DateTime BirthDate
        {
            get { return _birthDate; }
            set
            {
                _birthDate = value;
                OnPropertyChanged(nameof(BirthDate));
            }
        }
        public string PersonInfo
        {
            get { return _personInfo; }
            private set
            {
                _personInfo = value;
                OnPropertyChanged(nameof(PersonInfo));
            }
        }

        public bool InterfaceIsEnable { get => _interfaceIsEnable; set => _interfaceIsEnable = value; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
