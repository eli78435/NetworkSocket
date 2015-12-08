﻿using NetworkSocket.Core;
using NetworkSocket.Fast;
using FastServer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FastServer.Filters
{
    /// <summary>
    /// 日志过滤器
    /// </summary>
    public class LogFilterAttribute : FastFilterAttribute
    {
        public ILog Loger { get; set; }

        private string message;

        public LogFilterAttribute(string message)
        {
            this.message = message;
        }

        protected override void OnExecuting(ActionContext filterContext)
        {
            var log = string.Format("Time:{0} Client:{1} Action:{2} Message:{3}", DateTime.Now.ToString("mm:ss"), filterContext.Session, filterContext.Action, this.message);
            this.Loger.Write(log);
        }
    }
}
