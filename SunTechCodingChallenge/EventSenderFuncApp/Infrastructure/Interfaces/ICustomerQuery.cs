using EventSenderFuncApp.Shared.Models.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventSenderFuncApp.Infrastructure.Interfaces
{
    public interface ICustomerQuery
    {
        Task<int> GetPartitionKeyCount(string partitionKey);

        Task<List<AnalyticViewModel>> GetCustomerAnalytic();
    }
}
