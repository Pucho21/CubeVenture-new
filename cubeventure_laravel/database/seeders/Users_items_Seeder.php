<?php

namespace Database\Seeders;

use App\Models\Users_items;
use Illuminate\Database\Seeder;

class Users_items_Seeder extends Seeder {
    /**
     * Run the database seeds.
     *
     * @return void
     */
    public function run() {

        $data = [
            'id' => 1,
            'user_id' => '1',
            'item_id' => '1',
        ];
        if (!Users_items::find($data['id'])) Users_items::insert($data);

    }
}
