using System;
using System.Collections.Generic;

class Program
{
    static byte[] Capital = new byte[]
    {
        0, 1, 1, 1, 2, 3, 3, 3, 4, 5, 5, 5, 5, 5,
        6, 7, 7, 7, 7, 7, 8, 9, 9, 9, 9, 9
    };

    static byte[] Lower = new byte[]
    {
        9, 8, 8, 8, 7, 6, 6, 6, 5, 4, 4, 4, 4, 4,
        3, 2, 2, 2, 2, 2, 1, 0, 0, 0, 0, 0
    };

    static void Main()
    {
        Console.WriteLine("Masukkan kata:");
        string input = Console.ReadLine();

        try
        {
            byte[] result1 = ConvertWordToNumberFormat(input);
            int result2 = CalculateConvertVersion(result1);
            var resultSeq = GenerateSequence(result2);
            var result3 = GenerateChar(resultSeq);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }

    public static byte ConvertChar(char c)
    {
        if (c == 32)
            return 0;

        if (!char.IsLetter(c))
            throw new ArgumentException("Input Tidak Valid");

        if (c >= 'a')
            return Lower[c - 'a'];

        return Capital[c - 'A'];
    }

    public static byte[] ConvertWordToNumberFormat(string word)
    {
        if (string.IsNullOrEmpty(word))
            throw new ArgumentException("Kata tidak boleh kosong");

        Console.Write("Jawaban no 1: ");

        byte[] result = new byte[word.Length];
        for (int i = 0; i < word.Length; i++)
        {
            result[i] = ConvertChar(word[i]);
            Console.Write(result[i]);
        }

        Console.WriteLine();
        return result;
    }

    public static int CalculateConvertVersion(byte[] data)
    {
        int result = 0;

        for (int i = 0; i < data.Length; i++)
        {
            if (i % 2 == 0)
                result -= data[i];
            else
                result += data[i];
        }

        Console.Write("Jawaban no 2: ");
        Console.WriteLine(result);

        return result;
    }

    static List<int> GenerateSequence(int target)
    {
        List<int> result = new List<int>();
        int sum = 0;
        int current = 0;
        int positifTarget = Math.Abs(target);

        while (sum < positifTarget)
        {
            if (sum + current > positifTarget)
            {
                current = 0;
                continue;
            }

            sum += current;
            result.Add(current);
            current++;
        }

        return result;
    }

    static List<char> GenerateChar(List<int> target)
    {
        List<char> result = new List<char>();

        foreach (int num in target)
        {
            int charIn = Array.IndexOf(Capital, (byte)num);
            int charNew = charIn + 65;
            char newChar = (char)charNew;
            result.Add(newChar);
        }

        Console.WriteLine("Jawaban no 3: " + string.Join("", result));
        return result;
    }
}
   
