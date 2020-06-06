using System.Collections.Generic;

namespace Artes.Models
{
    public class Estado
    {
        public string Nome { get; set; }
        public string Sigla { get; set; }
    }

    public class Estados
    {
        public static List<Estado> GetEstados()
        {
            var listaEstados = new List<Estado>()
            {
                new Estado(){ Sigla="AL", Nome="Alagoas"},
                new Estado(){ Sigla="BA", Nome="Bahia"},
                new Estado(){ Sigla="CE", Nome="Ceará"},
                new Estado(){ Sigla="DF", Nome="Distrito Federal"},
                new Estado(){ Sigla="ES", Nome="Espirito Santo"},
                new Estado(){ Sigla="GO", Nome="Goiás"},
                new Estado(){ Sigla="MG", Nome="Minas Gerais"},
                new Estado(){ Sigla="PR", Nome="Paraná"},
                new Estado(){ Sigla="RS", Nome="Rio Grande do Sul"},
                new Estado(){ Sigla="SP", Nome="São Paulo"},
                new Estado(){ Sigla="TO", Nome="Tocantins"}
            };
            return listaEstados;
        }
    }
}
