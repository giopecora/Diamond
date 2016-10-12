using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Diamond.Repository;
using Diamond.Domain.DTO.Result;
using Diamond.Domain.Entities;
using Diamond.Domain.DTO;

namespace Diamond.Business
{
    public class ProdutoBusiness
    {
        private ProdutoRepository _repository = new ProdutoRepository();

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

            return result.SetData(new ProdutoDTO(entity));
        }

        public Result<ProdutoDTO> Insert(ProdutoDTO produto)
        {
            Result<ProdutoDTO> result = new Result<ProdutoDTO>();
            Produto entity = _repository.Insert(produto.ToEntity());

            produto.Id = entity.ID_Produto;

            return result.SetData(produto);
        }

        public Result<bool> Update(int id, ProdutoDTO produto)
        {
            Result<bool> result = new Result<bool>();

            result = _repository.Update(id, produto.ToEntity());

            if (!result.Success)
                result.SetFailure("Nao foi possivel atualizar este Produto.");

            return result;
        }

        public Result<bool> Delete(int id)
        {
            Result<bool> result = new Result<bool>();

            //result.Success = _repository.Delete(id);

            if (!result.Success)
                result.SetFailure("Nao foi possivel excluir este produto");

            return result;
        }
    }
}
