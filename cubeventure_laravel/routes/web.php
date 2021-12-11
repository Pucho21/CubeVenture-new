<?php

use Illuminate\Support\Facades\Route;
use App\Http\Controllers\MyController;

/*
|--------------------------------------------------------------------------
| Web Routes
|--------------------------------------------------------------------------
|
| Here is where you can register web routes for your application. These
| routes are loaded by the RouteServiceProvider within a group which
| contains the "web" middleware group. Now create something great!
|
Route::get('/', function () {
    return view('welcome');
});
*/

Route::get('/', [MyController::class, 'getData']);

//Route::post('/login', [App\Models\Login::class, 'loginUser']);
Route::post('/login', [MyController::class, 'loginUser']);
Route::post('/buyItem', [MyController::class, 'buyItem']);
Route::post('/updateCoins', [MyController::class, 'updateCoins']);
Route::post('/createNewLevel', [MyController::class, 'createNewLevel']);
Route::post('/getUsers', [MyController::class, 'getUsers']);
Route::post('/updateLevelHighscore', [MyController::class, 'updateLevelHighscore']);
Route::post('/getItemsIDs', [MyController::class, 'getItemsIDs']);
Route::post('/getLeaderboard', [MyController::class, 'getLeaderboard']);
Route::post('/getUserLevelStats', [MyController::class, 'getUserLevelStats']);
Route::post('/register', [MyController::class, 'register']);

/*Route::get('/game', [MyController::class, 'startGame']);
Route::get('/#leaders', [MyController::class, 'getLeaders']);
Route::get('/#howtoplay', [MyController::class, 'getHowToPlay']);
Route::get('/#about', [MyController::class, 'getAbout']);
Route::get('/#contact', [MyController::class, 'getContact']);*/

