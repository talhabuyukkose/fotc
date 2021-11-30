﻿using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentFTP;
using System;
using System.Text;
using System.Threading;

namespace FileOnTheCloud.Server.Helper
{
    public class FileTp
    {
        private IConfiguration _config;

        private CancellationToken token;
        public FileTp(IConfiguration config)
        {
            _config = config;

            token = new CancellationToken();
        }
        #region DOWNLOAD FILE

        public async Task<bool> DownloadFile(string localpath, string remotepath, string fileName, string content)
        {
            remotepath = remotepath.StartsWith("/") ? remotepath : "/" + remotepath;

            remotepath = remotepath + "/" + fileName;

            localpath = localpath + "\\" + fileName;

            using (var con = new FtpClient(_config["FTP:Host"], Convert.ToInt32(_config["FTP:Port"]), _config["FTP:User"], _config["FTP:Pass"]))
            {
                await con.ConnectAsync(token);

                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

                con.Encoding = System.Text.Encoding.GetEncoding(1254);

                await con.SetWorkingDirectoryAsync(remotepath);

                FtpStatus ftpStatus = con.DownloadFile(localpath + "\\" + fileName, remotepath + "/" + fileName);

                return ftpStatus == FtpStatus.Success;
            }
        }

        #endregion

        #region UPLOAD FILE

        public async Task<bool> UploadFile(string localpath, string remotepath, string fileName)
        {

            remotepath = remotepath.StartsWith("/") ? remotepath : "/" + remotepath;

            remotepath = remotepath + "/" + fileName;

            localpath = localpath + "\\" + fileName;

            using (var con = new FtpClient(_config["FTP:Host"], Convert.ToInt32(_config["FTP:Port"]), _config["FTP:User"], _config["FTP:Pass"]))
            {
                await con.ConnectAsync(token);

                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

                con.Encoding = System.Text.Encoding.GetEncoding(1254);

                FtpStatus ftpStatus = await con.UploadFileAsync(localpath, remotepath, FtpRemoteExists.Overwrite, true, FtpVerify.Retry);

                return ftpStatus == FtpStatus.Success;
            }
        }
        #endregion

        #region CREATE DIR

        public async Task<bool> CreateDir(string path, string dirname)
        {
            if (string.IsNullOrEmpty(path) == false)
                path = path.StartsWith("/") ? path : "/" + path;

            dirname = dirname.StartsWith("/") ? dirname : "/" + dirname;

            using (var con = new FtpClient(_config["FTP:Host"], Convert.ToInt32(_config["FTP:Port"]), _config["FTP:User"], _config["FTP:Pass"]))
            {
                await con.ConnectAsync(token);

                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

                con.Encoding = System.Text.Encoding.GetEncoding(1254);

                await con.SetWorkingDirectoryAsync(path, token);

                var response = await con.CreateDirectoryAsync(path + dirname, true, token);

                return response;
            }

        }

        #endregion

        #region DELETE DIR,FILE

        public async Task DeleteDir(string path)
        {

            path = path.StartsWith("/") ? path : "/" + path;

            using (var con = new FtpClient(_config["FTP:Host"], Convert.ToInt32(_config["FTP:Port"]), _config["FTP:User"], _config["FTP:Pass"]))
            {
                await con.ConnectAsync(token);

                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

                con.Encoding = System.Text.Encoding.GetEncoding(1254);

                await con.SetWorkingDirectoryAsync(path, token);

                await con.DeleteDirectoryAsync(path, token);
            }

        }

        public async Task DeleteFile(string path, string filename)
        {

            path = path.StartsWith("/") ? path : "/" + path;

            filename = filename.StartsWith("/") ? filename : "/" + filename;

            using (var con = new FtpClient(_config["FTP:Host"], Convert.ToInt32(_config["FTP:Port"]), _config["FTP:User"], _config["FTP:Pass"]))
            {
                await con.ConnectAsync(token);

                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

                con.Encoding = System.Text.Encoding.GetEncoding(1254);

                await con.SetWorkingDirectoryAsync(path, token);

                await con.DeleteFileAsync(path + filename, token);
            }

        }

        #endregion 

        #region GET FILE,DIR,SIZE

        public async Task<List<string>> GetDirListing(string path)
        {
            List<string> list = new List<string>();

            path = path.StartsWith("/") ? path : "/" + path;

            using (var con = new FtpClient(_config["FTP:Host"], Convert.ToInt32(_config["FTP:Port"]), _config["FTP:User"], _config["FTP:Pass"]))
            {
                await con.ConnectAsync(token);

                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

                con.Encoding = System.Text.Encoding.GetEncoding(1254);

                await con.SetWorkingDirectoryAsync(path, token);

                //string workingdirectory = con.GetWorkingDirectory();

                foreach (var item in await con.GetListingAsync(token))
                {
                    if (item.Type == FluentFTP.FtpFileSystemObjectType.Directory)
                    {
                        list.Add(item.FullName);
                    }
                }
            }

            return list;
        }

        public async Task<List<string>> GetFileListing(string path)
        {
            List<string> list = new List<string>();

            path = path.StartsWith("/") ? path : "/" + path;

            using (var con = new FtpClient(_config["FTP:Host"], Convert.ToInt32(_config["FTP:Port"]), _config["FTP:User"], _config["FTP:Pass"]))
            {
                await con.ConnectAsync(token);

                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

                con.Encoding = System.Text.Encoding.GetEncoding(1254);

                await con.SetWorkingDirectoryAsync(path, token);

                foreach (var item in await con.GetListingAsync(token))
                {
                    if (item.Type == FluentFTP.FtpFileSystemObjectType.File)
                    {
                        list.Add(item.FullName);
                    }
                }
            }

            return list;
        }

        public async Task<double> GetFileSize(string path, string filename)
        {
            List<string> list = new List<string>();

            path = path.StartsWith("/") ? path : "/" + path;

            filename = filename.StartsWith("/") ? filename : "/" + filename;

            using (var con = new FtpClient(_config["FTP:Host"], Convert.ToInt32(_config["FTP:Port"]), _config["FTP:User"], _config["FTP:Pass"]))
            {
                await con.ConnectAsync(token);

                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

                con.Encoding = System.Text.Encoding.GetEncoding(1254);

                await con.SetWorkingDirectoryAsync(path);

                var fileSize = await con.GetFileSizeAsync(path + filename, 0, token);

                var Size_MB = Math.Round(fileSize / (double)1048576, 3, MidpointRounding.AwayFromZero); // MB biriminde gösterim için hesaplanır

                return Size_MB;
            }
        }

        #endregion
    }
}