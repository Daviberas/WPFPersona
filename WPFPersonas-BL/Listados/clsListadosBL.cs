using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFPersona_ENTITIES;
using WPFPersonaDAL;

namespace WPFPersona_BL
{
    public class clsListadosBL
    {
        /// <summary>
        ///     Método que genera un listado de todas las personas de la tabla personas de la base de datos WPFSample.
        /// </summary>
        /// <returns>
        ///     El listado de personas.
        /// </returns>
        public ObservableCollection<clsPersona> getListadoPersonasBL()
        {
            ObservableCollection<clsPersona> lista = new ObservableCollection<clsPersona>();
            clsListadosDAL listado = new clsListadosDAL();

            lista = listado.getListadoPersonasDAL();

            return lista;
        }
    }
}
