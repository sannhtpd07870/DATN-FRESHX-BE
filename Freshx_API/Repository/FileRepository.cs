using Freshx_API.Dtos;
using Freshx_API.Interfaces;
using Freshx_API.Models;
using AutoMapper; 
using Microsoft.EntityFrameworkCore;
using Freshx_API.Services;

namespace Freshx_API.Repository
{
    public class FileRepository : IFilesRepository
    {
        private readonly BlobServices _blobService;
        private readonly FreshxDBContext _dbContext;
        private readonly IMapper _mapper;
        public FileRepository(BlobServices blobService, FreshxDBContext dbContext, IMapper mapper)
        {
            _blobService = blobService;
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<Savefile> CreateFile(FileDto fileDto)
        {
       
            if (fileDto.file != null)
            {
                using (var stream = fileDto.file.OpenReadStream())
                {
                    fileDto.fileName = fileDto.file.FileName;
                    fileDto.urlFile = await _blobService.UploadFileAsync(fileDto.file.FileName, stream);
                }
            }
            var saveFile = _mapper.Map<Savefile>(fileDto);
            await _dbContext.Savefiles.AddAsync(saveFile);
            await _dbContext.SaveChangesAsync();

            return saveFile;    
        }

        public async Task<Savefile> GetFileById(int id)
        {
            return await _dbContext.Savefiles.FindAsync(id) ?? throw new Exception("File not found");
        }

        public async Task<List<Savefile>> GetAllFiles()
        {
            return await _dbContext.Savefiles.ToListAsync();
        }

        public async Task<bool> DeleteFile(int id)
        {
            var file = await _dbContext.Savefiles.FindAsync(id);
            if (file == null)
                return false;

            _dbContext.Savefiles.Remove(file);
            await _dbContext.SaveChangesAsync();

            // Xóa file từ blob storage nếu cần
            if(file.fileName != null && await _blobService.FileExistsAsync(file.fileName))
            {
                await _blobService.DeleteFileAsync(file.fileName);
            }

            return true;
        }

        public async Task<Savefile> UpdateFile(int id, FileDto fileDto) // Thay đổi từ Savefile? thành Savefile
        {
            var existingFile = await _dbContext.Savefiles.FindAsync(id);
            if (existingFile == null)

                throw new KeyNotFoundException($"Không tìm thấy file với ID {id}.");

            var urlFile = existingFile.urlFile ?? throw new InvalidOperationException("urlFile không thể null");

            if (fileDto.file != null)
            {
                using (var stream = fileDto.file.OpenReadStream())
                {
                    urlFile = await _blobService.UploadFileAsync(fileDto.file.FileName, stream);
                }

                // Xóa file cũ từ blob storage nếu cần
                if(existingFile.fileName != null && await _blobService.FileExistsAsync(existingFile.fileName))
                {
                    await _blobService.DeleteFileAsync(existingFile.fileName);
                }
            }

            existingFile.fileName = fileDto.file?.FileName ?? existingFile.fileName;
            existingFile.urlFile = urlFile;

            await _dbContext.SaveChangesAsync();

            return existingFile;
        }

        public async Task<List<string>> GetAllFilesAsync()
        {
            return await _blobService.GetAllFilesAsync();
        }
    }
}
