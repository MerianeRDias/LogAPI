using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace StorageLog.Controllers
{
    [ApiController]
    public class LogAplicacaoController : ControllerBase
    {
        private readonly Conexoes.Sql _sql;

        public LogAplicacaoController()
        {
            _sql = new Conexoes.Sql();
        }

        [HttpPost("v1/LogAplicacao")]
        public IActionResult CadastrarLog(Model.LogAplicacao log)
        {
            try
            {
                
                if (string.IsNullOrWhiteSpace(log.MensagemErro) || log.MensagemErro.Length > 1000 || log.MensagemErro.Length <= 3)
                {
                    throw new InvalidOperationException("Mensagem de erro inválida!");
                }

                if (string.IsNullOrWhiteSpace(log.RastreioErro) || log.RastreioErro.Length > 3000 || log.RastreioErro.Length <= 3)
                {
                    throw new InvalidOperationException("Rastreio de erro inválido!");
                }

                if (string.IsNullOrWhiteSpace(log.NomeMaquina) || log.NomeMaquina.Length > 80 || log.NomeMaquina.Length <= 1)
                {
                    throw new InvalidOperationException("Nome da máquina inválido!");
                }

                if (string.IsNullOrWhiteSpace(log.NomeAplicacao) || log.NomeAplicacao.Length > 80 || log.NomeAplicacao.Length <= 1)
                {
                    throw new InvalidOperationException("Nome da aplicação inválido!");
                }

                if (string.IsNullOrWhiteSpace(log.Usuario) || log.Usuario.Length > 80 || log.Usuario.Length <= 1)
                {
                    throw new InvalidOperationException("Usuário inválido!");
                }

                _sql.CadastrarLogAplicacao(log);

                return StatusCode(200);
            }
            catch (InvalidOperationException ex)
            {
                return StatusCode(400, ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }

        }
    }
}
