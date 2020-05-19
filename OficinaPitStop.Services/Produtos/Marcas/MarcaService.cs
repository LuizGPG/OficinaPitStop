using System;
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

        public Marca ObterPorId(int codigoMarca)
        {
            var marca = _marcaRepository.ObterPorId(codigoMarca);
            if (marca == null)
                throw new NotFoundExepction(Marca.MarcaNaoEncontrada);

            return marca;
        }

        public async Task<IEnumerable<Marca>> ObterPorNome(string descricao) =>
            await _marcaRepository.ObterPorNome(descricao);

        public bool Adiciona(Marca marca) =>
            _marcaRepository.Adiciona(marca);

        public bool Atualiza(Marca marca)
        {
            try
            {
                ObterPorId(marca.CodigoMarca);
                return _marcaRepository.Atualiza(marca);
            }
            catch (NotFoundExepction)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new ArgumentException("Não foi possível atualizar marca. " + e);
            }
        }

        public bool Deleta(Marca marca)
        {
            try
            {
                ObterPorId(marca.CodigoMarca);
                return _marcaRepository.Deleta(marca);
            }
            catch (NotFoundExepction)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new ArgumentException("Não foi possível deletar marca. " + e);
            }
        }
    }
}