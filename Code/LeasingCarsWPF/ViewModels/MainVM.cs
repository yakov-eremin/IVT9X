using LeasingCarsWPF.Models;
using LeasingCarsWPF.Services;
using LeasingCarsWPF.Stores;
using System.Collections.Generic;

namespace LeasingCarsWPF.ViewModels
{
    public class MainVM : BaseVM 
    {
        private NavigationStore _navigationStore;
        private SideNavBarVM _sideNavBarVM;
        private bool _isLogout;

        public MainVM()
        {
            _navigationStore = new NavigationStore();
            _navigationStore.CurrentVMChanged += OnCurrentVMChanged;
            _navigationStore.CurrentVM = CreateLoginVM();
        }

        private LoginVM CreateLoginVM()
        {
            NavigationService<Employee> adminNavigationService = new NavigationService<Employee>(_navigationStore,
                (admin) => CreateAdminLayoutVM(admin));
            NavigationService<Employee> mechaNavigationService = new NavigationService<Employee>(_navigationStore,
                (mecha) => CreateMechaLayoutVM(mecha));
            NavigationService<Employee> hrNavigationService = new NavigationService<Employee>(_navigationStore,
                (hr) => CreateHRsLayoutVM(hr));
            _isLogout = true;
            return new LoginVM(adminNavigationService, mechaNavigationService, hrNavigationService);
        }

        private LayoutVM CreateAdminLayoutVM(Employee admin)
        {
            List<SideNavBarVM> items = new List<SideNavBarVM>()
            {
                new SideNavBarVM("Просмотр автомобилей",
                    new NavigationService<string>(_navigationStore, param => CreateAdminsVM(param))),
                new SideNavBarVM("Оформить заказ",
                    new NavigationService<string>(_navigationStore, param => CreateAdminsVM(param,admin))),
                new SideNavBarVM("Завершить сеанс",
                    new NavigationService<string>(_navigationStore, () => CreateLoginVM()))
            };
            if (_sideNavBarVM == null || _isLogout)
            {
                _sideNavBarVM = new SideNavBarVM(items);
                _sideNavBarVM.EmployeeFullName = $"{admin.FirstName} {admin.MiddleName} {admin.SecondName}";
                _sideNavBarVM.Title = "Администратор";
                _isLogout = false;
            }
            return new LayoutVM(new ListingCarsVM(), _sideNavBarVM);
        }

        private LayoutVM CreateAdminLayoutVM(BaseVM vM)
        {
            List<SideNavBarVM> items = new List<SideNavBarVM>()
            {
                new SideNavBarVM("Просмотр автомобилей",
                    new NavigationService<string>(_navigationStore, param => CreateAdminsVM(param))),
                new SideNavBarVM("Оформить заказ",
                    new NavigationService<string>(_navigationStore, param => CreateAdminsVM(param))),
                new SideNavBarVM("Завершить сеанс",
                    new NavigationService<string>(_navigationStore, () => CreateLoginVM()))
            };
            if (_sideNavBarVM == null)
            {
                _sideNavBarVM = new SideNavBarVM(items);
                _isLogout = false;
                _sideNavBarVM.Title = "Администратор";
            }
            return new LayoutVM(vM, _sideNavBarVM);
        }

        private BaseVM CreateAdminsVM(string param, Employee? employee = null)
        {
            switch (param)
            {
                case "Просмотр автомобилей":
                    return CreateAdminLayoutVM(new ListingCarsVM());
                case "Оформить заказ":
                    return CreateAdminLayoutVM(new OrderVM(employee));
                default:
                    return CreateLoginVM();
            }
        }

        private BaseVM CreateMechaLayoutVM(Employee mecha)
        {
            List<SideNavBarVM> items = new List<SideNavBarVM>()
            {
                new SideNavBarVM("Сделать заказ детали",
                    new NavigationService<string>(_navigationStore, param => CreateMechasVM(param, mecha))),
                new SideNavBarVM("Сменить статус автомобиля",
                    new NavigationService<string>(_navigationStore, param => CreateMechasVM(param))),
                new SideNavBarVM("Завершить сеанс",
                    new NavigationService<string>(_navigationStore, () => CreateLoginVM()))
            };
            if (_sideNavBarVM == null || _isLogout)
            {
                _sideNavBarVM = new SideNavBarVM(items);
                _isLogout = false;
                _sideNavBarVM.EmployeeFullName = $"{mecha.FirstName} {mecha.MiddleName} {mecha.SecondName}";
                _sideNavBarVM.Title = "Механик";
            }
            return new LayoutVM(new OrderSpareVM(mecha), _sideNavBarVM);
        }

        private BaseVM CreateMechaLayoutVM(BaseVM vM)
        {
            List<SideNavBarVM> items = new List<SideNavBarVM>()
            {
                new SideNavBarVM("Сделать заказ детали",
                    new NavigationService<string>(_navigationStore, param => CreateMechasVM(param))),
                new SideNavBarVM("Сменить статус автомобиля",
                    new NavigationService<string>(_navigationStore, param => CreateMechasVM(param))),
                new SideNavBarVM("Завершить сеанс",
                    new NavigationService<string>(_navigationStore, () => CreateLoginVM()))
            };
            if (_sideNavBarVM == null || _isLogout)
            {
                _sideNavBarVM = new SideNavBarVM(items);
                _isLogout = false;
                _sideNavBarVM.Title = "Механик";
            }
            return new LayoutVM(vM, _sideNavBarVM);
        }


        private BaseVM CreateMechasVM(string param, Employee? mecha = null)
        {
            switch (param)
            {
                case "Сделать заказ детали":
                    return CreateMechaLayoutVM(new OrderSpareVM(mecha));
                case "Сменить статус автомобиля":
                    return CreateMechaLayoutVM(new ChangeCarStatusVM());
                default:
                    return CreateLoginVM();
            }
        }

        private BaseVM CreateHRsLayoutVM(Employee hr)
        {
            List<SideNavBarVM> items = new List<SideNavBarVM>()
            {
                new SideNavBarVM("Просмотреть отзывы",
                    new NavigationService<string>(_navigationStore, param => CreateHRsVM(param))),
                new SideNavBarVM("Завершить сеанс",
                    new NavigationService<string>(_navigationStore, () => CreateLoginVM()))
            };
            if (_sideNavBarVM == null || _isLogout)
            {
                _sideNavBarVM = new SideNavBarVM(items);
                _sideNavBarVM.EmployeeFullName = $"{hr.FirstName} {hr.MiddleName} {hr.SecondName}";
                _isLogout = false;
                _sideNavBarVM.Title = "Менеджер";
            }
            return new LayoutVM(new StatisticsVM(), _sideNavBarVM);
        }

        private BaseVM CreateHRsLayoutVM(BaseVM vM)
        {
            List<SideNavBarVM> items = new List<SideNavBarVM>()
            {
                new SideNavBarVM("Просмотреть отзывы",
                    new NavigationService<string>(_navigationStore, param => CreateHRsVM(param))),
                new SideNavBarVM("Завершить сеанс",
                    new NavigationService<string>(_navigationStore, () => CreateLoginVM()))
            };
            if (_sideNavBarVM == null || _isLogout)
            {
                _sideNavBarVM = new SideNavBarVM(items);
                _isLogout = false;
                _sideNavBarVM.Title = "Менеджер";
            }
            return new LayoutVM(vM, _sideNavBarVM);
        }


        private BaseVM CreateHRsVM(string param)
        {
            switch (param)
            {
                case "Просмотреть отзывы":
                    return CreateMechaLayoutVM(new StatisticsVM());
                default:
                    return CreateLoginVM();
            }
        }

        private void OnCurrentVMChanged()
        {
            OnPropertyChanged(nameof(CurrentVM));
        }

        public BaseVM CurrentVM
        {
            get => _navigationStore.CurrentVM;
            set => _navigationStore.CurrentVM = value;
        }
    }
}