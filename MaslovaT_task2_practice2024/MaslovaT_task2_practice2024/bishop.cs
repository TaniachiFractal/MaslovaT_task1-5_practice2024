using System;

namespace MaslovaT_task2_practice2024
{
    internal static class bishop
    {
        /// <summary>
        ///  Даны координаты нахождения слона на шахматной доске. Требуется определить, бьет ли слон фигуру, стоящую на другой 
        ///  указанной клетке за один ход. Координаты слона и фигуры вводятся согласно шахматной записи через пробел в одну строку. 
        ///  В качестве выходного сообщения выводится одна из строк: "Слон сможет побить фигуру", "Слон не сможет побить фигуру", 
        ///  "Введены некорректные координаты"
        /// </summary>
        static void Main()
        {
            Console.WriteLine("Введите координаты слона и координаты второй фигуры в формате e3, b6, т.д: ");
            string inputLine = Console.ReadLine();
            string bishopPosition = inputLine.Split()[0];
            string otherPiecePosition = inputLine.Split()[1];

            if (!TwoChessPiecesInputValid(bishopPosition, otherPiecePosition))
            {
                Console.WriteLine("Вы ввели некорректные координаты");
                Console.ReadKey();
                return;
            }

            if (BishopCanEatPiece(bishopPosition,otherPiecePosition))
            {
                Console.WriteLine("Слон сможет побить фигуру");
                Console.ReadKey();
                return;
            }
            else
            {
                Console.WriteLine("Слон не сможет побить фигуру");
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
            if (!(input[0] >= 'a' && input[0] <= 'e')) return false;
            if (!(input[1] >= '1' && input[1] <= '8')) return false;
            return true;
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
            return (9-LetterPartOfPositionInt(chessPiecePosition)) + DigitPartOfPositionInt(chessPiecePosition);
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
        static bool BishopCanEatPiece(string bishopPosition, string piecePosition) 
        {
            if (TwoChessPiecesInTheSameMainDiagonal(piecePosition, bishopPosition) || TwoChessPiecesInTheSameSecondaryDiagonal(piecePosition,bishopPosition)) 
            {
                return true;
            }
            return false;
        }
    }
}