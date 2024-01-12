using ConsoleApp.Enums;

namespace ConsoleApp.Models.Responses;

public interface IServiceResult
{
    ServiceStatus Status { get; set; }
    object Result { get; set; }
  
}