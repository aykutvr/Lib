using Lib.Logger.Dto;
using Lib.Logger.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
namespace Lib.Logger.Repositories
{
    public class LibLoggerRepository : ILibLoggerRepository
    {
        private IServiceProvider _serviceProvider { get; set; }
        private IHttpContextAccessor? _hcx { get; set; }
        public LibLoggerRepository(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            if (serviceProvider != null)
                _hcx = _serviceProvider.GetService<IHttpContextAccessor>();


            System.Linq.Expressions.Expression.Constant(5);

        }

        public void Error(string message, [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerMemberName = "", [CallerLineNumber] int callerLineNumber = -1)
            => Error(message, "", callerFilePath, callerMemberName, callerLineNumber);
        public void Error(string message, string description, [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerMemberName = "", [CallerLineNumber] int callerLineNumber = -1)
            => AddLog(message, description, LogLevel.Error, callerFilePath, callerMemberName, callerLineNumber);

        public void Error(Exception ex, [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerMemberName = "", [CallerLineNumber] int callerLineNumber = -1)
           => AddLog(ex.Message, ex.ToString(), LogLevel.Error, callerFilePath, callerMemberName, callerLineNumber);
        public void Information(string message, [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerMemberName = "", [CallerLineNumber] int callerLineNumber = -1)
            => Information(message, "", callerFilePath, callerMemberName, callerLineNumber);
        public void Information(string message, string description, [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerMemberName = "", [CallerLineNumber] int callerLineNumber = -1)
            => AddLog(message, description, LogLevel.Information, callerFilePath, callerMemberName, callerLineNumber);
        public void Warning(string message, [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerMemberName = "", [CallerLineNumber] int callerLineNumber = -1)
           => Warning(message, "", callerFilePath, callerMemberName, callerLineNumber);
        public void Warning(string message, string description, [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerMemberName = "", [CallerLineNumber] int callerLineNumber = -1)
            => AddLog(message, description, LogLevel.Warning, callerFilePath, callerMemberName, callerLineNumber);
        public void Debug(string message, [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerMemberName = "", [CallerLineNumber] int callerLineNumber = -1)
           => Debug(message, "", callerFilePath, callerMemberName, callerLineNumber);
        public void Debug(string message, string description, [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerMemberName = "", [CallerLineNumber] int callerLineNumber = -1)
            => AddLog(message, description, LogLevel.Debug, callerFilePath, callerMemberName, callerLineNumber);
        public void AddLog(string message, string description, LogLevel logLevel, [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerMemberName = "", [CallerLineNumber] int callerLineNumber = -1)
            => AddLog(new LoggingParameters
            {
                Details = description,
                LogTime = DateTime.Now,
                LogLevel = logLevel,
                Message = message,
                SpecialFolderName = "",
                SpecialLogFileName = "",
                UseDateIndicatorInLogFileName = false
            }, callerFilePath, callerMemberName, callerLineNumber);
        private static Object thisLock = new Object();
        public void AddLog(LoggingParameters parameters, [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerMemberName = "", [CallerLineNumber] int callerLineNumber = -1)
        {
            string? requestPath = String.Empty;
            string? userName = String.Empty;
            string? requestMethod = String.Empty;
            string? remoteIpAddress = String.Empty;
            string? hostName = String.Empty;
            string? queryString = String.Empty;

            if (_hcx != null && _hcx.HttpContext != null)
            {
                requestPath = _hcx.HttpContext.Request.Path.ToString().IfNull("");
                userName = _hcx.HttpContext.User.Identity?.Name?.IfNull("").ToString();
                requestMethod = _hcx.HttpContext.Request.Method;
                try
                {
                    remoteIpAddress = _hcx.HttpContext.Connection.RemoteIpAddress.ToString();
                    hostName = !remoteIpAddress.IsNullOrEmpty() ? Dns.GetHostEntry(_hcx.HttpContext.Connection.RemoteIpAddress).HostName : "";
                }
                catch (Exception)
                {
                }

                queryString = _hcx.HttpContext.Request.QueryString.ToString();
            }

            if (SharedSettings.LogType == LoggingType.None && parameters.LogType != LoggingType.File)
            {

            }
            else if (SharedSettings.LogType == LoggingType.File || parameters.LogType == LoggingType.File)
            {
                string logFolder = SharedSettings.FolderPath.IsNullOrEmpty() ? System.IO.Path.Combine(SharedSettings.RootPath, "Log") : SharedSettings.FolderPath;

                if (!string.IsNullOrEmpty(parameters.SpecialFolderName))
                    logFolder = System.IO.Path.Combine(logFolder, parameters.SpecialFolderName);

                string logFileName = $@"{(string.IsNullOrEmpty(parameters.SpecialLogFileName) ? "" : $"{parameters.SpecialLogFileName}_")}{(parameters.UseDateIndicatorInLogFileName ? DateTime.Now.ToString("yyyy_MM_dd") + "_" : "")}_log.txt";

                if (!System.IO.Directory.Exists(logFolder))
                    System.IO.Directory.CreateDirectory(logFolder);

                string logPath = System.IO.Path.Combine(logFolder, logFileName);

                StringBuilder sBuilder = new StringBuilder();
                sBuilder.Append($"Log Date : {DateTime.Now}{Environment.NewLine}");
                sBuilder.Append($"Log Type : {parameters.LogLevel.ToString()}{Environment.NewLine}");
                sBuilder.Append($"File Path : {callerFilePath}{Environment.NewLine}");
                sBuilder.Append($"Method : {callerMemberName}{Environment.NewLine}");
                sBuilder.Append($"Line Number : {callerLineNumber}{Environment.NewLine}");
                sBuilder.Append($"Request Path : {requestPath}{Environment.NewLine}");
                sBuilder.Append($"Request Method : {requestMethod}{Environment.NewLine}");
                sBuilder.Append($"Query String : {requestMethod}{Environment.NewLine}");
                sBuilder.Append($"User Name : {userName}{Environment.NewLine}");
                sBuilder.Append($"Remote Ip Address : {remoteIpAddress}{Environment.NewLine}");
                sBuilder.Append($"Host Name : {hostName}{Environment.NewLine}");
                sBuilder.Append($"Log Message : {parameters.Message}{Environment.NewLine}");
                sBuilder.Append($"Log Details : {parameters.Details}{Environment.NewLine}");
                sBuilder.Append($"-----------------------------------------------------------{Environment.NewLine}");

                lock (thisLock)
                {
                    System.IO.File.AppendAllText(logPath, sBuilder.ToString());
                }

            }
            else if (SharedSettings.LogType == LoggingType.Database)
            {
                var dapper = new Lib.DapperORM.Repositories.DapperConnectRepository();
                if (dapper == null)
                    return;

                dapper.Connect(SharedSettings.ConnectionString, callerFilePath, callerMemberName, callerLineNumber)
                      .Insert(insert =>
                      {
                          insert.AddData<LogDto>(new LogDto
                          {
                              Date = DateTime.Now,
                              Description = parameters.Details.Left(4000),
                              LogType = parameters.LogLevel.ToString(),
                              Message = parameters.Message.Left(4000),
                              UserId = 0,
                              CallerFilePath = callerFilePath.Left(500),
                              CallerLineNumber = callerLineNumber,
                              CallerMemberName = callerMemberName.Left(100),
                              ClientHostName = hostName.Left(100),
                              RemoteIpAddress = remoteIpAddress.Left(100),
                              RequestMethod = requestMethod.Left(100),
                              RequestPath = requestPath.Left(100),
                              UserName = userName.IfNull("").Left(100),
                              QueryString = queryString.Left(500),
                          });
                      });
            }
        }
    }
}
