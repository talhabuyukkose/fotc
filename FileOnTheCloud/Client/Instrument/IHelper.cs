﻿using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace FileOnTheCloud.Client.Instrument
{
    public interface IHelper
    {
        Task<List<T>> GetListTsAsync<T>(string path, string errormessage);

        Task<T> GetTsAsync<T>(string path, string errormessage);

        Task<string> GetAsStringAsync(string path, string errormessage);

        Task<System.Net.HttpStatusCode> DeleteTsAsync<T>(string path);
        
        Task<string> PostReturnValueTsAsync<T>(string path, T body, string errormessage, string successmessage);

        Task<System.Net.HttpStatusCode> PostTsAsync<T>(string path, T body, string errormessage, string successmessage);

        Task<System.Net.HttpStatusCode> PostFileTsAsync(string path, HttpContent content, string errormessage, string successmessage);


    }
}