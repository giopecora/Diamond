using System;
using System.Collections.Generic;
using Diamond.Repository;
using Diamond.Domain.Entities;
using Diamond.Domain.DTO;
using AutoMapper;
using Diamond.Business;
using System.Web;
using Diamond.Domain.Models.Produto;

namespace Diamond.Business
{
    public class ProdutoBusiness
    {
        private ProdutoRepository _repository = new ProdutoRepository();

        public List<ProdutoDTO> SearchForProducts(string search)
        {
            return _repository.SearchForProducts(search).ToDTO<Produto, ProdutoDTO>();
        }

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

        public List<ProdutoDTO> GetAll(Filtro filtro, int page)
        {
            return _repository.GetAll(filtro.MontarQuery(), page).ToDTO<Produto, ProdutoDTO>();
        }

        public List<ProdutoDTO> ListAll(int page)
        {
            return _repository.ListAll(page).ToDTO<Produto, ProdutoDTO>();
        }

        public List<ProdutoDTO> ListAllByName(int page, string name)
        {
            return _repository.ListAllByName(page, name).ToDTO<Produto, ProdutoDTO>();
        }

        public List<ProdutoDTO> GetAllByCategoryId(int categoryId, int page)
        {
            return _repository.GetAllByCategoryId(categoryId, page).ToDTO<Produto, ProdutoDTO>();
        }

        public List<int> GetCount()
        {
            var list = new List<int>();
            list.Add(_repository.GetCount());

            return list;
        }

        public List<int> GetCountByName(string name)
        {
            var list = new List<int>();
            list.Add(_repository.GetCountByName(name));

            return list;
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
            produto.Ativo = true;
            produto.SetImagemSemProduto();
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

        public void UploadImagemPrincipal(int produtoID, string imageName)
        {
            ProdutoDTO produto = GetById(produtoID);
            produto.ImagemPrincipal = imageName;

            Update(produto);
        }

        public void Delete(int id)
        {
            ProdutoDTO produto = GetById(id);
            produto.Ativo = false;

            Update(produto);
        }
    }
}
