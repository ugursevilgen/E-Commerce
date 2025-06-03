﻿using AutoMapper;
using E_Commerce.Catalog.Dtos.ProductImageDtos;
using E_Commerce.Catalog.Entities;
using E_Commerce.Catalog.Settings;
using MongoDB.Driver;

namespace E_Commerce.Catalog.Services.ProductImageServices
{
    public class ProductImageService:IProductImageService
    {
        private readonly IMongoCollection<ProductImage> _ProductImageCollection;
        private readonly IMapper _mapper;

        public ProductImageService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _ProductImageCollection = database.GetCollection<ProductImage>(_databaseSettings.ProductImageCollectionName);
            _mapper = mapper;
        }

        public async Task CreateProductImageAsync(CreateProductImageDto createProductImageDto)
        {
            var value = _mapper.Map<ProductImage>(createProductImageDto);
            await _ProductImageCollection.InsertOneAsync(value);
        }

        public async Task DeleteProductImageAsync(string id)
        {
            await _ProductImageCollection.DeleteOneAsync(x => x.ProductImageID == id);
        }

        public async Task<GetByIdProductImageDto> GetByIdProductImageAsync(string id)
        {
            var values = await _ProductImageCollection.Find<ProductImage>(x => x.ProductImageID == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdProductImageDto>(values);
        }

        public async Task<List<ResultProductImageDto>> GetlAllProductImageAsync()
        {
            var values = await _ProductImageCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultProductImageDto>>(values);
        }

        public async Task UpdateProductImageAsync(UpdateProductImageDto updateProductImageDto)
        {
            var values = _mapper.Map<ProductImage>(updateProductImageDto);
            await _ProductImageCollection.FindOneAndReplaceAsync(x => x.ProductImageID == updateProductImageDto.ProductImageID, values);
        }
    }
}
