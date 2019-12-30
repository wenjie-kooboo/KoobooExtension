# Installation
copy Kooboo.Extension.dll from dist folder to the executing folder of Kooboo.  
more information: https://www.kooboo.com/documentation/csharp-extensions

# kScript extensions

## k.ex.code.require(...codeNames : string[]) : void    
Example 1: includes the code of the same name as the current view's name in "Development/Code"
``` javascript
k.ex.code.require();
``` 

Example 2: includes the code "lodash.min.js" in "Development/Scripts" and the code "helper" in "Development/Code"
``` javascript
k.ex.code.require("lodash.min.js", "helper")
```

## k.ex.view.render(name : string, parameters : any = null) : string   
``` javascript
var footerView = k.ex.view.render("Footer", { theme: "red" })
```
Get "theme" in Footer View
``` javascript
var theme = k.dataContext.exView ? k.dataContext.exView.theme : "";
```

## k.ex.searchIndex.search(keywords : string, top : number = Infinity, highLightAttr : string = null) : Array<SearchResult>   
``` javascript
var result = k.ex.searchIndex.search("hello", 20, "style=font-weight:bold;");
```
