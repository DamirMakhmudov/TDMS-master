﻿using Microsoft.Extensions.Logging;
using Tdms.Api;
using Tdms.ImportExport.Commands;
using Tdms.Log;
using System;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Threading;
using Tdms;
using System.Runtime.InteropServices;

namespace iCommands
{
    [TdmsApiCommand("C_API", Roles = "all")]
    public class ICommands1
    {
        public TDMSApplication ThisApplication;
        Tdms.Log.ILogger<ExportClassifiersCommand> Logger { get; set; }
        public TDMSObject thisobject;

        public ICommands1(TDMSApplication application, TDMSObject Thisobject, Tdms.Log.ILogger<ExportClassifiersCommand> logger)
        {
            ThisApplication = application;
            Logger = logger;
            thisobject = Thisobject;
        }

        public string ServerSideFunc(string text)
        {
            Logger.Info("start ServerSideFunc");
            Logger.Info(text);
            //some script

            Logger.Info("end ServerSideFunc");
            return "ok";
        }