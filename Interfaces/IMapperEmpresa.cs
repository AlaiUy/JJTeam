using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JJ.Entidades;

namespace JJ.Interfaces
{
    public interface IMapperEmpresa : IMapper
    {
        object getempresa();
        void addEmpresa(object xEmpresa);
        void AddCaja(object xCaja);
        void addEquipo(object xEquipo);
        object getGrupo();
        void UpdateEmpresa(Empresa xEmpresa);
        void ChangeCot(decimal xCotizacion, int xCodigo);
    }
}
