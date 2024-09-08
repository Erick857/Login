using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Login.Models;
using System.Data;
namespace Login.Controllers
{
    class CiudadesController
    {
        CiudadesModel _ciudadesModel = new CiudadesModel();
        public DataTable todosconrelacion() {
            return _ciudadesModel.todosconrelacion();
        }
    }
}
