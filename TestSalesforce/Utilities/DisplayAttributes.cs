
namespace InventoryManager.Utilities
{
    [System.AttributeUsage(System.AttributeTargets.All)]
    public class Display : System.Attribute
    {
        private string _name;

        public class DisplayAttributes
        {
        }

        public Display(string name)
        {
            _name = name;
        }

        public string GetName()
        {
            return _name;
        }


    }
    
}
