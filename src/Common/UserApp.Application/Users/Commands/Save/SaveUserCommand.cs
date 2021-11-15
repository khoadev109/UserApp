using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UserApp.Application.Common.Interfaces;
using UserApp.Application.Common.Models;
using UserApp.Application.Dto;

namespace UserApp.Application.Users.Commands.Save
{
    public class SaveUserCommand : IRequestWrapper<IEnumerable<UserDto>>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class SaveUserCommandHandler : IRequestHandlerWrapper<SaveUserCommand, IEnumerable<UserDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly AppSettings _settings;
        private readonly IFileHandler _fileHandler;
        private readonly string _fileDirectory;

        public SaveUserCommandHandler(IApplicationDbContext context, AppSettings settings, IFileHandler fileHandler)
        {
            _context = context;
            _settings = settings;
            _fileHandler = fileHandler;

            _fileDirectory = _settings.Directory;
        }

        public async Task<ServiceResult<IEnumerable<UserDto>>> Handle(SaveUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                IEnumerable<UserDto> users = await _fileHandler.SaveFileAsync(
                    _fileDirectory,
                    new UserDto
                    {
                        Id = Guid.NewGuid(),
                        FirstName = request.FirstName,
                        LastName = request.LastName
                    });

                return ServiceResult.Success(users);
            }
            catch (Exception ex)
            {
                return ServiceResult.Failed<IEnumerable<UserDto>>(ServiceError.SystemError);
            }
        }
    }
}
