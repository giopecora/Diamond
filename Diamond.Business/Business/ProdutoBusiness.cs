using System;
using System.Collections.Generic;
using Diamond.Repository;
using Diamond.Domain.Entities;
using Diamond.Domain.DTO;
using AutoMapper;
using Diamond.Business.Business;

namespace Diamond.Business
{
    public class ProdutoBusiness
    {
        private ProdutoRepository _repository = new ProdutoRepository();

        public List<ProdutoDestaqueDTO> GetTop5()
        {
            return _repository.GetTop5();
        }

        public List<ProdutoDTO> GetTop3CheaperByCategory(int categoryId)
        {
            List<Produto> entities = _repository.GetTop3CheaperByCategory(categoryId);
            List<ProdutoDTO> produtos = Mapper.Map<List<ProdutoDTO>>(entities);

            return produtos;
        }

        public List<ProdutoDTO> GetAll()
        {
            return _repository.GetAll().ToDTO<Produto, ProdutoDTO>();
        }

        public List<ProdutoDTO> GetAllByCategoryId(int categoryId, int page)
        {
            return _repository.GetAllByCategoryId(categoryId, page).ToDTO<Produto, ProdutoDTO>();
        }

        public ProdutoDTO GetById(int id)
        {
            Produto entity = _repository.GetById(id);

            if (entity == null)
                throw new Exception("Este Produto nao existe!");

            ProdutoDTO produto = Mapper.Map<ProdutoDTO>(entity);
            produto.Imagens = new ProdutoImagemBusiness().ListImagesByProductId(produto.Id);

            return produto;
        }

        public ProdutoDTO Insert(ProdutoDTO produto)
        {
            Produto entity = _repository.Insert(Mapper.Map<Produto>(produto));

            produto.Id = entity.Id;

            return produto;
        }

        public void Update(ProdutoDTO produto)
        {
            bool result = _repository.Update(Mapper.Map<Produto>(produto));

            if (!result)
                throw new Exception("Nao foi possivel atualizar este Produto.");
        }

        public void Delete(int id)
        {
            ProdutoDTO produto = GetById(id);
            produto.Ativo = false;

            Update(produto);
        }
    }
}
