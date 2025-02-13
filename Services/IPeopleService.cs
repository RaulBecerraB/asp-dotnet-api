using System;

namespace GetPeople.Controllers;

public interface IPeopleService
{
    bool Validate(People people);
}
