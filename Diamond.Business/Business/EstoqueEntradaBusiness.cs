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
    public class EstoqueEntradaBusiness
    {
        private EstoqueEntradaRepository _repository = new EstoqueEntradaRepository();

        public int Insert(EstoqueEntradaDTO entrada)
        {
            return _repository.Insert(Mapper.Map<Estoque_Entrada>(entrada));
        }
    }
}
