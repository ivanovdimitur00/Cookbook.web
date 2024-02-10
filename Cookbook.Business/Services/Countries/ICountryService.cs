using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.DataModels.Entities;
using Cookbook.Web.Models.Countries.BindingModels;
using Cookbook.Web.Models.Countries.ViewModels;

namespace Cookbook.Business.Services.Countries
{
    public interface ICountryService
    {
        List<Country> GetAllCountries();

        IEnumerable<AllCountriesViewModel> GetAllCountriesWithRelatedData();

        CountryDetailsViewModel GetCountryDetails(string countryId);

        bool CreateCountry(CreateCountryBindingModel createCountryBindingModel, string currentUserName);

        EditCountryBindingModel GetCountryEditingDetails(string countryId);

        bool EditCountry(EditCountryBindingModel editCountryBindingModel, string currentUserName);

        DeleteCountryViewModel GetCountryDeletionDetails(string countryId);

        void DeleteCountry(Country country);

        Country FindCountry(string countryId);
    }
}
