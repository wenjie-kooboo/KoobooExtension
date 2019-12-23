## Installation
copy Kooboo.Extension.dll from dist folder to the executing folder of Kooboo.  
more information: https://www.kooboo.com/documentation/csharp-extensions

## kScript extensions

### k.ex.code.require(...codeNames : string[]) : void    
1. Example 1: includes the code of the same name as the current view's name in "Development/Code"
``` javascript
k.ex.code.require();
``` 

2. Example 2: includes the code "lodash.min.js" in "Development/Scripts" and the code "helper" in "Development/Code"
``` javascript
k.ex.code.require("lodash.min.js", "helper")
```