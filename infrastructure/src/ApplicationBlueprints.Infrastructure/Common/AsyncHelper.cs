﻿using System;
using System.Threading;
using System.Threading.Tasks;

namespace ApplicationBlueprints.Infrastructure.Common
{
    public static class AsyncHelper
    {
        private static readonly TaskFactory TaskFactory = new 
            TaskFactory(CancellationToken.None, 
                TaskCreationOptions.None, 
                TaskContinuationOptions.None, 
                TaskScheduler.Default);

        public static TResult RunSync<TResult>(Func<Task<TResult>> func) => TaskFactory
                .StartNew(func, CancellationToken.None, 
                TaskCreationOptions.None, 
                TaskScheduler.Default)
                .Unwrap()
                .GetAwaiter()
                .GetResult();

        public static void RunSync(Func<Task> func) => TaskFactory
                .StartNew(func, 
                CancellationToken.None,
                TaskCreationOptions.None,
                TaskScheduler.Default);
    }
}
