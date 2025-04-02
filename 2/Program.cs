using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Digite seu nome completo: ");
        string input = Console.ReadLine();

        char[] chars = input.ToCharArray();

        for (int i = 0; i < chars.Length; i++)
        {
            char c = chars[i];

            if (char.IsLetter(c))
            {
                if (char.IsUpper(c))
                {
                    c = (char)((c - 'A' + 2) + 'A');
                }
                else
                {
                    c = (char)((c - 'a' + 2) + 'a');
                }
                chars[i] = c;
            }
        }

        string saida = new string(chars);
        Console.WriteLine($"Resultado do deslocamento: {saida}");
    }
}