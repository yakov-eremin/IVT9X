using LeasingCarsWPF.ViewModels;
using System;

namespace LeasingCarsWPF.Stores
{
    public class NavigationStore
    {
        private BaseVM _currentViewModel;

        public event Action CurrentVMChanged;

        public BaseVM CurrentVM
        {
            get { return _currentViewModel; }
            set
            {
                _currentViewModel = value;
                OnCurrentVMChanged();
            }
        }

        private void OnCurrentVMChanged()
        {
            CurrentVMChanged?.Invoke();
        }
    }
}