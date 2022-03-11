using LeasingCarsWPF.Stores;
using LeasingCarsWPF.ViewModels;
using System;

namespace LeasingCarsWPF.Services
{
    public class NavigationService<TParameter> : INavigationService<TParameter>
    {
        private NavigationStore _navigationStore;
        private Func<BaseVM>? _createVM;
        private Func<TParameter, BaseVM>? _paramCreateVM;

        public NavigationService(NavigationStore navigationStore, Func<BaseVM> createVM)
        {
            _navigationStore = navigationStore;
            _createVM = createVM;
            _paramCreateVM = null;
        }

        public NavigationService(NavigationStore navigationStore, Func<TParameter, BaseVM> paramCreateVM)
        {
            _navigationStore=navigationStore;
            _paramCreateVM=paramCreateVM;
            _createVM=null;
        }

        public void Navigate()
        {
            _navigationStore.CurrentVM = _createVM();
        }

        public void Navigate(TParameter parameter)
        {
            if (_paramCreateVM == null)
            {
                _navigationStore.CurrentVM = _createVM();
                return;
            }
            _navigationStore.CurrentVM = _paramCreateVM(parameter);
        }
    }
}
