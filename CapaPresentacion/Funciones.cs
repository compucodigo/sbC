using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{     
    public class Funciones
    {
        public static string GLB_APLICACION = "Sistema S&B Ver. 1.00";
        public static void SelTexto(TextBox CajaTexto)
        {
            if (!string.IsNullOrEmpty(CajaTexto.Text))
            {
                CajaTexto.SelectAll();
                return;
            }
        }
        public static void ValidarCampo(KeyPressEventArgs Tecla, string opcion, TextBox CajaTexto)
        {
            if (opcion=="D")
            {
               if (Tecla.KeyChar == 8)
                {
                    Tecla.Handled = false;
                    return;
                }
                bool IsDec = false;
                int nroDec = 0;

                for (int i = 0; i < CajaTexto.Text.Length; i++)
                {
                    if (CajaTexto.Text[i] == ',')
                        IsDec = true;

                    if (IsDec && nroDec++ >= 2)
                    {
                        Tecla.Handled = true;
                        return;
                    }
                }
                if (Tecla.KeyChar >= 48 && Tecla.KeyChar <= 57)
                    Tecla.Handled = false;
                else if (Tecla.KeyChar == 44)
                    Tecla.Handled = (IsDec) ? true : false;
                else
                    Tecla.Handled = true;
            }
            if (opcion == "N")
            {
                if (Tecla.KeyChar == 8)
                {
                    Tecla.Handled = false;
                    return;
                }
                if (Tecla.KeyChar >= 48 && Tecla.KeyChar <= 57)
                    Tecla.Handled = false;
                else 
                    Tecla.Handled = true;
            }
        }
    }
}
