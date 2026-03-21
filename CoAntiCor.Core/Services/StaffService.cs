using CoAntiCor.Core.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;


namespace CoAntiCor.Core.Services;

public class StaffService : IStaffService
{
    private readonly IConfiguration _config;

    public StaffService(IConfiguration config)
    {
        _config = config;
    }

    public async Task<string> AssignStaffAsync()
    {

       return "CompletedTask";
    }
}
