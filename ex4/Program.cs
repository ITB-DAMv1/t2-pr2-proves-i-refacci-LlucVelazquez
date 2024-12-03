using System;

class Program
{
    static void Main(string[] args)
    {
        const string WidthRectangle = "Introdueix l'amplada del rectangle:";
        const string HeightRectangle = "Introdueix l'altura del rectangle:";
        const string AreaRectangle = "L'àrea del rectangle és: ";
        const string RadiusRectangle = "Introdueix el radi del cercle:";
        const string CircumferenceRectangle = "La circumferència del cercle és: ";
        double circumference = 0;
        double radius = 0;
        double area = 0;
        double width = 0;
        double height = 0;
        Console.WriteLine(WidthRectangle);
        width = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine(HeightRectangle);
        height = Convert.ToDouble(Console.ReadLine());

        // Calcula l'àrea
        area = CalcAreaRectangle(width, height);
        Console.WriteLine(AreaRectangle + area);

        // Sol·licita l'entrada de l'usuari per calcular la circumferència d'un cercle
        Console.WriteLine(RadiusRectangle);
        radius = Convert.ToDouble(Console.ReadLine());
        circumference = CalcCircumferenceRect(radius);
        Console.WriteLine(CircumferenceRectangle + circumference);

        // Imprimeix un missatge basat en el valor de l'àrea
        WriteAreaValor(area);
        
    }
    public static double CalcAreaRectangle(double width, double height)
    {
        double area = 0;
        area = width * height;
        return area;
    }
    public static double CalcCircumferenceRect(double radius)
    {
        double circumference = 2 * Math.PI * radius;
        return circumference;
    }
    public static void WriteAreaValor(double area)
    {
        const string AreaHigh = "L'àrea és més gran de 50";
        const string AreaMedium = "L'àrea és entre 20 i 50";
        const string AreaLow = "L'àrea és menor o igual a 20";
        if (area > 50)
        {
            Console.WriteLine(AreaHigh);
        }
        else if (area > 20)
        {
            Console.WriteLine(AreaMedium);
        }
        else
        {
            Console.WriteLine(AreaLow);
        }
    }
}