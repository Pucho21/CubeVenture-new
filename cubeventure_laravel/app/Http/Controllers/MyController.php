<?php

namespace App\Http\Controllers;

use App\Models\Leader;
use Illuminate\Http\Request;
use Illuminate\Routing\Controller;
use Illuminate\Support\Facades\DB;

class MyController extends Controller{

    public function getData(){

        //Toto mi posle celu tabulku Leader z DB
        $leaders = DB::table('user')
            ->join('users_levels', 'users_levels.user_id', '=', 'user.id')
            ->select('user.username AS username', 'user.coins AS coins',
                DB::raw('MAX(users_levels.level_id) AS level'),
                DB::raw('SUM(users_levels.score) AS score'))
            ->groupBy('users_levels.user_id')
            ->orderByDesc('score')
            ->get();

        return view('main', ['leaders' => $leaders]);
    }

    public function loginUser(Request $request){
        //$token = csrf_token();

        $userLogin = $request->input('loginUser');
        $userPassword = $request->input('loginPassword');


        //$existingUser = Login::where('username','=',$userLogin)->first();
        $existingUser = DB::table('user')->where('username', $userLogin)->where('password', md5($userPassword))->first();
        if($existingUser){
            echo $existingUser->id;
        } else {
            echo "0";
        }
    }

    public function buyItem(Request $request){
        $userID = $request->input('userID');
        $itemID = $request->input('itemID');

        DB::table('users_items')->insert([
            'user_id' => $userID,
            'item_id' => $itemID
        ]);
    }

    public function updateCoins(Request $request){
        $userID = $request->input('userID');
        $updatedCoins = $request->input('updatedCoins');

        DB::table('user')->where('id', $userID)->update(['coins' => $updatedCoins]);
    }

    public function createNewLevel(Request $request){
        $userID = $request->input('userID');
        $levelID = $request->input('levelID');

        DB::table('users_levels')->insert([
            'user_id' => $userID,
            'level_id' => $levelID,
            'stars' => 0,
            'score' => 0
        ]);
    }

    public function getItem(Request $request){
        $itemID = $request->input('itemID');
    }

    public function getItemsIDs(Request $request){
        $array = [];
        $userID = $request->input('userID');

        $row = DB::table('users_items')->select('item_id')->where('user_id', $userID)->get();
        foreach ($row as $data){
            array_push($array, $data->item_id);
        }
        echo json_encode($array);
    }

    public function getLeaderboard(){

        $result = DB::table('user')
            ->join('users_levels', 'users_levels.user_id', '=', 'user.id')
            ->select('user.username AS username',
                DB::raw('MAX(users_levels.level_id) AS level'),
                DB::raw('SUM(users_levels.score) AS score'))
            ->groupBy('users_levels.user_id')
            ->orderByDesc('score')
            ->get();

        foreach ($result as $row){
            echo $row->username;
            echo "\n";
            echo $row->level;
            echo "\n";
            echo $row->score;
            echo "\n";
        }
    }

    public function getUserLevelStats(Request $request){
        $array = [];
        $userID =$request->input('userID');

        $result = DB::table('users_levels')
            ->select('level_id', 'stars', 'score')
            ->where('user_id', $userID)
            ->get();

        foreach ($result as $row){
            array_push($array, $row->level_id.'');
            array_push($array, $row->stars.'');
            array_push($array, $row->score.'');
        }
        echo json_encode($array);
    }

    public function getUsers(Request $request){
        $userID = $request->input('userID');


        $row = DB::table('user')->select('coins')->where('id', $userID)->get();
        foreach ($row as $data){
            echo $data->coins;
        }
    }

    public function register(Request $request){
        $loginUser = $request->input('loginUser');
        $loginPassword = $request->input('loginPassword');
        $loginEmail = $request->input('loginEmail');
        $userID = null;

        //check valdity email
        if (!filter_var($loginEmail, FILTER_VALIDATE_EMAIL)) {
            exit('-2'); //email is not valid
        }
        //check validity znakov v mene
        if (preg_match('/^[a-zA-Z0-9]+$/', $loginUser) == 0) {
            exit('-1'); //Username is not valid!
        }
        //check validity dlzky hesla
        if (strlen($loginPassword) > 20 || strlen($loginPassword) < 5) {
            exit('0'); //Password must be between 5 and 20 characters long!
        }

        $result = DB::table('user')
            ->select('username')
            ->where('username', $loginUser)
            ->get();

        if(sizeof($result) != 0){
            echo "Username is already taken";
        } else {
            //Create new user
            DB::table('user')
                ->insert([
                    'username' => $loginUser,
                    'password' => md5($loginPassword),
                    'email' => $loginEmail,
                    'level' => 1,
                    'coins' => 100
                ]);

            $result = DB::table('user')
                ->select('id')
                ->where('username', $loginUser)
                ->get();
            foreach ($result as $user){
                $userID = $user->id;
            }

            DB::table('users_levels')
                ->insert([
                    'user_id' => $userID,
                    'level_id' => 1,
                    'stars' => 0,
                    'score' => 0
                ]);

        }
    }

    public function updateLevelHighscore(Request $request){
        $userID = $request->input('userID');
        $levelID = $request->input('levelID');
        $updatedScore = $request->input('updatedScore');
        $updatedStars = $request->input('updatedStars');

        DB::table('users_levels')->where('user_id', $userID)->where('level_id', $levelID)->update(['stars' => $updatedStars, 'score' => $updatedScore]);
    }

}
