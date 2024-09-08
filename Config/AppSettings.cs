using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login.Config
{
    class AppSettings
    {
        private static AppSettings _instancia;
        public string usuario{ get; set; }
        public string Rol { get; set; }
        public int idusuario { get; set; }
        public string AppName { get; set; }
        private AppSettings() {
            AppName = "Accesos Casari";
        }

        public static AppSettings Instancia {

            get {
                if (_instancia == null) {
                    _instancia = new AppSettings();
                }
                return _instancia;
            }
        
        }
    }
}
