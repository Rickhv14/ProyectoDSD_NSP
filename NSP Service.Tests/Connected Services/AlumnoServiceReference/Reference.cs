﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NSP_Service.Tests.AlumnoServiceReference {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="AlumnoServiceReference.IAlumnoService")]
    public interface IAlumnoService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAlumnoService/ConsultarNota", ReplyAction="http://tempuri.org/IAlumnoService/ConsultarNotaResponse")]
        string ConsultarNota(string dni, string codigo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAlumnoService/ConsultarNota", ReplyAction="http://tempuri.org/IAlumnoService/ConsultarNotaResponse")]
        System.Threading.Tasks.Task<string> ConsultarNotaAsync(string dni, string codigo);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IAlumnoServiceChannel : NSP_Service.Tests.AlumnoServiceReference.IAlumnoService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class AlumnoServiceClient : System.ServiceModel.ClientBase<NSP_Service.Tests.AlumnoServiceReference.IAlumnoService>, NSP_Service.Tests.AlumnoServiceReference.IAlumnoService {
        
        public AlumnoServiceClient() {
        }
        
        public AlumnoServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public AlumnoServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public AlumnoServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public AlumnoServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string ConsultarNota(string dni, string codigo) {
            return base.Channel.ConsultarNota(dni, codigo);
        }
        
        public System.Threading.Tasks.Task<string> ConsultarNotaAsync(string dni, string codigo) {
            return base.Channel.ConsultarNotaAsync(dni, codigo);
        }
    }
}
