using AutoMapper;
using Diamond.Domain.DTO;
using Diamond.Domain.Entities;
using Diamond.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diamond.Business.Business
{
    public class ProdutoImagemBusiness
    {
        private ProdutoImagemRepository _repository = new ProdutoImagemRepository();

        public List<ProdutoImagemDTO> ListImagesByProductId(int productId)
        {
            List<ProdutoImagemDTO> imagens = new List<ProdutoImagemDTO>();
            List<Produto_Imagens> entities = _repository.ListImagesByProductId(productId);

            foreach (Produto_Imagens entity in entities)
            {
                imagens.Add(Mapper.Map<ProdutoImagemDTO>(entity));
            }

            return imagens;
        }
    }
}
