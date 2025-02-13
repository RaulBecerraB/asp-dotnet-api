using System;

namespace GetPeople.Services;

public class RandomService : IRandomService
{
    private int _value;

    public int value
    {
        get { return _value; }
    }

    public RandomService()
    {
        _value = new Random().Next(1, 100);
    }
}
