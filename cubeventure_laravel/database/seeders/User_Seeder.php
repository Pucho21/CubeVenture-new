<?php

namespace Database\Seeders;

use App\Models\User;
use Illuminate\Database\Seeder;

class User_Seeder extends Seeder {
    /**
     * Run the database seeds.
     *
     * @return void
     */
    public function run() {

        $data = [
            'id' => 1,
            'username' => 'Default_user',
            'password' => 'c21f969b5f03d33d43e04f8f136e7682',
            'email' => 'default@gmail.com',
            'level' => '1',
            'coins' => '69420',
        ];
        if (!User::find($data['id'])) User::insert($data);

    }
}
