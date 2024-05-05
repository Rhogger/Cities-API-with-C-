using System.Text.Json;

public abstract class DataLoadBase : IDataLoad
{

    public List<City> Cities()
    {
        return Load<City>(".\\data\\cities");
    }

    public List<State> States()
    {
        return Load<State>(".\\data\\states");
    }

    public List<Country> Countries()
    {
        return Load<Country>(".\\data\\countries");
    }

    public abstract List<T> Load<T>(string local);
}