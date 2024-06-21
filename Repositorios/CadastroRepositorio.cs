using Api.Data;
using Api.Models;
using Api.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Api.Repositorios
{
    public class CadastroRepositorio : ICadastroRepositorio
    {
        private readonly Contexto _dbContext;

        public CadastroRepositorio(Contexto dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<CadastroModel>> GetAll()
        {
            return await _dbContext.Cadastro.ToListAsync();
        }

        public async Task<CadastroModel> GetById(int id)
        {
            return await _dbContext.Cadastro.FirstOrDefaultAsync(x => x.CadastroId == id);
        }

        public async Task<CadastroModel> InsertCadastro(CadastroModel cadastro)
        {
            await _dbContext.Cadastro.AddAsync(cadastro);
            await _dbContext.SaveChangesAsync();
            return cadastro;
        }

        public async Task<CadastroModel> UpdateCadastro(CadastroModel cadastro, int id)
        {
            CadastroModel Cadastro = await GetById(id);
            if (cadastro == null)
            {
                throw new Exception("Não encontrado.");
            }
            else
            {
                cadastro.CadastroNome = cadastro.CadastroNome;
                cadastro.Cnpj = cadastro.Cnpj;
                cadastro.Telefone = cadastro.Telefone;
                cadastro.Localidade = cadastro.Localidade;
                cadastro.Descrição = cadastro.Descrição;
                cadastro.Foto = cadastro.Foto;
                _dbContext.Cadastro.Update(cadastro);
                await _dbContext.SaveChangesAsync();
            }
            return cadastro;

        }

        public async Task<bool> DeleteCadastro(int id)
        {
            CadastroModel cadastro = await GetById(id);
            if (cadastro == null)
            {
                throw new Exception("Não encontrado.");
            }

            _dbContext.Cadastro.Remove(cadastro);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
