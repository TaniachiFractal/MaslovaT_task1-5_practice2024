using System;

namespace MaslovaT_task3_practice2024
{
    internal static class Program
    {
        /// <summary>
        ///  Даны координаты нахождения ферзя на шахматной доске. Требуется определить, бьет ли ферзь фигуру, стоящую 
        ///  на другой указанной клетке за один ход. Координаты ферзя и фигуры вводятся согласно шахматной записи через
        ///  пробел в одну строку. В качестве выходного сообщения выводится одна из строк: "Ферзь сможет побить фигуру", 
        ///  "Ферзь не сможет побить фигуру", "Введены некорректные координаты"
        /// </summary>
        static void Main()
        {
            Console.WriteLine("Введите координаты ферзя и координаты второй фигуры в формате e3, b6, т.д: ");
            string inputLine = Console.ReadLine();
            string queenPosition = inputLine.Split()[0];
            string otherPiecePosition = inputLine.Split()[1];

            if (!TwoChessPiecesInputValid(queenPosition, otherPiecePosition))
            {
                Console.WriteLine("Вы ввели некорректные координаты");
                Console.ReadKey();
                return;
            }

            if (QueenCanEatPiece(queenPosition,otherPiecePosition))
            {
                Console.WriteLine("Ферзь сможет побить фигуру");
                Console.ReadKey();
                return;
            }
            else
            {
                Console.WriteLine("Ферзь не сможет побить фигуру");
                Console.ReadKey();
                return;
            }
        }


        /// <summary>
        /// Выдаёт правильно или неправильно записана координата шахматной фигуры. Правильный формат: h8 - [латинская буква a-h][цифра 1-8]
        /// </summary>
        static bool ChessPiecePositionValid(string input)
        {
            if (input.Length != 2) return false;
            if (!(input[0] >= 'a' && input[0] <= 'h')) return false;
            if (!(input[1] >= '1' && input[1] <= '8')) return false;
            return true;
        }
        /// <summary>
        /// Проверка двух шахматных координат на верность и на неравенство
        /// </summary>
        static bool TwoChessPiecesInputValid(string piecePosition1, string piecePosition2)
        {
            if (!ChessPiecePositionValid(piecePosition1) || !ChessPiecePositionValid(piecePosition2))
            {
                return false;
            }
            else if (piecePosition1 == piecePosition2)
            {
                return false;
            }
            return true;
        }
     
        
        
        /// <summary>
        /// Сумма двух координат шахматной фигуры, если а = 1; h = 8
        /// </summary>
        static int SumOfaPosition(string chessPiecePosition)
        {
            return LetterPartOfPositionInt(chessPiecePosition) + DigitPartOfPositionInt(chessPiecePosition);
        }
        /// <summary>
        /// Сумма двух координат шахматной фигуры, если а = 8; h = 1
        /// </summary>
        static int SumOfaPositionInverted(string chessPiecePosition)
        {
            return (9 - LetterPartOfPositionInt(chessPiecePosition)) + DigitPartOfPositionInt(chessPiecePosition);
        }
        /// <summary>
        /// Узнать, находятся ли 2 шахматные фигуры в одной диагонали, параллельной a8-h1 (их сумма кооржинат равна)
        /// </summary>
        static bool TwoChessPiecesInTheSameMainDiagonal(string piecePosition1, string piecePosition2)
        {
            return SumOfaPosition(piecePosition1) == SumOfaPosition(piecePosition2);
        }
        /// <summary>
        /// Узнать, находятся ли 2 шахматные фигуры в одной диагонали, параллельной a1-h8 (их сумма кооржинат равна, если одну координатную прямую перевернуть)
        /// </summary>
        static bool TwoChessPiecesInTheSameSecondaryDiagonal(string piecePosition1, string piecePosition2)
        {
            return SumOfaPositionInverted(piecePosition1) == SumOfaPositionInverted(piecePosition2);
        }
        


        /// <summary>
        /// Получить букву координаты фигуры в числовом формате. Пример: ВВОД - b1, ВЫВОД - 2; ВВОД - h1, ВЫВОД - 8
        /// </summary>
        static int LetterPartOfPositionInt(string input)
        {
            return (int)(input[0]) - 96;
        }
        /// <summary>
        /// Получить цифру координаты фигуры в числовом формате. Пример: ВВОД - a1, ВЫВОД - 1
        /// </summary>
        static int DigitPartOfPositionInt(string input)
        {
            return (int)(input[1]) - 48;
        }


        /// <summary>
        /// Проверка, что у 2 фигур одинаковая буква -> стоят в одном столбце -> ладья может съесть
        /// </summary>
        static bool TwoChessPiecesHaveSameLetter(string piecePosition1, string piecePosition2)
        {
            if (LetterPartOfPositionInt(piecePosition1) == LetterPartOfPositionInt(piecePosition2))
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// Проверка, что у 2 фигур одинаковая цифра -> стоят в одной строке -> ладья может съесть
        /// </summary>
        static bool TwoChessPiecesHaveSameDigit(string piecePosition1, string piecePosition2)
        {
            if (DigitPartOfPositionInt(piecePosition1) == DigitPartOfPositionInt(piecePosition2))
            {
                return true;
            }
            return false;
        }
      
        
        
        /// <summary>
        /// Узнать, может ли ладья съесть фигуру
        /// </summary>
        static bool RookCanEatPiece(string rookPosition, string otherPiecePosition)
        {
            if (TwoChessPiecesHaveSameDigit(otherPiecePosition, rookPosition) || TwoChessPiecesHaveSameLetter(otherPiecePosition, rookPosition))
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// Узнать, может ли слон может побить фигуру
        /// </summary>
        static bool BishopCanEatPiece(string bishopPosition, string piecePosition)
        {
            if (TwoChessPiecesInTheSameMainDiagonal(piecePosition, bishopPosition) || TwoChessPiecesInTheSameSecondaryDiagonal(piecePosition, bishopPosition))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Узнать, может ли ферзт может побить фигуру
        /// </summary>
        static bool QueenCanEatPiece(string queenPosition, string piecePosition)
        {
            if (BishopCanEatPiece(queenPosition, piecePosition) || RookCanEatPiece(queenPosition, piecePosition))
            {
                return true;
            }
            return false; 
        }

    }
}