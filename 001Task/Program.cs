using _001Task.Data;
using Microsoft.EntityFrameworkCore;

await using var dataContext = new DataContext();

//1
//Напишите запрос LINQ, чтобы получить всех людей, живущих в городе с населением более 3 милион человек.
//Write a LINQ query to retrieve all the people who live in a city with a population greater than 3 

// var res1 = from p in dataContext.Peoples
//     join c in dataContext.Cities on p.CityId equals c.Id
//     where c.Population > 3000000
//     select new
//     {
//     people = p.FirstName
//     };
// foreach (var r in res1)
// {
//     Console.WriteLine(r.people);
// }

//2
//Получите все города со средней численностью населения в соответствующей стране
//Retrieve all cities with their respective country's average population

// var res2 = from c in dataContext.Cities
//     join co in dataContext.Countries on c.CountryId equals co.Id
//     let average = dataContext.Cities.Average(x => x.Population)
//     where c.Population > average
//     select new
//     {
//         city = c.Name
//     };
// foreach (var r in res2)
// {
//     Console.WriteLine(r.city);
// }

//3
//Получите города с самым высоким населением в каждой стране
//Retrieve the cities with the highest population in each country

// var res2 = from c in dataContext.Cities
//     let high = dataContext.Cities.Max(x => x.Population)
//     where c.Population==high
//     select new
//     {
//         city = c.Name
//     };
// foreach (var r in res2)
// {
//     Console.WriteLine(r.city);
// }

//4
//Получите среднее население городов в каждой стране
//Retrieve the average population of cities in each country

// var res3 = from c in dataContext.Cities
//     let average = dataContext.Cities.Average(x => x.Population)
//     select new
//     {
//         city = c.Name,
//         average = average
//     };
// foreach (var r in res3)
// {
//     Console.WriteLine(r.city + " " + r.average);
// }


//5
//Получить все города, в которых есть человек по имени "Марк".
//Retrieve all cities that have a person with by name "Mark"

// var res4 = from p in dataContext.Peoples
//     let people = p.FirstName.Contains("Mark")
//     join c in dataContext.Cities on p.CityId equals c.Id
//     select new
//     {
//         city = c.Name
//     };
// foreach (var r in res4)
// {
//     Console.WriteLine(r.city);
// }


//6
//Получить всех людей вместе с соответствующими названиями городов и стран
//Retrieve all people along with their associated city and country names

// var res6 = from p in dataContext.Peoples
//     join c in dataContext.Cities on p.CityId equals c.Id
//     join co in dataContext.Countries on c.CountryId equals co.Id
//     select new
//     {
//         country = co.Name,
//         city = c.Name,
//         people = p.FirstName
//     };
// foreach (var r in res6)
// {
//     Console.WriteLine(r.country + " " + r.city + " " + r.people);
// }


//7
//Получите все города вместе с соответствующими названиями стран, используя свойство навигации
//Retrieve all cities along with their associated country names using a navigation property

// var res7 = dataContext.Cities.Include(x=>x.Country).Select(x=>new
// {
//     city = x.Name,
//     country = x.Country.Name
// });
// foreach (var r in res7)
// {
//     Console.WriteLine(r.city + " " + r.country);
// }

//8
//Получить всех людей вместе с связанными с ними городом и страной.
//Retrieve all people along with their associated city and country 

// var res8 = from p in dataContext.Peoples
//     join c in dataContext.Cities on p.CityId equals c.Id
//     join co in dataContext.Countries on c.CountryId equals co.Id
//     select new
//     {
//         country = co.Name,
//         city = c.Name,
//         people = p.FirstName
//     };
// foreach (var r in res8)
// {
//     Console.WriteLine(r.country + " " + r.city + " " + r.people);
// }

//9
//Получить всех людей, живущих в "USA".
//Retrieve all people living in  "USA".

// var res9 = from p in dataContext.Peoples
//     join c in dataContext.Cities on p.CityId equals c.Id
//     join co in dataContext.Countries on c.CountryId equals co.Id
//     where co.Name.Contains("USA")
//     select new
//     {
//         people = p.FirstName
//     };
// foreach (var r in res9)
// {
//     Console.WriteLine(r.people);
// }

//10
//Получить всех людей вместе с соответствующим населением города и страны
//Retrieve all people along with their associated city and country populations 

var res10 = dataContext.Peoples.Include(x => x.City).ThenInclude(c => c.Country).Select(x => new
{
    people = x.FirstName,
    citypop = x.City.Population,
    counpop = dataContext.Cities.Sum(x => x.Population)
});
foreach (var r in res10)
{
    Console.WriteLine(r.people + " " + r.citypop + " " + r.counpop);
}





