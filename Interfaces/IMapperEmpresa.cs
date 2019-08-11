using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Interfaces
{
    public interface IMapperEmpresa : IMapper
    {
        object getempresa();
        void addEmpresa(object xEmpresa);
        void AddCaja(object xCaja);
        void addEquipo(object xEquipo);
        object getGrupo();
    }
}
