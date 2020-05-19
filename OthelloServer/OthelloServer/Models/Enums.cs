using System;
using System.Collections.Generic;
using System.Text;

namespace OthelloServer.Models
{
    // An enum for each of the players
    public enum Players
    {
        Player0 = 0,
        Plater1 = 1
    }

    // An enum for the owner's token of a square
    public enum Tokens
    {
        TokenBorder = 0,
        TokenP1 = 1,
        TokenP2 = 2,
        TokenUnclaimed = 3
    }

    public enum GamePieceShapes
    {
        SHAPE_UNDEFINED = 0,
        SHAPE_CIRCLE = 1,
        SHAPE_SQUARE = 2
    }
}
