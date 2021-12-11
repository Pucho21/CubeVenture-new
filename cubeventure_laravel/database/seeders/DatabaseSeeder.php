<?php

namespace Database\Seeders;

use Illuminate\Database\Seeder;

class DatabaseSeeder extends Seeder {
    /**
     * Run the database seeds.
     *
     * @return void
     */
    public function run() {

        $this->call([
            User_Seeder::class,
            Users_items_Seeder::class,
            Users_levels_Seeder::class,
        ]);
    }
}
