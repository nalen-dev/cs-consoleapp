using System;
using System.Collections.Generic;
using System.Linq;

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
            byte[] result1 = ConvertWordToNumberFormat(input, 1, true);
            int result2 = CalculateConvertVersion(result1);
            var resultSeq = GenerateSequence(result2);
            var result3 = GenerateChar(resultSeq, true);
            var result4 = GenerateCharAddLastTwo(result3);
            CharToNumbModEven(result4);
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

        return c >= 'a' ? Lower[c - 'a'] : Capital[c - 'A'];
    }

    public static byte[] ConvertWordToNumberFormat(string word, int quest, bool print)
    {
        if (string.IsNullOrEmpty(word))
            throw new ArgumentException("Kata tidak boleh kosong");

        if (print)
            Console.Write("Jawaban no 1: ");

        byte[] result = new byte[word.Length];
        for (int i = 0; i < word.Length; i++)
        {
            if (quest == 3 && result.Length - i <= 2)
            {
                result[i] = ConvertChar(word[i]);
                result[i]++;
            }
            else
            {
                result[i] = ConvertChar(word[i]);
            }

            if (print)
                Console.Write(result[i]);
        }


        return result;
    }

    public static int CalculateConvertVersion(byte[] data)
    {
        int result = data[0];

        for (int i = 1; i < data.Length; i++)
        {
            if (i % 2 == 1)
                result += data[i];
            else
                result -= data[i];
        }

        Console.Write("\nJawaban no 2: ");
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

    static List<char> GenerateChar(List<int> target, bool print)
    {
        List<char> result = new List<char>();

        foreach (int num in target)
        {
            int charIn = Array.IndexOf(Capital, (byte)num);
            int charNew = charIn + 65;
            char newChar = (char)charNew;
            result.Add(newChar);
        }

        if (print)
            Console.WriteLine("Jawaban no 3: " + string.Join("", result));

        return result;
    }

    static List<char> GenerateCharAddLastTwo(List<char> target)
    {
        string targetString = string.Join("", target);
        byte[] numbers = ConvertWordToNumberFormat(targetString, 3, false);
        List<int> numbersAsInts = numbers.Select(b => (int)b).ToList();
        List<char> result = GenerateChar(numbersAsInts, false);

        Console.WriteLine("Jawaban no 4: " + string.Join("", result));
        return result;
    }

    static void CharToNumbModEven(List<char> target)
    {
     string targetString = string.Join("", target); 
     byte[] numbers = ConvertWordToNumberFormat(targetString, 5, false);
     Console.Write("Jawaban no 5: ");
     for(int i = 0; i < numbers.Length; i++){
        if(numbers[i] % 2 ==0){
          numbers[i]++;
        }
        Console.Write(numbers[i]);
     }
      Console.Write("\n");
    }
}
  
