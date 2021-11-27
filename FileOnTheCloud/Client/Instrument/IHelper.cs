using System.Collections.Generic;
using System.Threading.Tasks;

namespace FileOnTheCloud.Client.Instrument
{
    public interface IHelper
    {
        Task<List<T>> GetListTsAsync<T>(string path);

        Task<T> GetTsAsync<T>(string path);

        Task<System.Net.HttpStatusCode> DeleteTsAsync<T>(string path);

        Task<System.Net.HttpStatusCode> PostTsAsync<T>(T body, string path, string errormessage, string successmessage);
    }
}