@extends('layouts.app')

@section('content_main')
    <div class="col-md-8 no gutters">
        <div class="middle">

            <div class="home">
                <section id="home">

                    <div class="nav_border"></div>
                    @include('content.home')

                </section>
            </div>

           <div class="game">
                <section id="game">

                    <div class="nav_border"></div>
                    @include('content.index')

                </section>
            </div>

            <div class="leaders">
                <section id="leaders">

                    <div class="nav_border"></div>
                    @include('content.leaders')

                </section>
            </div>
            <div class="howtoplay">
                <section id="howtoplay">

                    <div class="nav_border"></div>
                    @include('content.howtoplay')

                </section>
            </div>
            <div class="contact">
                <section id="contact">

                    <div class="nav_border"></div>
                    @include('content.contact')

                </section>
            </div>
            <div class="about">
                <section id="about">

                    <div class="nav_border"></div>
                    @include('content.about')

                </section>
            </div>

        </div>
        <input id="myBtn" type="image" src="{{ asset('images/top_arrow.png') }}" onclick="topFunction()"/>
    </div>

    <script>
        //Get the button
        var mybutton = document.getElementById("myBtn");
        var bool = false;

        // When the user scrolls down 60px from the top of the document, show the button
        window.onscroll = function() {scrollFunction()};

        function scrollFunction() {
            if (document.querySelector('.smoothscroll').scrollTop > 60) {
                mybutton.style.display = "block";
            } else {
                mybutton.style.display = "none";
            }
        }
        /*
        function menuFunction(){

            if (document.querySelector('.smoothscroll').scrollTop > 60) {
                bool=true;
                /*document.getElementById('side_nav').style.top = "30%";
                document.getElementById('side_nav').style.display = "block"*//*
                document.getElementById('side_nav').style.animation = 'sidebar_show 1s ease forwards';
            }
            if(bool && document.querySelector('.smoothscroll').scrollTop < 60) {
                /*document.getElementById('side_nav').style.display = "none"*//*

                document.getElementById('side_nav').style.animation = 'sidebar_hide 0.5s ease forwards';

            }
        }*/

        // When the user clicks on the button, scroll to the top of the document
        function topFunction() {
            document.querySelector('.smoothscroll').scrollTop = 0;
        }
    </script>
@endsection

{{--
@section('sidebar')
    @parent

@endsection
 --}}
