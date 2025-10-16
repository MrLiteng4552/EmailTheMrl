class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("====================");
        Console.WriteLine("ТреугольникоИнатор");
        Console.WriteLine("====================");
        Console.WriteLine("Введщите сторону a");
        string Inputnumber1 = Console.ReadLine();
        double doubleNumber1 = Convert.ToDouble(Inputnumber1);
        Console.WriteLine("Введщите сторону b");
        string Inputnumber2 = Console.ReadLine();
        double doubleNumber2 = Convert.ToDouble(Inputnumber2);
        Console.WriteLine("Введщите сторону c");
        string Inputnumber3 = Console.ReadLine();
        double doubleNumber3 = Convert.ToDouble(Inputnumber3);

        if((doubleNumber1 + doubleNumber2 > doubleNumber3) && (doubleNumber1 + doubleNumber3 > doubleNumber2) && (doubleNumber2 + doubleNumber3 > doubleNumber2))
        {
            int InputNumber1 = Convert.ToInt32(Inputnumber1);
            int InputNumber2 = Convert.ToInt32(Inputnumber2);
            int InputNumber3 = Convert.ToInt32(Inputnumber3);
            if ((InputNumber1) == (InputNumber2) && (InputNumber2) == (InputNumber3) && (InputNumber1) == (InputNumber3))
            {
                Console.WriteLine("Равносторонний треугольник");
            }
            else if ((InputNumber1) == (InputNumber2) || (InputNumber1) != (InputNumber3) || (InputNumber3) != (InputNumber2))
            {
                Console.WriteLine("Равнобедренный треугольник треугольник");
            }
            else if ((InputNumber1) != (InputNumber2) && (InputNumber2) != (InputNumber3) && (InputNumber1) != (InputNumber3))
            {
                Console.WriteLine("Разносторонний треугольник");
            }
        }   
        else
        {
            Console.WriteLine("Это не треугольник если что");
        }


    }

}
