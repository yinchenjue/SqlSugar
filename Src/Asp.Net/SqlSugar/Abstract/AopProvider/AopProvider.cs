﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SqlSugar
{
    public class AopProvider
    {
        private AopProvider() { }
        public AopProvider(SqlSugarProvider context)
        {
            this.Context = context;
            this.Context.Ado.IsEnableLogEvent = true;
        }
        private SqlSugarProvider Context { get; set; }
        public Action<DiffLogModel> OnDiffLogEvent { set { this.Context.CurrentConnectionConfig.AopEvents.OnDiffLogEvent = value; } }
        public Action<SqlSugarException> OnError { set { this.Context.CurrentConnectionConfig.AopEvents.OnError = value; } }
        public Action<string, SugarParameter[]> OnLogExecuting { set { this.Context.CurrentConnectionConfig.AopEvents.OnLogExecuting= value; } }
        public Action<string, SugarParameter[]> OnLogExecuted { set { this.Context.CurrentConnectionConfig.AopEvents.OnLogExecuted = value; } }
        public Func<string, SugarParameter[], KeyValuePair<string, SugarParameter[]>> OnExecutingChangeSql { set { this.Context.CurrentConnectionConfig.AopEvents.OnExecutingChangeSql = value; } }
        public virtual Action<object, DataFilterModel> DataExecuting { set { this.Context.CurrentConnectionConfig.AopEvents.DataExecuting = value; } }
        public Action<object, DataFilterModel> DataChangesExecuted { set { this.Context.CurrentConnectionConfig.AopEvents.DataChangesExecuted = value; } }
        public virtual Action<object, DataAfterModel> DataExecuted { set { this.Context.CurrentConnectionConfig.AopEvents.DataExecuted = value; } }
        public Action<IDbConnection> CheckConnectionExecuting { set { this.Context.CurrentConnectionConfig.AopEvents.CheckConnectionExecuting = value; } }
        public Action<IDbConnection, TimeSpan> CheckConnectionExecuted { set { this.Context.CurrentConnectionConfig.AopEvents.CheckConnectionExecuted = value; } }
        public Action<string, SugarParameter[]> OnGetDataReadering { set { this.Context.CurrentConnectionConfig.AopEvents.OnGetDataReadering = value; } }
        public Action<string, SugarParameter[], TimeSpan> OnGetDataReadered { set { this.Context.CurrentConnectionConfig.AopEvents.OnGetDataReadered = value; } }
    }
}
