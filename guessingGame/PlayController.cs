using System;
using System.Collections.Generic;

namespace guessingGame
{

    class ProgramController
    {
        private bool quit = false;

        public ProgramController(PlayerStatistics user_data)
        {
            PlayerStatistics data_file = user_data;
            CheatController cheats = new CheatController();

            //run software until quit

            while (quit)
            {
                // build menu
                //take in a choice
                //play game of choosing
                //capture the data back contained in userdata
                // pass same userdata into as many games as needed and 
            }
        }

        //number guess game
    }

    //Cheat controller
    class CheatController
    {
        private bool inf_lives = false;
        private bool not_random = false;
    }
    //number guess game
}
