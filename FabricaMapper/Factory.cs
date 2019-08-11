using JJ.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JJ.Mappers;


namespace JJ.FabricaMapper
{
    public class Factory
    {
        public static IMapper getMapper(Type Class)
        {
            switch (Class.Name)
            {
                case "GesArticulos": return (IMapper)new MapperArticulos();
                case "GesPrecios": return (IMapper)new MapperPrecios();
                case "GesPersonas": return (IMapper)new MapperPersonas();
                case "GesDocumentos": return (IMapper)new MapperDocumentos();
                case "GesCajas": return (IMapper)new MapperCajas();
                case "GesVendedores": return (IMapper)new MapperVendedores();
                case "GesEmpresa":return (IMapper)new MapperEmpresa();
            }
            return null;
        }
    }
}
