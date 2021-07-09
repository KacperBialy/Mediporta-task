using Mediporta.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Mediporta.Services
{
    public interface IStackOverflowService
    {
        Task<List<Tag>> GetMostPopularTagsAsync(int amount);
    }
}