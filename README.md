# Installation
copy Kooboo.Extension.dll from dist folder to the executing folder of Kooboo.  
more information: https://www.kooboo.com/documentation/csharp-extensions

# Exception
> System.TypeInitializationException: “Kooboo.Lib.Reflection.AssemblyLoader”的类型初始值设定项引发异常。 ---> System.NotSupportedException: 尝试从一个网络位置加载程序集，在早期版本的 .NET Framework 中，这会导致对该程序集进行沙盒处理。此发行版的 .NET Framework 默认情况下不启用 CAS 策略，因此，此加载可能会很危险。如果此加载不是要对程序集进行沙盒处理，请启用 loadFromRemoteSources 开关。

> An attempt was made to load an assembly from a network location which would have caused the assembly to be sandboxed in previous versions of the .NET Framework. This release of the .NET Framework does not enable CAS policy by default, so this load may be dangerous. If this load is not intended to sandbox the assembly, please enable the loadFromRemoteSources switch.

if you had exception of above, you can edit "Kooboo.exe.Config" to enable loadFromRemoteSources like this:
``` xml
<configuration>
   <runtime>
      <loadFromRemoteSources enabled="true"/>
   </runtime>
</configuration>
```
See http://go.microsoft.com/fwlink/?LinkId=155569 for more information.  

# kScript extensions

## k.code.require(...codeNames : string[]) : void    
Example 1: includes the code of the same name as the current view's name in "Development/Code"
``` javascript
k.code.require();
``` 

Example 2: includes the code "underscore-min.js" in "Development/Scripts" and the code "helper" in "Development/Code"
``` javascript
k.code.require("underscore-min.js", "helper")
```

## k.view.render(name : string, parameters : any = null) : string   
``` javascript
var footerView = k.view.render("Footer", { theme: "red" })
```
Get "theme" in Footer View
``` javascript
var theme = k.dataContext.view ? k.dataContext.view.theme : "";
```

## k.searchIndex.search(keywords : string, top : number = Infinity, highLightAttr : string = null) : Array&lt;SearchResult&gt;   
``` javascript
var result = k.searchIndex.search("hello", 20, "style=font-weight:bold;");
```
## k.searchIndex.searchWithPaging(keywords : string, pagesize : number, pagenumber : number, highLightAttr : string = null) : PagedResult
``` javascript
var result = k.searchIndex.searchWithPaging("hello", 20, 1, "style=font-weight:bold;");
```

## k.searchIndex.searchByFolders(folderIds : string[], keywords : string, pagesize : number, pagenumber : number, highLightAttr : string = null) : PagedResult  
``` javascript
var result = k.searchIndex.searchByFolders(["bcd3df0f-e295-e731-f9e8-95929f333352"], "hello", 20, 1, "style=font-weight:bold;");
```
