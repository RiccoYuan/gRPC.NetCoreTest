using Grpc.Core;
using GrpcService.Protos;
using System.Threading.Tasks;

namespace GrpcService.Services
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
