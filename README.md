# README

## 可执行程序

```shell
C:\Users\admin\source\repos\ConsoleApp1\ConsoleApp1\bin\Debug\net6.0

Mode                LastWriteTime         Length Name
----                -------------         ------ ----
-a----        2023/10/3     20:06            425 ConsoleApp1.deps.json
-a----        2023/10/3     22:14           4608 ConsoleApp1.dll                                                                                                
-a----        2023/10/3     22:14         149504 ConsoleApp1.exe
-a----        2023/10/3     22:14          10276 ConsoleApp1.pdb
-a----        2023/10/3     20:06            147 ConsoleApp1.runtimeconfig.json

```

写单元测试
MSTest
NUnit
xUnit

vs上可以运行单元测试代码
Rider目前运行不了

Rider ide添加库
ConsoleApp1.csproj

```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>net6.0</TargetFramework>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include="MSTest" Version="2.2.10" />
    <PackageReference Include="NUnit" Version="3.13.3" />
    <PackageReference Include="xunit" Version="2.4.2" />
  </ItemGroup>

</Project>
```

  <ItemGroup>
    <PackageReference Include="MSTest" Version="2.2.10" />
    <PackageReference Include="NUnit" Version="3.13.3" />
    <PackageReference Include="xunit" Version="2.4.2" />
  </ItemGroup>


C:\Users\admin\.nuget\packages
下载好的c#库
C:\Users\admin\.nuget\packages\nunit\3.13.3\lib\net40

nunit.framework.dll

## 如何打包，部署到windows server上？
