using ppedv.Autovermietung.Logic;
using ppedv.Autovermietung.Model;
using System.Collections.ObjectModel;

namespace ppedv.Autovermietung.UI.WPF.ViewModel
{
    public class AutoViewModel
    {
        public ObservableCollection<Auto> AutosList { get; set; }
        public Auto SelectedAuto { get; set; }

        private Core _core;

        public AutoViewModel()
        {
            _core = new Core(new Data.EFCore.EfRepository());
            AutosList = new ObservableCollection<Auto>(_core.Repository.GetAll<Auto>());
        }
    }
}
