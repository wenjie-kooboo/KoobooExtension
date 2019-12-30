# Installation
copy Kooboo.Extension.dll from dist folder to the executing folder of Kooboo.  
more information: https://www.kooboo.com/documentation/csharp-extensions

# kScript extensions

## k.code.require(...codeNames : string[]) : void    
Example 1: includes the code of the same name as the current view's name in "Development/Code"
``` javascript
k.code.require();
``` 

Example 2: includes the code "lodash.min.js" in "Development/Scripts" and the code "helper" in "Development/Code"
``` javascript
k.code.require("lodash.min.js", "helper")
```

## k.view.render(name : string, parameters : any = null) : string   
``` javascript
var footerView = k.view.render("Footer", { theme: "red" })
```
Get "theme" in Footer View
``` javascript
var theme = k.dataContext.view ? k.dataContext.view.theme : "";
```

## k.searchIndex.search(keywords : string, top : number = Infinity, highLightAttr : string = null) : Array<SearchResult>   
``` javascript
var result = k.searchIndex.search("hello", 20, "style=font-weight:bold;");
```
