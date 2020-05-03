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

        public IEnumerable<Marca> ObtemTodasAsMarcas() =>
            _marcaRepository.ObtemTodasAsMarcas();

        public Marca ObtemMarcaPorId(int codigoMarca) =>
            _marcaRepository.ObtemMarcaPorId(codigoMarca);

        public IEnumerable<Marca> ObterMarcasPorNome(string descricao) =>
            _marcaRepository.ObterMarcasPorNome(descricao);
    }
}