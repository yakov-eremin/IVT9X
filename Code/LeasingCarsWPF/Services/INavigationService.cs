
namespace LeasingCarsWPF.Services
{
    public interface INavigationService<TParameter>
    {
        public void Navigate();
        public void Navigate(TParameter parameter);
    }
}