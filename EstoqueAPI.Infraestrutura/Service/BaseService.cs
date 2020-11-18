using Dados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstoqueAPI.Infraestrutura
{
    public class BaseService<T> : IService<T> where T : ModeloBase
    {
        private readonly IRepository<T> repository;

        public BaseService(IRepository<T> repository)
        {
            this.repository = repository;
        }

        public async Task<T> Create(T modelBase)
        {
            await this.repository.Add(modelBase);
            return modelBase;
        }

        public async Task Delete(Guid id)
        {
            var item = await this.repository.GetById(id);
            if (item != null)
                await this.repository.Delete(item);
        }

        public async Task<IList<T>> GetAll()
        {
            var list = await this.repository.List();
            return list.ToList();
        }

        public async Task<T> GetByID(Guid id)
        {
            return await this.repository.GetById(id);
        }

        public async Task<T> Update(T modelBase)
        {
            await this.repository.Update(modelBase);
            return modelBase;
        }
    }
}

