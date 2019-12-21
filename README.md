## Installation
copy Kooboo.Extension.dll from dist folder to the executing folder of Kooboo.  
more information: https://www.kooboo.com/documentation/csharp-extensions
## kScript extensions
1. k.ex.code.run(...codeNames : string[]) : void    
### Example 1 (in view): 
``` javascript
k.ex.code.run();
``` 
It runs the code of the same name as the current view's name in "Development/Code"
### Example 2: 
``` javascript
k.ex.code.run("lodash.min.js", "helper")
```
It runs the code "lodash.min.js" in "Development/Scripts" and the code "helper" in "Development/Code"