using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace TicTacToe
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IServicioTicTacToe" in both code and config file together.
    [ServiceContract]
    public interface IServicioTicTacToe
    {
        /*
        [OperationContract]
        void DoWork();
        */

        // Expone el método como parte del servicio WCF
        [OperationContract]
        void EmpezarJuego();

        [OperationContract]
        bool Mover(int idJugador, int x, int y);

        [OperationContract]
        string ObtenerTablero();

        [OperationContract]
        string DeterminarGanador();

        [OperationContract]
        int Unir();
    }
}
