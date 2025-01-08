﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ClienteTicTacToe.ReferenciaServicioTicTacToe {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ReferenciaServicioTicTacToe.IServicioTicTacToe")]
    public interface IServicioTicTacToe {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicioTicTacToe/EmpezarJuego", ReplyAction="http://tempuri.org/IServicioTicTacToe/EmpezarJuegoResponse")]
        void EmpezarJuego();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicioTicTacToe/EmpezarJuego", ReplyAction="http://tempuri.org/IServicioTicTacToe/EmpezarJuegoResponse")]
        System.Threading.Tasks.Task EmpezarJuegoAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicioTicTacToe/Mover", ReplyAction="http://tempuri.org/IServicioTicTacToe/MoverResponse")]
        bool Mover(int idJugador, int x, int y);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicioTicTacToe/Mover", ReplyAction="http://tempuri.org/IServicioTicTacToe/MoverResponse")]
        System.Threading.Tasks.Task<bool> MoverAsync(int idJugador, int x, int y);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicioTicTacToe/ObtenerTablero", ReplyAction="http://tempuri.org/IServicioTicTacToe/ObtenerTableroResponse")]
        string ObtenerTablero();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicioTicTacToe/ObtenerTablero", ReplyAction="http://tempuri.org/IServicioTicTacToe/ObtenerTableroResponse")]
        System.Threading.Tasks.Task<string> ObtenerTableroAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicioTicTacToe/DeterminarGanador", ReplyAction="http://tempuri.org/IServicioTicTacToe/DeterminarGanadorResponse")]
        string DeterminarGanador();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicioTicTacToe/DeterminarGanador", ReplyAction="http://tempuri.org/IServicioTicTacToe/DeterminarGanadorResponse")]
        System.Threading.Tasks.Task<string> DeterminarGanadorAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicioTicTacToe/Unir", ReplyAction="http://tempuri.org/IServicioTicTacToe/UnirResponse")]
        int Unir();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicioTicTacToe/Unir", ReplyAction="http://tempuri.org/IServicioTicTacToe/UnirResponse")]
        System.Threading.Tasks.Task<int> UnirAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServicioTicTacToeChannel : ClienteTicTacToe.ReferenciaServicioTicTacToe.IServicioTicTacToe, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServicioTicTacToeClient : System.ServiceModel.ClientBase<ClienteTicTacToe.ReferenciaServicioTicTacToe.IServicioTicTacToe>, ClienteTicTacToe.ReferenciaServicioTicTacToe.IServicioTicTacToe {
        
        public ServicioTicTacToeClient() {
        }
        
        public ServicioTicTacToeClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ServicioTicTacToeClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServicioTicTacToeClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServicioTicTacToeClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public void EmpezarJuego() {
            base.Channel.EmpezarJuego();
        }
        
        public System.Threading.Tasks.Task EmpezarJuegoAsync() {
            return base.Channel.EmpezarJuegoAsync();
        }
        
        public bool Mover(int idJugador, int x, int y) {
            return base.Channel.Mover(idJugador, x, y);
        }
        
        public System.Threading.Tasks.Task<bool> MoverAsync(int idJugador, int x, int y) {
            return base.Channel.MoverAsync(idJugador, x, y);
        }
        
        public string ObtenerTablero() {
            return base.Channel.ObtenerTablero();
        }
        
        public System.Threading.Tasks.Task<string> ObtenerTableroAsync() {
            return base.Channel.ObtenerTableroAsync();
        }
        
        public string DeterminarGanador() {
            return base.Channel.DeterminarGanador();
        }
        
        public System.Threading.Tasks.Task<string> DeterminarGanadorAsync() {
            return base.Channel.DeterminarGanadorAsync();
        }
        
        public int Unir() {
            return base.Channel.Unir();
        }
        
        public System.Threading.Tasks.Task<int> UnirAsync() {
            return base.Channel.UnirAsync();
        }
    }
}
