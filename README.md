## MOZGUI.Fireup

**MOZGUI.Fireup** is developed to run applications via a web links with a custom protocol.

Windows users often need to exchange and open links (UNC format) to folders or documents in the local network via corporate CMS. 

Now it can be worked in IE 11 only.

**MOZGUI.Fireup** can help you to use any internet browser for opening links in UNC format. 

**1. Install MOZGUI.Fireup**

For security reasons, after installation you can change list of allowed file extensions:
- Find key in Registry **HKEY-CLASSES_ROOT\mozgui-fireup\AllowedExtensions** and add or remove your file extensions

**Note**: Default allowed file extensions: **txt; rtf; doc; docx; xls; xlsx; ppt; pptx; htm; html**.

**2. Inject JavaScript into your CMS pages to enable changing UNC links on-the-fly.**
```markdown
<script>
window.onload=function() {
  var links = document.links;
  for (var i=0, n=links.length;i<n;i++) {
	   var href = links[i].href;
	   if (href) {
		 links[i].href = href.replace(/^(file:(\/)+)/,"mozgui-fireup:");
	   }
  }
}
</script>
```
## How it works

**MOZGUI.Fireup installer** registers custom URL protocol (mozgui-fireup) for launching **MOZGUI.Fireup** with a parameter.
Example of link with custom protocol: 
```<a href="mozgui-fireup:parameter">```, where parameter is a path or URL to folder or file (```<a href="mozgui-fireup:file://SRV/Share/document.docx">```).

After clicking on this link **MOZGUI.Fireup** will start process to open "parameter" url using default program for file extension as part of this url (when url is folder, url will be opened by explorer).

To exclude possibility of starting executable files, list of allowed file extensions is restricted.




