# ReCapProject

This repository provides Rent a car.

## Used Dependencies

``` csharp
/// <summary>
/// This interface includes custom query for Car Entity
/// </summary>
public interface ICarDal
{
    List<Car> GetAll();
    List<Car> GetById(int carId);
    void Add(Car car);
    void Update(Car car);
    void Delete(Car car);

}
```
