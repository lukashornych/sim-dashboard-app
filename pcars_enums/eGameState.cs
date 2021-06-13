using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dashboardapp.pcars_enums
{
    public enum eGameState
    {
        GAME_EXITED = 0, //waiting for game to start
        GAME_FRONT_END, //in menus
        GAME_INGAME_PLAYING, //in session
        GAME_INGAME_PAUSED, //game paused
        GAME_MAX
    }
}
