using System.Data.SqlClient;

namespace StorageLog.Conexoes
{
    public class Sql
    {
        private readonly SqlConnection _conexao;

        public Sql()
        {
            string conexao = System.IO.File.ReadAllText(@"C:\Users\Meriane\Documents\RumoAcademy\VisualStudio\conexao\stringConexaoStorage.txt");
            this._conexao = new SqlConnection(conexao);

        }

        public void CadastrarLogAplicacao(Model.LogAplicacao log)
        {
            try
            {
                _conexao.Open();

                string sql = @"INSERT INTO LogAplicacao
                                (DataHora,MensagemErro,RastreioErro,NomeMaquina,NomeAplicacao,Usuario)
                               VALUES
                                (@dataHora, @mensagemErro, @rastreioErro, @nomeMaquina, @nomeAplicacao, @usuario);";

                using (SqlCommand cmd = new SqlCommand(sql, _conexao))
                {
                    cmd.Parameters.AddWithValue("dataHora", log.DataHora);
                    cmd.Parameters.AddWithValue("mensagemErro", log.MensagemErro);
                    cmd.Parameters.AddWithValue("rastreioErro", log.RastreioErro);
                    cmd.Parameters.AddWithValue("nomeMaquina", log.NomeMaquina);
                    cmd.Parameters.AddWithValue("nomeAplicacao", log.NomeAplicacao);
                    cmd.Parameters.AddWithValue("usuario", log.Usuario);
                    cmd.ExecuteNonQuery();
                }
            }

            finally
            {
                _conexao.Close();
            }

        }
    }
}
