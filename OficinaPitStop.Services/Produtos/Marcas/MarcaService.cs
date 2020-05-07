using System.Collections.Generic;
using OficinaPitStop.Entities.Produtos.Marcas;
using OficinaPitStop.Repositories.Abstractions.Repository.Produtos.Marcas;
using OficinaPitStop.Services.Abstractions.Produtos.Marcas;

namespace OficinaPitStop.Services.Produtos.Marcas
{
    public class MarcaService : IMarcaService
    {
        private readonly IMarcaRepository _marcaRepository;

        public MarcaService(IMarcaRepository marcaRepository)
        {
            _marcaRepository = marcaRepository;
        }

        public IEnumerable<Marca> ObterTodos() =>
            _marcaRepository.ObterTodos();

        public Marca ObterPorId(int codigoMarca) =>
            _marcaRepository.ObterPorId(codigoMarca);

        public IEnumerable<Marca> ObterPorNome(string descricao) =>
            _marcaRepository.ObterPorNome(descricao);

        public bool Adiciona(Marca marca) =>
            _marcaRepository.Adiciona(marca);

        public bool Atualiza(Marca marca) =>
            _marcaRepository.Atualiza(marca);

        public bool Deleta(Marca marca) =>
            _marcaRepository.Deleta(marca);
    }
}