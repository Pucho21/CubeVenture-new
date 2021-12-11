<?php

namespace Database\Seeders;

use App\Models\Users_levels;
use Illuminate\Database\Seeder;

class Users_levels_Seeder extends Seeder {
    /**
     * Run the database seeds.
     *
     * @return void
     */
    public function run() {

        $data = [
            ['id' => 1,
            'user_id' => '1',
            'level_id' => '1',
            'stars' => '0',
            'score' => '0',],
            ['id' => 2,
            'user_id' => '1',
            'level_id' => '2',
            'stars' => '0',
            'score' => '0',],
            ['id' => 3,
            'user_id' => '1',
            'level_id' => '3',
            'stars' => '0',
            'score' => '0',],
        ];
        foreach ($data as $level){
            if (!Users_levels::find($level['id'])) Users_levels::insert($level);
        }


    }
}
