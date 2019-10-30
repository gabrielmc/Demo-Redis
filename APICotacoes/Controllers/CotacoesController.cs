using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Caching.Distributed;
using System.Data.SqlClient;
using Dapper;

namespace APICotacoes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CotacoesController : ControllerBase
    {
        [HttpGet]
        public ContentResult Get( [FromServices]IConfiguration config, [FromServices]IDistributedCache cache)
        {
            string valorJSON = cache.GetString("Cotacoes");
            if (valorJSON == null)
            {
                using (SqlConnection conexao = new SqlConnection(config.GetConnectionString("BaseCotacoes")))
                {
                    valorJSON = conexao.QueryFirst<string>(
                        "SELECT Sigla " +
                              ",NomeMoeda " +
                              ",UltimaCotacao " +
                              ",GETDATE() AS DataProcessamento " +
                              ",ValorComercial AS 'Cotacoes.Comercial' " +
                              ",ValorTurismo AS 'Cotacoes.Turismo' " +
                        "FROM dbo.Cotacoes " +
                        "ORDER BY NomeMoeda " +
                        "FOR JSON PATH, ROOT('Moedas')");
                }

                DistributedCacheEntryOptions opcoesCache = new DistributedCacheEntryOptions();
                opcoesCache.SetAbsoluteExpiration(TimeSpan.FromMinutes(3));
                cache.SetString("Cotacoes", valorJSON, opcoesCache);
            }
            return Content(valorJSON, "application/json");
        }
    }
}

