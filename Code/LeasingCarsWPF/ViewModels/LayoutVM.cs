
namespace LeasingCarsWPF.ViewModels
{
    public class LayoutVM : BaseVM
    {
        public BaseVM ContentVM { get; set; }
        public SideNavBarVM SideNavBarVM { get; set; }

        public LayoutVM(BaseVM contentVM, SideNavBarVM sideNavBarVM)
        {
            ContentVM = contentVM;
            SideNavBarVM = sideNavBarVM;
        }
    }
}
