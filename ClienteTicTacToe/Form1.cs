using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClienteTicTacToe
{
    public partial class Form1 : Form
    {
        // Cliente WCF para comunicarse con el servicio
        private ReferenciaServicioTicTacToe.ServicioTicTacToeClient cliente;
        private int idJugador;
        private char jugadorActual;

        public Form1()
        {
            InitializeComponent();
            // Crea una instancia del cliente WCF
            cliente = new ReferenciaServicioTicTacToe.ServicioTicTacToeClient();
            idJugador = -1;
            jugadorActual = ' ';
            // Actualiza la interfaz gráfica con el estado inicial
            ActualizarTablero();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        // Metodo para actualizar la interfaz con el estado actual del tablero
        private void ActualizarTablero()
        {
            // Obtiene el tablero como una cadena
            var tableroCadena = cliente.ObtenerTablero();
            // Convierte la cadena en un arreglo
            var tablero = tableroCadena.Split(',').Select(c => c[0]).ToArray();
            // Asigna los valores del tablero a los botones de la interfaz
            btn00.Text = tablero[0].ToString();
            btn01.Text = tablero[1].ToString();
            btn02.Text = tablero[2].ToString();
            btn10.Text = tablero[3].ToString();
            btn11.Text = tablero[4].ToString();
            btn12.Text = tablero[5].ToString();
            btn20.Text = tablero[6].ToString();
            btn21.Text = tablero[7].ToString();
            btn22.Text = tablero[8].ToString();
            // Actualiza la etiqueta de estado
            lblEstado.Text = $"Jugador {idJugador}, Turno: {jugadorActual}";
        }

        // Metodo para iniciar un nuevo juego
        private void EmpezarJuegoNuevo()
        {
            // Llama al servicio para reiniciar el juego
            cliente.EmpezarJuego();
            // Actualiza el tablero con el estado inicial
            ActualizarTablero();
        }

        // Metodo para manejar los movimientos de los jugadores
        private void Movimiento(int x, int y, Button btn)
        {
            // Realiza el movimiento en el servicio
            if (cliente.Mover(idJugador, x, y))
            {
                btn.Text = jugadorActual.ToString();
                string ganador = cliente.DeterminarGanador();
                // Verifica si hay un ganador o un empate
                if (ganador != "Nadie")
                {
                    lblEstado.Text = ganador == "Empate" ? "Es un empate!" : $"{ganador} gana!";
                    return;
                }
                jugadorActual = jugadorActual == 'X' ? 'O' : 'X';
                // Actualiza el estado
                lblEstado.Text = $"Jugador {idJugador}, Turno: {jugadorActual}";
            }
            ActualizarTablero();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            EmpezarJuegoNuevo();
        }

        // Evento que se ejecuta al hacer clic en el botoon para unirse al juego
        private void btnUnir_Click(object sender, EventArgs e)
        {
            idJugador = cliente.Unir();
            if (idJugador == -1)
            {
                lblEstado.Text = "El juego está lleno...";
                return;
            }
            jugadorActual = idJugador == 1 ? 'X' : 'O';
            lblEstado.Text = $"Jugador {idJugador}, Turno: {jugadorActual}";
        }

        // Evento que se ejecuta al hacer clic en cualquier boton
        private void btn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int x = int.Parse(btn.Name[3].ToString());
            int y = int.Parse(btn.Name[4].ToString());
            Movimiento(x, y, btn);
        }

    }
}
