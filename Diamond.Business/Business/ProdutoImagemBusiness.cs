using AutoMapper;
using Diamond.Domain.DTO;
using Diamond.Domain.Entities;
using Diamond.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Diamond.Business
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

        public ProdutoImagemDTO GetByProdutoIdAndName(int produtoId, string imagem)
        {
            Produto_Imagens entity = _repository.GetByProductIdAndName(produtoId, imagem);

            return Mapper.Map<ProdutoImagemDTO>(entity);
        }

        public bool Insert(ProdutoImagemDTO imagem)
        {
            bool result = _repository.Update(Mapper.Map<Produto_Imagens>(imagem));

            if (!result)
                throw new Exception("Nao foi possivel atualizar este Produto.");

            return result;
        }

        public bool InsertRange(List<ProdutoImagemDTO> imagens)
        {
            bool result = _repository.InsertRange(Mapper.Map<List<Produto_Imagens>>(imagens));

            if (!result)
                throw new Exception("Nao foi possivel atualizar este Produto.");

            return result;
        }

        public bool Delete(int produtoId, string imagem)
        {
            ProdutoImagemDTO produto = GetByProdutoIdAndName(produtoId, imagem);

            return _repository.Delete(Mapper.Map<Produto_Imagens>(produto));
        }

        public bool Upload(List<ProdutoImagemDTO> imagens)
        {
            return InsertRange(imagens);
        }
    }
}
