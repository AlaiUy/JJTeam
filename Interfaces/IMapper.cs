using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Interfaces
{
    public interface IMapper
    {
        bool Add(object xObject);

        bool Update(object xObject);

        bool Remove(object xObject);

        IList<object> getMonedas();

       

    }
}
