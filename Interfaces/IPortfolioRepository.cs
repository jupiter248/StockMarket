using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using Api.Models;

namespace api.Interfaces
{
    public interface IPortfolioRepository
    {
        Task<List<Stock>> GetUserPortfolioAsync(AppUser appUser);  
        Task<Portfolio> CreateAsync(Portfolio portfolio);
        Task<Portfolio?> DeleteAsync(Portfolio portfolio);

    }
}