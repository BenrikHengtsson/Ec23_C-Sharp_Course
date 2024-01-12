using ConsoleApp.Services;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IMenuService menuService = new MenuService();

            menuService.RenderMainMenu();
            //menuService.RenderAllContacts();    
           
            
            

            

        }
    }
}
