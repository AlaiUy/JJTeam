﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Interfaces
{
    public interface IMapperDocumentos:IMapper 
    {
        List<object> getVentasEsperaContado();
    }
}
