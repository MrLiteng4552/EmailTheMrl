class ArrayReverser
{
    static void Main()
    {
        int[] originalArray = { 2021, 2022, 2023, 2024, 2025 };
        int arrayLength = originalArray.Length;

        Console.Write("Исхадный массив: ");
        foreach (int element in originalArray)
        {
            Console.Write(element + " ");
        }
        Console.WriteLine(); 

        int[] reversedArray = new int[arrayLength];


        for (int i = 0; i < arrayLength; i++)
        {
            reversedArray[i] = originalArray[arrayLength - 1 - i];
        }

        Console.Write("Пиривернутый массив: ");
        foreach (int element in reversedArray)
        {
            Console.Write(element + " ");
        }
        Console.WriteLine();
    }
}
//вообще это можно сделать так:
//Console.WriteLine("Исходный массив: 2021, 2022, 2023, 2024, 2025");
//Console.WriteLine("Перевернутый массив: 2025, 2024, 2023, 2022, 2021");
//Готово!