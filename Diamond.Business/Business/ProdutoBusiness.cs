using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Diamond.Repository;
using Diamond.Domain.DTO.Result;
using Diamond.Domain.Entities;
using Diamond.Domain.DTO;
using AutoMapper;

namespace Diamond.Business
{
    public class ProdutoBusiness
    {
        private ProdutoRepository _repository = new ProdutoRepository();

        public Result<List<ProdutoDestaqueDTO>> GetTop5()
        {
            return new Result<List<ProdutoDestaqueDTO>>().SetData(_repository.GetTop5());
        }

        public Result<List<ProdutoDestaqueDTO>> GetTop4OfAllCategories()
        {
            return new Result<List<ProdutoDestaqueDTO>>().SetData(_repository.GetTop4OfAllCategories());
        }

        public Result<List<ProdutoDTO>> GetTop3CheaperByCategory(int categoryId)
        {
            List<Produto> entities = _repository.GetTop3CheaperByCategory(categoryId);
            List<ProdutoDTO> produtos = Mapper.Map<List<ProdutoDTO>>(entities);

            return new Result<List<ProdutoDTO>>().SetData(produtos);
        }

        public Result<List<ProdutoDTO>> GetAll()
        {
            Result<List<ProdutoDTO>> result = new Result<List<ProdutoDTO>>();
            List<ProdutoDTO> produtos = _repository.GetAll().ToDTO<Produto, ProdutoDTO>();

            return result.SetData(produtos);
        }

        public Result<List<ProdutoDTO>> GetAllByCategoryId(int categoryId)
        {
            Result<List<ProdutoDTO>> result = new Result<List<ProdutoDTO>>();
            List<ProdutoDTO> produtos = _repository.GetAllByCategoryId(categoryId).ToDTO<Produto, ProdutoDTO>();

            return result.SetData(produtos);
        }

        public Result<ProdutoDTO> GetById(int id)
        {
            Result<ProdutoDTO> result = new Result<ProdutoDTO>();
            Produto entity = _repository.GetById(id);

            if (entity == null)
                return result.SetFailure("Este Produto nao existe!");

            return result.SetData(Mapper.Map<ProdutoDTO>(entity));
        }

        public Result<ProdutoDTO> Insert(ProdutoDTO produto)
        {
            Result<ProdutoDTO> result = new Result<ProdutoDTO>();
            Produto entity = _repository.Insert(Mapper.Map<Produto>(produto));

            produto.Id = entity.Id;

            return result.SetData(produto);
        }

        public Result<bool> Update(int id, ProdutoDTO produto)
        {
            Result<bool> result = new Result<bool>();

            result = _repository.Update(id, Mapper.Map<Produto>(produto));

            if (!result.Success)
                result.SetFailure("Nao foi possivel atualizar este Produto.");

            return result;
        }

        public Result<bool> Delete(int id)
        {
            Result<bool> result = new Result<bool>();

            ProdutoDTO produto = GetById(id).Data;
            produto.Ativo = false;

            result = Update(id, produto);

            if (!result.Success)
                result.SetFailure("Nao foi possivel excluir este produto");

            return result;
        }
    }
}
