﻿using Microsoft.EntityFrameworkCore;
using MK.RequirementsApp.Application.Interfaces;
using MK.RequirementsApp.Domain;
using MK.RequirementsApp.Infrastructure.Contexts;

namespace MK.RequirementsApp.Infrastructure.Repositories
{
    public class ImagesRepository : IImagesRepository
    {

        private readonly RequirementsContext context;
        public ImagesRepository(RequirementsContext context)
        {
            this.context = context;
        }
        public async Task<Image> Create(Image newImage)
        {
            await context.Images.AddAsync(newImage);
            return newImage;
        }

        public async Task<IEnumerable<Image>> GetAll()
        {
            return await context.Images.ToListAsync();
        }

        public async Task Delete(int imageId)
        {
            var image = await context.Images.FirstOrDefaultAsync(p => p.Id == imageId);
            context.Images.Remove(image);
        }
    }
}
