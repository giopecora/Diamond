using AutoMapper;
using Diamond.Domain.DTO;
using Diamond.Domain.Entities;
using Diamond.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diamond.Business
{
    public class EstoqueSaidaBusiness
    {
        private EstoqueSaidaRepository _repository = new EstoqueSaidaRepository();

        public int Insert(EstoqueSaidaDTO saida)
        {
            return _repository.Insert(Mapper.Map<Estoque_Saida>(saida));
        }
    }
}
