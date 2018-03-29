using System;
using Xunit;
using Lab04;
using static Lab04.Program;

namespace Lab4Test
{
    public class UnitTest1
    {
        Player player = new Player("test", "#");

        [Fact]
        public void CanStringArray()
        {
            GameBoard gameBoard = new GameBoard();
            Assert.Equal("|0| |1| |2|\n|3| |4| |5|\n|6| |7| |8|\n",
                gameBoard.StringBoard(new string[3, 3] { { "|0|", "|1|", "|2|" }, { "|3|", "|4|", "|5|" }, { "|6|", "|7|", "|8|" } }));
        }

        [Fact]
        public void CanModifyArrayStart()
        {
            GameBoard gameBoard = new GameBoard();
            Assert.Equal(new string[3, 3] { { "|#|", "|1|", "|2|" }, { "|3|", "|4|", "|5|" }, { "|6|", "|7|", "|8|" } },
                gameBoard.UpdateBoard(0, "#"));
        }

        [Fact]
        public void CanModifyArrayMid()
        {
            GameBoard gameBoard = new GameBoard();
            Assert.Equal(new string[3, 3] { { "|0|", "|1|", "|2|" }, { "|3|", "|#|", "|5|" }, { "|6|", "|7|", "|8|" } },
                gameBoard.UpdateBoard(4, "#"));
        }

        [Fact]
        public void CanModifyArrayEnd()
        {
            GameBoard gameBoard = new GameBoard();
            Assert.Equal(new string[3, 3] { { "|0|", "|1|", "|2|" }, { "|3|", "|4|", "|5|" }, { "|6|", "|7|", "|#|" } },
                gameBoard.UpdateBoard(8, "#"));
        }

        [Fact]
        public void CanMakeGameBoard()
        {
            Assert.IsNotType<GameBoard>(new GameBoard());
        }

        [Theory]
        [InlineData("Kevin", "&")]
        [InlineData("Peter", "*")]
        [InlineData("Amanda", "?")]

        public void CanMakePlayr(string playerName, string playerSymbol)
        {
            Assert.IsType<Player>(new Player(playerName, playerSymbol));
        }
    }
}
