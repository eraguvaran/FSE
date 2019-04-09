C:\Projects\Capsule\TaskManager\TaskManagerService\packages\OpenCover.4.6.519\tools\OpenCover.Console.exe -target:C:\Projects\Capsule\TaskManager\TaskManagerService\Task.NUnitTest\runtests.bat -register:user -filter:"+[TaskManagerService],+[Task.BusinessLayer]*" 
C:\Projects\Capsule\TaskManager\TaskManagerService\packages\ReportGenerator.3.1.2\tools\ReportGenerator.exe -reports:C:\Projects\Capsule\TaskManager\TaskManagerService\Task.NUnitTest\results.xml -targetdir:coverage

pause /exit