```html
<a href="javascript:alert(1)">click me</a>
```

```html

<div onclick="alert(1)">abc</div>
<img src="" onerror="alert(1)"/>
```

```html

<meta http-equiv="content-security-policy"
      content="img-src 'self'; style-src css/style.css; script-src js/index.js; default-src self;"
```

* img-src
* style-src
* script-src
* default-src