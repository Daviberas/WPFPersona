using System;
using System.Collections.ObjectModel;
using System.Windows;
using WPFPersona_BL;
using WPFPersona_ENTITIES;

namespace WPFPersona.ViewModels
{
    public class clsMainPageVM : clsVMBase
    {
        private clsPersona _personaSeleccionada;
        private ObservableCollection<clsPersona> _listado;
        private DelegateCommand _eliminarCommand;
        private DelegateCommand _guardarCommand;
        private clsManejadoraPersonaBL mane = new clsManejadoraPersonaBL();
        private clsListadosBL lista = new clsListadosBL();

        public clsMainPageVM()
        {
            _listado = lista.getListadoPersonasBL();
            _eliminarCommand = new DelegateCommand(EliminarCommand_Executed, EliminarCommand_CanExecute);
            _guardarCommand = new DelegateCommand(GuardarCommand_Executed, EliminarCommand_CanExecute);
        }

        public clsPersona personaSeleccionada
        {
            get
            {
                return _personaSeleccionada;
            }
            set
            {
                _personaSeleccionada = value;
                _eliminarCommand.RaiseCanExecuteChanged();
                _guardarCommand.RaiseCanExecuteChanged();
                NotifyPropertyChanged("personaSeleccionada");
            }
        }
        public ObservableCollection<clsPersona> listado
        {
            get
            {
                return _listado;
            }
            set
            {
                _listado = value;
                NotifyPropertyChanged("listado");
            }
        }

        public DelegateCommand eliminarCommand
        {
            get
            {
                return _eliminarCommand;
            }
        } 

        private void EliminarCommand_Executed()
        {
            try
            {
                mane.borrarPersonaBL(personaSeleccionada.Id);
            }
            catch (Exception e)
            {
                MessageBox.Show("Error en la base de datos.");
            }
            listado = lista.getListadoPersonasBL();
        }

        private bool EliminarCommand_CanExecute()
        {
            bool puedeBorrar = false;
            if (personaSeleccionada != null)
                puedeBorrar = true;
            return puedeBorrar;
        }

        public DelegateCommand guardarCommand
        {
            get
            {
                return _guardarCommand;
            }
        }

        private void GuardarCommand_Executed()
        {
            try
            {
                if (personaSeleccionada.Id != 0)
                    mane.actualizarPersonaBL(personaSeleccionada);
                else
                    if (personaSeleccionada.Id == 0)
                        mane.insertarPersonaBL(personaSeleccionada);
            }
            catch (Exception e)
            {
                MessageBox.Show("Error en la base de datos.");
            }
            listado = lista.getListadoPersonasBL();
        }
    }
}
