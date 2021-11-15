using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using UserApp.Application.Common.Interfaces;
using UserApp.Application.Common.Models;
using UserApp.Application.Dto;

namespace UserApp.Application.Users.Queries
{
    public class GetAllUsersQuery : IRequestWrapper<IEnumerable<UserDto>>
    {
    }

    public class GetAllUsersQueryHandler : IRequestHandlerWrapper<GetAllUsersQuery, IEnumerable<UserDto>>
    {
        private readonly AppSettings _settings;
        private readonly IFileHandler _fileHandler;
        private readonly string _filePath;

        public GetAllUsersQueryHandler(AppSettings settings, IFileHandler fileHandler)
        {
            _settings = settings;
            _fileHandler = fileHandler;

            _filePath = _settings.Directory;
        }

        public async Task<ServiceResult<IEnumerable<UserDto>>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            try
            {
                IEnumerable<UserDto> users = await _fileHandler.GetContentInJsonAsync<UserDto>(_filePath);

                return ServiceResult.Success(users);
            }
            catch (Exception ex) when (ex is DirectoryNotFoundException || ex is FileNotFoundException)
            {

            }
            catch (Exception ex)
            {

            }

            return ServiceResult.Failed<IEnumerable<UserDto>>(ServiceError.SystemError);
        }
    }
}
