namespace WinFormsApp1
{
    internal class Employees
    {
        public static implicit operator Employees(Employee v)
        {
            throw new NotImplementedException();
        }
    }
}