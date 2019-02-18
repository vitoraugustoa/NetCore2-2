using System;
using Microsoft.Extensions.Configuration;

namespace AspnCore22Empty_NetCli.Services
{
    public class ConfigurationMensagemService : IMensageService
    {
        private IConfiguration _config;

        public ConfigurationMensagemService(IConfiguration config)
        {
            _config = config;
        }
        
        public string GetMensagem()
        {
            return _config["Mensagem"];
        }
    }
}