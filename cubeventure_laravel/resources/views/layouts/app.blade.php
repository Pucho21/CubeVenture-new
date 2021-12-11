<!DOCTYPE html>
<html>
    <head>
        <meta charset="utf-8">
        <title>CubeVenture</title>
        <!-- add icon link -->
        <link rel = "icon" href="{{ asset('images/cubeventure_logo_small.png') }}" type = "image/x-icon">
        <link rel="stylesheet" href="{{ asset('/css/app.css') }}">
        <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.6.0/dist/css/bootstrap.min.css" integrity="sha384-B0vP5xmATw1+K9KRQjQERJvTumQW0nPEzvF6L/Z6nronJ3oUOFUFpCjEUQouq2+l" crossorigin="anonymous">

        <script
            src="https://maps.googleapis.com/maps/api/js?key=AIzaSyB41DRUbKWJHPxaFjMAwdrzWzbVKartNGg&callback=initMap&v=weekly&channel=2"
            async
        ></script>

    </head>
    <body>

    <div class="smoothscroll" onscroll="scrollFunction()">

    <!-- Header code -->
        @include('inc.navbar')

            <div class="row no-gutters">
                <!-- Left sidebar code -->
                @include('inc.sidebar_left')

                <!-- Main content code -->
                @yield('content_main')

                <!-- Right sidebar code -->
                @include('inc.sidebar_right')
            </div>

    <!-- Footer code -->
    @include('inc.footer')
    </div>

    </body>
</html>
