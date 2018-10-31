using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Entidades
{
    public class Espera : Factura

    {
        
        private int _codcuenta;
        private byte _estado;
        private string _Nombreopc;
        private string _DirOpc;
        private string _RutOpc;
        private string _Adenda;




        public Espera(int xcodigo, DateTime xfecha, int xcodcliente, int xcodcuenta, int xmoneda, byte xestado, int xcodvendedor, String xNombreOpc, string xDirOpc, string xRutOpc, string xAdenda, List<Esperalin> xEsperaL) {
            base.Codigo = xcodigo;
            base.Fecha = xfecha;
            base.Codcliente = xcodcliente;
            _codcuenta = xcodcuenta;
            
            _estado = xestado;
            base.Codvendedor = xcodvendedor;
            _Nombreopc = xNombreOpc;
            _DirOpc = xDirOpc;
            _RutOpc = xRutOpc;
            _Adenda = xAdenda;
            

            //base.Lineas = xEsperaL;

        }

        public void AgregarLinea(List<Esperalin> LinE) {

      

        }
      

     
    }
}
