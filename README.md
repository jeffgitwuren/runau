# runau
### Run as user | Written by [CuSO₄·5H₂O](https://cuso4.tech) | Licensed under the [MIT License](LICENSE)

This project uses the Win32 apis to spawn a new process in that session. This allows a process running in a different session (such as a windows service) to start a process with a graphical user interface that the user must see. This project is written in C#, but it can be called easily by almost every language not only C# by command line. Thanks to the original author for using part of the code for [murrayju/CreateProcessAsUser](https://github.com/murrayju/CreateProcessAsUser).

**Note that the process must have the appropriate (admin) privileges for this to work correctly.**

---

## Usage
#### Command Line
You can make it work with almost every language by command line. Just [click here to download builded executable file](bin/Debug/runau.exe), and use it like this:
```
rem Run calc.exe
runau calc.exe

rem Use notepad.exe to open C:\emmm.txt
renau notepad.exe C:\emmm.txt

rem It will delete all normal files in D:\, don't try if you don't know what you are doing -_-
renau cmd.exe "/c del *.* /s /f /q" D:\

rem If you want to hide the window, make sure the fourth parameter is "-h".
runau cmd.exe "/c del *.* /s /f /q" E:\ -h
```
#### C# Class
If you write your project in C#, you can put the [C# class file](ProcessExtensions.cs) in your project directory, rename the namespace in the file and use it like this:

```C#
ProcessExtensions.StartProcessAsCurrentUser("calc.exe"); // Run calc.exe
ProcessExtensions.StartProcessAsCurrentUser("notepad.exe", "C:\emmm.txt"); // Use notepad.exe to open C:\emmm.txt
ProcessExtensions.StartProcessAsCurrentUser("cmd.exe","/c del *.* /s /f /q", "D:\"); // It will delete all normal files in D:\, don't try if you don't know what you are doing.
ProcessExtensions.StartProcessAsCurrentUser("cmd.exe","/c del *.* /s /f /q", "E:\", false); // Delete all normal files in E:\ without any window, you know.
```

_The function accepts 1-4 parameters. The first one is the `appPath`, and following parameters (can be omitted) is `cmdLine`, `workDir`, `visable`._

---
## Parameters
The second argument is used to pass the command line arguments as a string. Depending on the target application, `argv[0]` might be expected to be the executable name, or it might be the first parameter. See [this stack overflow answer](https://stackoverflow.com/a/14001282) for details. When in doubt, try it both ways.
