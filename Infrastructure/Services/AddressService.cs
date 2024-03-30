using Infrastructure.Entites;
using Infrastructure.Factories;
using Infrastructure.Models;
using Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class AddressService
    {
        private readonly AddressRepository _addressRepository;

        public AddressService(AddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }
        public async Task<ResponseResult> GetOrCreateAddressAsync(string streetName, string postalCode, string city)
        {

            try
            {
                var result =await GetAddressAsync(streetName, postalCode, city);
                if (result.StausCode == StatusCode.NotFound)
                    result = await CreateAddressAsync(streetName, postalCode, city);

                return result;

            }
            catch (Exception ex)
            {
                return ResponseFactory.Error(ex.Message);
            }
        }
        public async Task<ResponseResult> CreateAddressAsync(string streetName, string postalCode, string city)
        {

            try
            {
                var exists = await _addressRepository.ExistesAsync(x => x.StreetName == streetName && x.PostalCode == postalCode && x.City == city);
                if (exists == null)
                {
                    var result = await _addressRepository.CreateAsync(AddressFactory.CreateAddress(streetName, postalCode, city));
                    if (result.StausCode == StatusCode.Ok)
                    
                      return  ResponseFactory.Ok(AddressFactory.CreateAddress((AddressEntity)result.ContentResult!));
                    return result;
                }
                return exists;
            }
            catch (Exception ex)
            {
                return ResponseFactory.Error(ex.Message);
            }
        }


        public async Task<ResponseResult> GetAddressAsync(string streetName,string postalCode,string city)
        {

            try
            {
                var result = await _addressRepository.GetOneAsync(x => x.StreetName == streetName && x.PostalCode == postalCode && x.City == city);
                return result;
           
             }
            catch (Exception ex)
            {
                return ResponseFactory.Error(ex.Message);
            }
        }

    }
}
