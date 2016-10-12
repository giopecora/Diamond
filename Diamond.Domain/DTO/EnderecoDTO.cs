using Diamond.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diamond.Domain.DTO
{
    public class EnderecoDTO
    {
        public EnderecoDTO()
        {

        }

        public EnderecoDTO(Endereco entity)
        {
            Id = entity.ID_Endereco;
            Logradouro = entity.NM_Logradouro;
            Endereco = entity.NM_Endereco;
            Numero = entity.NR_Endereco;
            Complemento = entity.DS_Complemento;
            CEP = entity.NR_CEP;
            Cidade = entity.NM_Cidade;
            Sigla = entity.DS_Sigla;
            TipoEndereco = entity.NR_Tipo_Endereco;
        }

        public Endereco ToEntity()
        {
            return new Endereco()
            {
                ID_Endereco = Id,
                NM_Logradouro = Logradouro,
                NM_Endereco = Endereco,
                NR_Endereco = Numero,
                DS_Complemento = Complemento,
                NR_CEP = CEP,
                NM_Cidade = Cidade,
                DS_Sigla = Sigla,
                NR_Tipo_Endereco = TipoEndereco
            };
        }

        public int Id { get; set; }
        public string Logradouro { get; set; }
        public string Endereco { get; set; }
        public int? Numero { get; set; }
        public string Complemento { get; set; }
        public string CEP { get; set; }
        public string Cidade { get; set; }
        public string Sigla { get; set; }
        public int? TipoEndereco { get; set; }
    }
}
