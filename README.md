## MOZGUI.Fireup

MOZGUI.Fireup is developed to run applications via a web links with a custom protocol.

Windows users often need to exchange and open links (UNC format) to folders or documents on the local network (UNC) via corporate CMS. Now it can be worked in IE 11 only.

MOZGUI.Fireup can help you use any browser for open links in UNC format. 

First step:

### 1. Install MOZGUI.Fireup

For security aims: after installation you can change list of allowed file extensions:
- Find Key in Registry **HKEY-CLASSES_ROOT\mozgui-fireup\AllowedExtensions** and add or remove your extensions

### 2. Inject javascript in CMS pages for change links on-the-fly.
```<script>
window.onload=function() {
  var links = document.links; // or document.getElementsByTagName("a");
  for (var i=0, n=links.length;i<n;i++) {
	   var href = links[i].href;
	   if (href) {
		 links[i].href = href.replace(/^(file:(\/)+)/,"mozgui-fireup:");
	   }
  }
}
</script>
```
### Markdown

Markdown is a lightweight and easy-to-use syntax for styling your writing. It includes conventions for

```markdown
Syntax highlighted code block

# Header 1
## Header 2
### Header 3

- Bulleted
- List

1. Numbered
2. List

**Bold** and _Italic_ and `Code` text

[Link](url) and ![Image](src)
```

For more details see [GitHub Flavored Markdown](https://guides.github.com/features/mastering-markdown/).

### Jekyll Themes

Your Pages site will use the layout and styles from the Jekyll theme you have selected in your [repository settings](https://github.com/MOZGUI/MOZGUI.Fireup/settings). The name of this theme is saved in the Jekyll `_config.yml` configuration file.

### Support or Contact

Having trouble with Pages? Check out our [documentation](https://docs.github.com/categories/github-pages-basics/) or [contact support](https://github.com/contact) and we’ll help you sort it out.
