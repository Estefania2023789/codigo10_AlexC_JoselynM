// ************************************************************************
// Practica 10
// Joselyn Martinez, Alex Calderon
// Fecha de realización: 18/12/2024
// Fecha de entrega: 08/07/2025

// Resultados:
// El programa presenta un problema crítico de sincronización en la interfaz cliente: el estado del tablero no se actualiza
// automáticamente entre jugadores. Esto genera una experiencia confusa, ya que las acciones realizadas por un jugador no son
// visibles para el otro hasta que ambos interactúan con la interfaz. Este comportamiento indica la falta de un mecanismo de
// actualización en tiempo real en el cliente.

// ********************************
// Conclusiones: 
// * Aunque WCF soporta funcionalidades como Duplex Communication para notificaciones en tiempo real, estas no se están
//   aprovechando en esta implementación
// * El proyecto demuestra una implementación básica de comunicación cliente-servidor usando WCF, lo que valida su utilidad
//   para aplicaciones distribuidas de pequeña escala.
// * La falta de actualización automática del tablero compromete la experiencia del usuario, resaltando la importancia
//   de implementar mecanismos de sincronización en sistemas distribuidos.

// Recomendaciones:
// * El problema observado durante las pruebas indica que la falta de actualización automática del tablero entre los jugadores
//   afecta negativamente la experiencia. Se recomienda implementar un mecanismo de notificaciones del servidor para sincronizar
//   el estado del tablero en tiempo real utilizando el patrón Duplex en WCF, permitiendo que cada cliente sea informado inmediatamente
//   después de un movimiento.
// * Mejorar los mensajes en la interfaz gráfica del cliente. Por ejemplo, notificar al jugador actual cuando es su turno, y mostrar
//   un mensaje claro al jugador que espera cuando el tablero está siendo actualizado. Esto reduce la confusión observada durante las pruebas.
// ************************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace TicTacToe
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ServicioTicTacToe" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ServicioTicTacToe.svc or ServicioTicTacToe.svc.cs at the Solution Explorer and start debugging.
    // Clase que implementa el servicio WCF
    public class ServicioTicTacToe : IServicioTicTacToe
    {
        // Tablero de juego de 3x3
        private static char[,] tablero = new char[3, 3];
        private static char ganador = ' ';
        private static int jugadorActual = 1;
        private static Dictionary<int, char> jugadores = new Dictionary<int, char>();

        public void EmpezarJuego()
        {
            // Reinicia el tablero y los estados del juego
            tablero = new char[3, 3];
            ganador = ' ';
            jugadorActual = 1;
            // Limpia los jugadores registrados
            jugadores.Clear();
        }

        public bool Mover(int idJugador, int x, int y)
        {
            // Verifica si el jugador se encuentra registrado, si la celda esta ocupada o hay un ganador
            if (!jugadores.ContainsKey(idJugador) || tablero[x, y] != '\0' || ganador != ' ')
                return false;

            // Verifica si el jugador actual tiene el turno correcto
            if ((jugadorActual == 1 && jugadores[idJugador] == 'X') || (jugadorActual == 2 && jugadores[idJugador] == 'O'))
            {
                tablero[x, y] = jugadores[idJugador];
                jugadorActual = jugadorActual == 1 ? 2 : 1;
                ganador = DeterminarGanador() == "Nadie" ? ' ' : jugadores[idJugador];
                return true;
            }
            return false;
        }

        public string ObtenerTablero()
        {
            // Convierte el tablero en una cadena separada por comas
            return string.Join(",", tablero.Cast<char>().Select(c => c == '\0' ? ' ' : c));
        }

        public string DeterminarGanador()
        {
            // Verifica filas y columnas para encontrar un ganador
            for (int i = 0; i < 3; i++)
            {
                if (tablero[i, 0] == tablero[i, 1] && tablero[i, 1] == tablero[i, 2] && tablero[i, 0] != '\0')
                    return tablero[i, 0].ToString();
                if (tablero[0, i] == tablero[1, i] && tablero[1, i] == tablero[2, i] && tablero[0, i] != '\0')
                    return tablero[0, i].ToString();
            }

            // Verifica diagonales
            if (tablero[0, 0] == tablero[1, 1] && tablero[1, 1] == tablero[2, 2] && tablero[0, 0] != '\0')
                return tablero[0, 0].ToString();
            if (tablero[0, 2] == tablero[1, 1] && tablero[1, 1] == tablero[2, 0] && tablero[0, 2] != '\0')
                return tablero[0, 2].ToString();

            // Verifica si hay celdas vacias
            foreach (char celda in tablero)
                if (celda == '\0')
                    return "Nadie";

            // Si no hay ganador y no hay celdas vacías, es un empate
            return "Empate";
        }

        public int Unir()
        {
            // Registra un jugador en el juego, hasta un máximo de 2 jugadores
            if (jugadores.Count >= 2)
                return -1;

            // Asigna un nuevo ID al jugador
            int idJugador = jugadores.Count + 1;
            // Asocia el jugador con su símbolo
            jugadores.Add(idJugador, idJugador == 1 ? 'X' : 'O');
            // Devuelve el ID del jugador
            return idJugador;
        }
    }
}
