using System;

namespace StorageLog.Model
{
    public class LogAplicacao
    {
        public long Identificador { get; set; }
        public DateTime DataHora { get; set; }
        public string MensagemErro { get; set; }
        public string RastreioErro { get; set; }
        public string NomeMaquina { get; set; }
        public string NomeAplicacao { get; set; }
        public string Usuario { get; set; }
    }
}
