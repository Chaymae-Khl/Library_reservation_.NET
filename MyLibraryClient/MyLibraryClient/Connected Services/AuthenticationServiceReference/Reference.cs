﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AuthenticationServiceReference
{
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Administrator", Namespace="http://schemas.datacontract.org/2004/07/MyLibraryService")]
    public partial class Administrator : object
    {
        
        private string ad_loginField;
        
        private string ad_nameField;
        
        private string ad_passwordField;
        
        private int idField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ad_login
        {
            get
            {
                return this.ad_loginField;
            }
            set
            {
                this.ad_loginField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ad_name
        {
            get
            {
                return this.ad_nameField;
            }
            set
            {
                this.ad_nameField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ad_password
        {
            get
            {
                return this.ad_passwordField;
            }
            set
            {
                this.ad_passwordField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="AuthenticationServiceReference.IAuthenticationService")]
    public interface IAuthenticationService
    {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAuthenticationService/Login", ReplyAction="http://tempuri.org/IAuthenticationService/LoginResponse")]
        AuthenticationServiceReference.Administrator Login([System.ServiceModel.MessageParameterAttribute(Name="login")] string login1, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAuthenticationService/Login", ReplyAction="http://tempuri.org/IAuthenticationService/LoginResponse")]
        System.Threading.Tasks.Task<AuthenticationServiceReference.Administrator> LoginAsync(string login, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAuthenticationService/GetName", ReplyAction="http://tempuri.org/IAuthenticationService/GetNameResponse")]
        string GetName(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAuthenticationService/GetName", ReplyAction="http://tempuri.org/IAuthenticationService/GetNameResponse")]
        System.Threading.Tasks.Task<string> GetNameAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAuthenticationService/register", ReplyAction="http://tempuri.org/IAuthenticationService/registerResponse")]
        void register(AuthenticationServiceReference.Administrator admin);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAuthenticationService/register", ReplyAction="http://tempuri.org/IAuthenticationService/registerResponse")]
        System.Threading.Tasks.Task registerAsync(AuthenticationServiceReference.Administrator admin);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    public interface IAuthenticationServiceChannel : AuthenticationServiceReference.IAuthenticationService, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    public partial class AuthenticationServiceClient : System.ServiceModel.ClientBase<AuthenticationServiceReference.IAuthenticationService>, AuthenticationServiceReference.IAuthenticationService
    {
        
        /// <summary>
        /// Implement this partial method to configure the service endpoint.
        /// </summary>
        /// <param name="serviceEndpoint">The endpoint to configure</param>
        /// <param name="clientCredentials">The client credentials</param>
        static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);
        
        public AuthenticationServiceClient() : 
                base(AuthenticationServiceClient.GetDefaultBinding(), AuthenticationServiceClient.GetDefaultEndpointAddress())
        {
            this.Endpoint.Name = EndpointConfiguration.BasicHttpBinding_IAuthenticationService.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public AuthenticationServiceClient(EndpointConfiguration endpointConfiguration) : 
                base(AuthenticationServiceClient.GetBindingForEndpoint(endpointConfiguration), AuthenticationServiceClient.GetEndpointAddress(endpointConfiguration))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public AuthenticationServiceClient(EndpointConfiguration endpointConfiguration, string remoteAddress) : 
                base(AuthenticationServiceClient.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public AuthenticationServiceClient(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(AuthenticationServiceClient.GetBindingForEndpoint(endpointConfiguration), remoteAddress)
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public AuthenticationServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress)
        {
        }
        
        public AuthenticationServiceReference.Administrator Login(string login1, string password)
        {
            return base.Channel.Login(login1, password);
        }
        
        public System.Threading.Tasks.Task<AuthenticationServiceReference.Administrator> LoginAsync(string login, string password)
        {
            return base.Channel.LoginAsync(login, password);
        }
        
        public string GetName(int id)
        {
            return base.Channel.GetName(id);
        }
        
        public System.Threading.Tasks.Task<string> GetNameAsync(int id)
        {
            return base.Channel.GetNameAsync(id);
        }
        
        public void register(AuthenticationServiceReference.Administrator admin)
        {
            base.Channel.register(admin);
        }
        
        public System.Threading.Tasks.Task registerAsync(AuthenticationServiceReference.Administrator admin)
        {
            return base.Channel.registerAsync(admin);
        }
        
        public virtual System.Threading.Tasks.Task OpenAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndOpen));
        }
        
        private static System.ServiceModel.Channels.Binding GetBindingForEndpoint(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_IAuthenticationService))
            {
                System.ServiceModel.BasicHttpBinding result = new System.ServiceModel.BasicHttpBinding();
                result.MaxBufferSize = int.MaxValue;
                result.ReaderQuotas = System.Xml.XmlDictionaryReaderQuotas.Max;
                result.MaxReceivedMessageSize = int.MaxValue;
                result.AllowCookies = true;
                return result;
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.EndpointAddress GetEndpointAddress(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_IAuthenticationService))
            {
                return new System.ServiceModel.EndpointAddress("http://localhost:49287/MyServices/AuthenticationService.svc");
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.Channels.Binding GetDefaultBinding()
        {
            return AuthenticationServiceClient.GetBindingForEndpoint(EndpointConfiguration.BasicHttpBinding_IAuthenticationService);
        }
        
        private static System.ServiceModel.EndpointAddress GetDefaultEndpointAddress()
        {
            return AuthenticationServiceClient.GetEndpointAddress(EndpointConfiguration.BasicHttpBinding_IAuthenticationService);
        }
        
        public enum EndpointConfiguration
        {
            
            BasicHttpBinding_IAuthenticationService,
        }
    }
}
