using System.Threading.Tasks;
using Grpc.Core;
using GrpcService.Protos;

namespace GrpcServiceConsoleApp.Services
{
    public class UserService : User.UserBase
    {
        public override Task<SayHiResponse> SayHi(SayHiRequest request, ServerCallContext context)
        {
            return Task.FromResult(new SayHiResponse
            {
                Message = $"Hi,{request.Name}!"
            });
        }
    }
}
