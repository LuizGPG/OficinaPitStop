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

        public Marca ObterPorId(int codigoMarca) =>
            _marcaRepository.ObterPorId(codigoMarca);

        public async Task<IEnumerable<Marca>> ObterPorNome(string descricao) =>
            await _marcaRepository.ObterPorNome(descricao);

        public bool Adiciona(Marca marca) =>
            _marcaRepository.Adiciona(marca);

        public bool Atualiza(Marca marca)
        {
            if ((_marcaRepository.ObterPorId(marca.CodigoMarca)) != null)
                return _marcaRepository.Atualiza(marca);

            throw new NotFoundExepction("Marca não encontrada para deletar!");
        }

        public bool Deleta(Marca marca)
        {
            if ((_marcaRepository.ObterPorId(marca.CodigoMarca)) != null)
                return _marcaRepository.Deleta(marca);

            throw new NotFoundExepction("Marca não encontrada para deletar!");
        }
    }
}