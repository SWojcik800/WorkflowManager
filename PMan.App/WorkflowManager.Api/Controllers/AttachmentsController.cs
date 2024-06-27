using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WorkflowManager.Api.Dtos;
using WorkflowManager.Api.Helpers;
using WorkflowManager.ApplicationCore.Models;

namespace WorkflowManager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttachmentsController(IConfiguration configuration, IJWTTokenService jwtTokenService, AppManagerApi appManagerApi) : ControllerBase
    {
        [HttpPost]
        public async Task UploadAttachment(UploadAttachmentDto dto)
        {

            var currentUserId = jwtTokenService.GetCurrentUserId();
            if (currentUserId == 0)
                throw new UnauthorizedAccessException();
            var attachmentModel = new Attachment()
            {
                Id = Guid.NewGuid().ToString().Replace("-",""),
                AttachmentOwnerType = dto.AttachmentOwnerType,
                CreationTime = DateTime.Now,
                FileName = dto.FileName,
                OwnerId = dto.OwnerId,
                CreatedById = currentUserId
            };

            var uploadFolderPath = configuration.GetValue<string>("UploadFolderPath");
            var ownerPath = Path.Combine(uploadFolderPath, dto.AttachmentOwnerType.ToString(), dto.OwnerId.ToString());

            if(!Directory.Exists(ownerPath))
                Directory.CreateDirectory(ownerPath);

            var filePath = Path.Combine(ownerPath, attachmentModel.Id);

            System.IO.File.WriteAllBytes(filePath, dto.Attachment);
            attachmentModel.FilePath = filePath;

            appManagerApi.DbContext.Attachments.Add(attachmentModel);

            await appManagerApi.DbContext.SaveChangesAsync();

        }

        [HttpGet]
        public async Task<FileDto> DownloadFile(string id)
        {
            var currentUserId = jwtTokenService.GetCurrentUserId();
            if (currentUserId == 0)
                throw new UnauthorizedAccessException();
            var attachment = await appManagerApi.DbContext.Attachments.FirstOrDefaultAsync(x => x.Id == id);

            var fileContent = System.IO.File.ReadAllBytes(attachment.FilePath);

            return new FileDto()
            {
                Id = attachment.Id,
                File = fileContent,
                FileName = attachment.FileName
            };
        }

        [HttpGet("for-owner")]
        public async Task<List<AttachmentDto>> GetAttachmentsForOwner(int ownerId, AttachmentOwnerType attachmentOwnerType)
        {
            var currentUserId = jwtTokenService.GetCurrentUserId();
            if (currentUserId == 0)
                throw new UnauthorizedAccessException();
            var result = await appManagerApi.DbContext.Attachments.Where(x => x.OwnerId == ownerId && x.AttachmentOwnerType == attachmentOwnerType)
                .Select(x => new AttachmentDto
                {
                    Id = x.Id,
                    CreatedByUserId = x.CreatedBy.Id,
                    CreationTime = x.CreationTime,
                    CreatorLogin = x.CreatedBy.Login,
                    FileName = x.FileName
                })
                .ToListAsync();

            return result;
        }
    }
}
