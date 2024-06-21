using Api.Data;
using Api.Models;
using Api.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Api.Repositorios
{
    public class LoginRepositorio : ILoginRepositorio
    {
        private readonly Contexto _dbContext;

        public LoginRepositorio(Contexto dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<LoginModel>> GetAll()
        {
            return await _dbContext.Login.ToListAsync();
        }

        public async Task<LoginModel> GetById(int id)
        {
            return await _dbContext.Login.FirstOrDefaultAsync(x => x.LoginId == id);
        }
        public async Task<LoginModel> Login(LoginModel login)
        {
            return await _dbContext.Login.FirstOrDefaultAsync(x => x.LoginNome == login.LoginNome && x.LoginSenha == login.LoginSenha);
        }

        public async Task<LoginModel> InsertLogin(LoginModel login)
        {
            await _dbContext.Login.AddAsync(login);
            await _dbContext.SaveChangesAsync();
            return login;
        }

        public async Task<LoginModel> UpdateLogin(LoginModel login, int id)
        {
            LoginModel Login = await GetById(id);
            if (login == null)
            {
                throw new Exception("Não encontrado.");
            }
            else
            {
                login.LoginNome = login.LoginNome;
                login.LoginSenha = login.LoginSenha;
                _dbContext.Login.Update(login);
                await _dbContext.SaveChangesAsync();
            }
            return login;

        }

        public async Task<bool> DeleteLogin(int id)
        {
            LoginModel login = await GetById(id);
            if (login == null)
            {
                throw new Exception("Não encontrado.");
            }

            _dbContext.Login.Remove(login);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
