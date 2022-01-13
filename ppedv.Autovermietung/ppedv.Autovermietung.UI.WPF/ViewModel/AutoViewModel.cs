using ppedv.Autovermietung.Logic;
using ppedv.Autovermietung.Model;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace ppedv.Autovermietung.UI.WPF.ViewModel
{
    public class AutoViewModel
    {
        public ObservableCollection<Auto> AutosList { get; set; }
        public Auto SelectedAuto { get; set; }

        public ICommand SaveCommand { get; set; }

        private Core _core;

        public AutoViewModel() : this(null)
        { }

        public AutoViewModel(Core core)
        {
            if (core == null)
                _core = new Core(new Data.EFCore.EfRepository());
            else
                _core = core;

            AutosList = new ObservableCollection<Auto>(_core.Repository.GetAll<Auto>());
            SelectedAuto = AutosList.FirstOrDefault();

            SaveCommand = new RelayCommand(x => _core.Repository.SaveChanges());
        }
    }
}
