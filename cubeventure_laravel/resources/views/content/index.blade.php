<link rel="shortcut icon" href="{{ asset('TemplateData/favicon.ico') }}">
<link rel="stylesheet" href="{{ asset('TemplateData/style.css') }}">
<script src="{{ asset('TemplateData/UnityProgress.js') }}"></script>
<script src="{{ asset('Build/UnityLoader.js') }}"></script>
<script>
    var unityInstance;
    function startGame(){
        document.getElementById("shader").style.display = 'none';
        unityInstance = UnityLoader.instantiate("unityContainer", "Build/Cube_build.json", {onProgress: UnityProgress});
        document.getElementById("fullscreen").style.display = 'block';
    }
</script>
</head>
<body>
<div class="webgl-content">
    <div class="title"><strong> CubeVenture </strong></div>
    <div id="unityContainer"></div>
    <div class="footer_unity">
        <div id="shader" class="shader">
            <button onclick="startGame()">
                <img src="{{ asset('images/playbutton.png') }}">
            </button>
        </div>
        <div class="webgl-logo"></div>
        <div id="fullscreen" class="fullscreen" onclick="unityInstance.SetFullscreen(1)"></div>

    </div>
</div>

