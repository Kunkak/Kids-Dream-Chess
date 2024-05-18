using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rook : Piece
{
    void Awake()
    {
        base.OnStart();
        Type = "rook";
    }

    protected override bool[,] Moves()
    {
        bool[,] moves = Piece.EmptyBoard();
        int column = position.x + 1, row = position[1];

        // check squeres to the right
        while (column < 9) 
        {
            if (GameManager.instance.CheckPiece(column, row) == null)
            {
                moves[column, row] = true;
                column++;
            }
            else if (GameManager.instance.CheckPiece(column, row) == !white)
            {
                moves[column, row] = true;
                break;
            }
            else
                break;
        }

        //check squeres to the left
        column = position.x - 1;
        while (column > 0)
        {
            if (GameManager.instance.CheckPiece(column, row) == null)
            {
                moves[column, row] = true;
                column--;
            }
            else if (GameManager.instance.CheckPiece(column, row) == !white)
            {
                moves[column, row] = true;
                break;
            }
            else
                break;
        }

        //check squeres above
        column = position.x; row = position[1] + 1;
        while (row < 9)
        {
            if (GameManager.instance.CheckPiece(column, row) == null)
            {
                moves[column, row] = true;
                row++;
            }
            else if (GameManager.instance.CheckPiece(column, row) == !white)
            {
                moves[column, row] = true;
                break;
            }
            else
                break;
        }

        //check squeres under
        row = position[1] - 1;
        while (row > 0)
        {
            if (GameManager.instance.CheckPiece(column, row) == null)
            {
                moves[column, row] = true;
                row--;
            }
            else if (GameManager.instance.CheckPiece(column, row) == !white)
            {
                moves[column, row] = true;
                break;
            }
            else
                break;
        }

        
        return moves;
    }

    public override void FillChecksBoard()
    {
        var board = white ? GameManager.instance.whiteChecks : GameManager.instance.blackChecks;

        int column, row;

        // check squeres to the right
        column = position.x + 1; row = position.y;
        while (column < 9)
        {
            if (GameManager.instance.CheckPiece(column, row) == null)
            {
                board[column, row] = true;
                column++;
            }
            else if (GameManager.instance.CheckPiece(column, row) == !white && GameManager.instance.board[column, row].Type == "king")
            {
                board[column, row] = true;
                column++;
            }
            else
            {
                board[column, row] = true;
                break;
            }
        }

        //check squeres to the left
        column = position.x - 1;
        while (column > 0)
        {
            if (GameManager.instance.CheckPiece(column, row) == null)
            {
                board[column, row] = true;
                column--;
            }
            else if (GameManager.instance.CheckPiece(column, row) == !white && GameManager.instance.board[column, row].Type == "king")
            {
                board[column, row] = true;
                column--;
            }
            else
            {
                board[column, row] = true;
                break;
            }
        }

        //check squeres above
        column = position.x; row = position.y + 1;
        while (row < 9)
        {
            if (GameManager.instance.CheckPiece(column, row) == null)
            {
                board[column, row] = true;
                row++;
            }
            else if (GameManager.instance.CheckPiece(column, row) == !white && GameManager.instance.board[column, row].Type == "king")
            {
                board[column, row] = true;
                row++;
            }
            else
            {
                board[column, row] = true;
                break;
            }
        }

        //check squeres under
        row = position.y - 1;
        while (row > 0)
        {
            if (GameManager.instance.CheckPiece(column, row) == null)
            {
                board[column, row] = true;
                row--;
            }
            else if (GameManager.instance.CheckPiece(column, row) == !white && GameManager.instance.board[column, row].Type == "king")
            {
                board[column, row] = true;
                row--;
            }
            else
            {
                board[column, row] = true;
                break;
            }
        }
    }

}
