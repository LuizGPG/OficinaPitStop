using System.Collections.Generic;
using System.Threading.Tasks;
using OficinaPitStop.Entities.Produtos.Marcas;
using OficinaPitStop.Repositories.Abstractions.Repository.Produtos.Marcas;
using OficinaPitStop.Services.Abstractions.Produtos.Marcas;
using OficinaPitStop.Services.Execptions;

namespace OficinaPitStop.Services.Produtos.Marcas
{
    public class MarcaService : IMarcaService
    {
        private readonly IMarcaRepository _marcaRepository;

        public MarcaService(IMarcaRepository marcaRepository)
        {
            _marcaRepository = marcaRepository;
        }

        public async Task<IEnumerable<Marca>> ObterTodos() =>
            await _marcaRepository.ObterTodos();

        public async Task<Marca> ObterPorId(int codigoMarca) =>
            await _marcaRepository.ObterPorId(codigoMarca);

        public async Task<IEnumerable<Marca>> ObterPorNome(string descricao) =>
            await _marcaRepository.ObterPorNome(descricao);

        public async Task<bool> Adiciona(Marca marca) =>
            await _marcaRepository.Adiciona(marca);

        public async Task<bool> Atualiza(Marca marca)
        {
            if ((await _marcaRepository.ObterPorId(marca.CodigoMarca)) != null)
                return await _marcaRepository.Atualiza(marca);
            
            throw new NotFoundExepction("Marca não encontrada para deletar!");
        }

        public async Task<bool> Deleta(Marca marca)
        {
            if ((await _marcaRepository.ObterPorId(marca.CodigoMarca)) != null)
                return await _marcaRepository.Deleta(marca);

            throw new NotFoundExepction("Marca não encontrada para deletar!");
        }
    }
}