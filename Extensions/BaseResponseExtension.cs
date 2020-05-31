using Notes.API.Domain.Models;
using Notes.API.Domain.Services.Communication;
using Notes.API.Resources;
using Notes.API.Resources.Communication;

namespace Notes.API.Extensions
{
    public static class BaseResponseExtension
    {
        public static ResponseResult GetResponseResult<T>(this T response, IResource resource) where T: BaseResponse 
        {
            return new ResponseResult
            {
                Data = resource,
                Message = response.Message,
                Success = response.Success
            };
        }
    }
}