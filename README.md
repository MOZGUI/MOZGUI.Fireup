## MOZGUI.Fireup

**MOZGUI.Fireup** is developed to run applications via a web links with a custom protocol.

Windows users often need to exchange and open links (UNC format) to folders or documents on the local network (UNC) via corporate CMS. Now it can be worked in IE 11 only.

**MOZGUI.Fireup** can help you use any browser for open links in UNC format. 

**1. Install MOZGUI.Fireup**

For security aims: after installation you can change list of allowed file extensions:
- Find Key in Registry **HKEY-CLASSES_ROOT\mozgui-fireup\AllowedExtensions** and add or remove your extensions

**2. Inject javascript in your CMS pages for change UNC links on-the-fly.**
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
