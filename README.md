EF Core NullReference Exceptions
========================================

This sample was forked from https://github.com/bricelam/Sample-SplitMigrations

Added a MyApp.Data.Tests project (xUnit)

Exceptions Produced
----------
-System.NullReferenceException: 'Object reference not set to an instance of an object.'
or
-System.InvalidOperationException: 'BeginExecuteReader requires an open and available Connection. The connection's current state is closed.'

Important Note
----------
System.NullReferenceException: will only be throw if it is the first test run.  There's some comments in the code.

System.NullReferenceException: 'Object reference not set to an instance of an object.' Stack Trace
----------------
```
   at Microsoft.EntityFrameworkCore.Query.RelationalQueryContext.<RegisterValueBufferCursorAsync>d__14.MoveNext()
--- End of stack trace from previous location where exception was thrown ---
   at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()
   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
   at Microsoft.EntityFrameworkCore.Query.Internal.AsyncQueryingEnumerable.AsyncEnumerator.<BufferlessMoveNext>d__9.MoveNext()
--- End of stack trace from previous location where exception was thrown ---
   at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()
   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
   at Microsoft.EntityFrameworkCore.Storage.Internal.SqlServerExecutionStrategy.<ExecuteAsync>d__6`2.MoveNext()
--- End of stack trace from previous location where exception was thrown ---
   at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()
   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
   at Microsoft.EntityFrameworkCore.Query.Internal.AsyncQueryingEnumerable.AsyncEnumerator.<MoveNext>d__8.MoveNext()
--- End of stack trace from previous location where exception was thrown ---
   at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()
   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
   at Microsoft.EntityFrameworkCore.Query.Internal.AsyncLinqOperatorProvider.SelectAsyncEnumerable`2.SelectAsyncEnumerator.<MoveNext>d__4.MoveNext()
--- End of stack trace from previous location where exception was thrown ---
   at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()
   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
   at Microsoft.EntityFrameworkCore.Query.Internal.AsyncLinqOperatorProvider.SelectAsyncEnumerable`2.SelectAsyncEnumerator.<MoveNext>d__4.MoveNext()
--- End of stack trace from previous location where exception was thrown ---
   at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()
   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
   at Microsoft.EntityFrameworkCore.Query.Internal.AsyncLinqOperatorProvider.ExceptionInterceptor`1.EnumeratorExceptionInterceptor.<MoveNext>d__5.MoveNext()
--- End of stack trace from previous location where exception was thrown ---
   at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()
   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
   at Microsoft.EntityFrameworkCore.EntityFrameworkQueryableExtensions.<ToListAsync>d__129`1.MoveNext()
--- End of stack trace from previous location where exception was thrown ---
   at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()
   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
   at System.Runtime.CompilerServices.TaskAwaiter.GetResult()
   at MyApp.Data.Tests.IntegrationTest1.<>c__DisplayClass0_0.<<MyDbContext_MultipleAsyncs_GeneratesException>b__0>d.MoveNext() in C:\Users\mdepouw\Documents\GitHub\EfCoreException\MyApp.Data.Tests\IntegrationTest1.cs:line 32
```

Workaround that doesn't produced the System.NullReferenceException:
----------------
If you perform a single await first then running multiples with Task.WhenAll does not produce an exception