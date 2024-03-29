﻿using Data.DataAccess.Repositories.Interfaces;
using Data.DataModels.Entities;
using Cookbook.Web.Models.Countries.BindingModels;
using Cookbook.Web.Models.Countries.ViewModels;
using Cookbook.Web.Models.Recipes.ViewModels;

namespace Cookbook.Business.Services.Countries
{
    public class CountryService : ICountryService
    {
        private readonly ICountryRepository _countryRepository;

        public CountryService(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }

        public List<Country> GetAllCountries()
        {
            return _countryRepository.GetAllAsNoTracking().ToList();
        }

        public IEnumerable<AllCountriesViewModel> GetAllCountriesWithRelatedData()
        {
            List<AllCountriesViewModel> allCountries = _countryRepository
                .GetAllAsNoTracking()
                    .OrderBy(c => c.Name)
                    .Select(c => new AllCountriesViewModel
                    {
                        Id = c.Id,
                        Name = c.Name,
                        RelatedRecipes = c.Recipes
                            .Select(r => new RecipeConciseInformationViewModel
                            {
                                Title = r.Title
                            })
                    })
                    .ToList();

            return allCountries;
        }

        public CountryDetailsViewModel GetCountryDetails(string countryId)
        {
            var singleCountry = _countryRepository
                  .GetAllByCondition(c => c.Id == countryId)
                      .FirstOrDefault();

            if (singleCountry is null)
            {
                return null;
            }

            var singleCountryDetails = new CountryDetailsViewModel
            {
                Id = singleCountry.Id,
                Name = singleCountry.Name,
                CreatedOn = singleCountry.CreatedOn,
                CreatedBy = singleCountry.CreatedBy,
                ModifiedOn = singleCountry.ModifiedOn,
                ModifiedBy = singleCountry.ModifiedBy,
                RelatedRecipes = singleCountry.Recipes
                    .Select(r => new RecipeDetailedInformationViewModel
                    {
                        Title = r.Title,
                        Servings = r.Servings,
                        CreatedOn = r.CreatedOn
                    })
            };

            return singleCountryDetails;
        }

        public bool CreateCountry(CreateCountryBindingModel createCountryBindingModel, string currentUserName)
        {
            Country countryToCreate = new Country
            {
                Name = createCountryBindingModel.Name
            };

            var allCountries = _countryRepository.GetAllAsNoTracking();

            if (_countryRepository.Exists(allCountries, countryToCreate))
            {
                return false;
            }

            countryToCreate.CreatedBy = currentUserName;

            _countryRepository.Add(countryToCreate);

            return true;
        }

        public EditCountryBindingModel GetCountryEditingDetails(string countryId)
        {
            var countryToEdit = FindCountry(countryId);

            if (countryToEdit is null)
            {
                return null;
            }

            var countyToEditDetails = new EditCountryBindingModel
            {
                Id = countryToEdit.Id,
                Name = countryToEdit.Name
            };

            return countyToEditDetails;
        }

        public bool EditCountry(EditCountryBindingModel editCountryBindingModel, string currentUserName)
        {
            var countryToUpdate = FindCountry(editCountryBindingModel.Id);

            countryToUpdate.Name = editCountryBindingModel.Name;

            var filteredCountries = _countryRepository
                .GetAllAsNoTracking()
                .Where(c => !c.Id.Equals(countryToUpdate.Id));

            if (_countryRepository.Exists(filteredCountries, countryToUpdate))
            {
                return false;
            }

            countryToUpdate.ModifiedBy = currentUserName;

            _countryRepository.Update(countryToUpdate);

            return true;
        }

        public DeleteCountryViewModel GetCountryDeletionDetails(string countryId)
        {
            var countryToDelete = FindCountry(countryId);

            if (countryToDelete is null)
            {
                return null;
            }

            var countryToDeleteDetails = new DeleteCountryViewModel
            {
                Name = countryToDelete.Name
            };

            return countryToDeleteDetails;
        }

        public void DeleteCountry(Country country)
        {
            _countryRepository.Delete(country);
        }

        public Country FindCountry(string countryId)
        {
            return _countryRepository.GetById(countryId);
        }
    }
}
