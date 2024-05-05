using System.Text.Json;

public interface IDataLoad
{
    List<City> Cities();

    List<State> States();

    List<Country> Countries();

    List<T> Load<T>(string local);
}