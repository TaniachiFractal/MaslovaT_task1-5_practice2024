using System;

namespace MaslovaT_task1_practice2024
{
    internal static class Program
    {
        /// <summary>
        /// Даны координаты нахождения ладьи на шахматной доске. Требуется определить, бьет ли ладья фигуру,
        /// стоящую на другой указанной клетке за один ход. Координаты ладьи и фигуры вводятся согласно шахматной 
        /// записи через пробел в одну строку. В качестве выходного сообщения выводится одна из строк: "Ладья сможет побить фигуру",
        /// "Ладья не сможет побить фигуру", "Введены некорректные координаты"
        /// </summary>
        static void Main()
        {
            Console.WriteLine("Введите координаты ладьи и координаты второй фигуры в формате e3, b6, т.д: ");
            string inputLine = Console.ReadLine();
            string rookPosition = inputLine.Split()[0];
            string otherPiecePosition = inputLine.Split()[1];

            if (!TwoChessPiecesInputValid(rookPosition, otherPiecePosition))
            {
                Console.WriteLine("Вы ввели некорректные координаты");
                Console.ReadKey();
                return;
            }

            if (RookCanEatPiece(rookPosition,otherPiecePosition)) 
            {
                Console.WriteLine("Ладья сможет побить фигуру");
                Console.ReadKey();
                return;
            }
            else
            {
                Console.WriteLine("Ладья не сможет побить фигуру");
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
        /// Получить букву координаты фигуры. Пример: ВВОД - a1, ВЫВОД - a
        /// </summary>
        static char LetterPartOfPosition(string input)
        {
            return input[0];
        }
        /// <summary>
        /// Получить цифру координаты фигуры. Пример: ВВОД - a1, ВЫВОД - 1
        /// </summary>
        static char DigitPartOfPosition(string input)
        {
            return input[1];
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
        /// Проверка, что у 2 фигур одинаковая буква -> стоят в одном столбце -> ладья может съесть
        /// </summary>
        static bool TwoChessPiecesHaveSameLetter(string piecePosition1, string piecePosition2)
        {
            if (LetterPartOfPosition(piecePosition1) == LetterPartOfPosition(piecePosition2))
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
            if (DigitPartOfPosition(piecePosition1) == DigitPartOfPosition(piecePosition2))
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
            if (  TwoChessPiecesHaveSameDigit(otherPiecePosition, rookPosition) || TwoChessPiecesHaveSameLetter(otherPiecePosition,rookPosition) )
            {
                return true;
            }
            return false;
        }
    }
}