using System;

// Класс Фермер
public class Farmer
{
    private DroneOperator _droneOperator;

    // Конструктор принимает оператора дронов для взаимодействия
    public Farmer(DroneOperator droneOperator)
    {
        _droneOperator = droneOperator;
    }

    // Метод для отслеживания состояния полей
    public void TrackFieldStatus()
    {
        Console.WriteLine("Фермер відстежує стан полів.");
    }

    // Метод для запроса данных у оператора дронов
    public void RequestDataFromDroneOperator()
    {
        Console.WriteLine("Фермер запитує дані в оператора дронів.");
        _droneOperator.ProvideData(this); // Передаем фермера в метод ProvideData
    }

    // Метод для получения аналитики от агронома
    public void ReceiveAnalytics(AnalyticsData data)
    {
        Console.WriteLine("Фермер отримав аналітичні дані.");
        // Обработка аналитических данных
    }
}

// Класс Оператор Дронів
public class DroneOperator
{
    private Agronom _agronom;

    // Конструктор принимает агронома для взаимодействия
    public DroneOperator(Agronom agronom)
    {
        _agronom = agronom;
    }

    // Метод для управления дроном
    public void ControlDrone()
    {
        Console.WriteLine("Оператор керує дроном.");
    }

    // Метод для передачи данных агроному
    public void ProvideData(Farmer farmer)
    {
        Console.WriteLine("Оператор передає дані агроному.");
        _agronom.AnalyzeData(new DroneData(), farmer); // Передаем фермера агроному для обратной связи
    }
}

// Класс Агроном
public class Agronom
{
    // Метод для анализа данных и передачи аналитики фермеру
    public void AnalyzeData(DroneData data, Farmer farmer)
    {
        Console.WriteLine("Агроном аналізує дані з дронів.");
        // Анализ данных
        AnalyticsData analytics = new AnalyticsData();
        farmer.ReceiveAnalytics(analytics); // Возвращаем данные фермеру
    }
}

// Вспомогательные классы для данных
public class DroneData { }
public class AnalyticsData { }

class Program
{
    static void Main(string[] args)
    {
        // Создаем агронома
        Agronom agronom = new Agronom();

        // Создаем оператора дронов и передаем ему агронома
        DroneOperator droneOperator = new DroneOperator(agronom);

        // Создаем фермера и передаем ему оператора дронов
        Farmer farmer = new Farmer(droneOperator);

        // Взаимодействие классов
        farmer.TrackFieldStatus();
        farmer.RequestDataFromDroneOperator();
        droneOperator.ControlDrone();
    }
}