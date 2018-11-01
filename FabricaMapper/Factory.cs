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
            }
            return null;
        }
    }
}
