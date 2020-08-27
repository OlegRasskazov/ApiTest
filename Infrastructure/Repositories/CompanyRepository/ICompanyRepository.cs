﻿using Infrastructure.Dto.Filters;
using Infrastructure.Models;

namespace Infrastructure.Repositories.CompanyRepository
{
    public interface ICompanyRepository
    {
        Company GetCompanyById(int id);

        Company[] GetCompanies(Filter filter);
    }
}
