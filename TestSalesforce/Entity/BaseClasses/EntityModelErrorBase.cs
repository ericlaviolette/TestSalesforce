using System.Collections.Generic;
using InventoryManager.Utilities;

namespace InventoryManager.Entity
{
    abstract public class EntityModelErrorBase : EntityModelBase
    {
        public EntityModelErrorBase()
        {
            ErrorsReturn = new ErrorCodeJSON[] { new ErrorCodeJSON() };
        }

        public ErrorCodeJSON[] ErrorsReturn { get; set; }

        public bool HasError()
        {
            if (ErrorsReturn == null)
            {
                return false;
            }
            else
            {
                foreach (ErrorCodeJSON errorReturn in ErrorsReturn)
                {
                    if (errorReturn.errorCode != string.Empty || errorReturn.message != string.Empty)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                return false;
            }
        }
    }
}
