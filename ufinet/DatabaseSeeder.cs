using Newtonsoft.Json.Linq;
using ufinet;
using ufinet.Entities;

namespace MyNamespace
{
    public static class DatabaseSeeder
    {
        public static async Task SeedAsync(ApplicationDbContext dbContext)
        {
            if (dbContext.Countries.Any())
            {
                // La base de datos ya ha sido poblada con datos, no hay necesidad de continuar.
                return;
            }

            using var httpClient = new HttpClient();
            var response = await httpClient.GetAsync("https://restcountries.com/v3.1/all?fields=name,ccn3,population");
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();

            var jArray = JArray.Parse(json);

            foreach (var jObject in jArray.Children<JObject>())
            {
                var nameObject = jObject["name"];
                var commonName = nameObject["common"].ToString();
                var officialName = nameObject["official"].ToString();

                var isoCode = jObject["ccn3"].ToString();
                var population = Convert.ToInt32(jObject["population"]);

                var country = new Country
                {
                    Name = commonName,
                    ISOCode = isoCode,
                    Population = population
                };

                dbContext.Countries.Add(country);
            }

            await dbContext.SaveChangesAsync();


            var random = new Random();
            foreach (var country in dbContext.Countries)
            {
                var hotels = new List<Hotel>();
                var restaurants = new List<Restaurant>();

                for (int i = 0; i < 10; i++)
                {
                    hotels.Add(new Hotel
                    {
                        Name = $"Hotel {i}",
                        Stars = random.Next(1, 6),
                        CountryId = country.Id
                    });

                    restaurants.Add(new Restaurant
                    {
                        Name = $"Restaurant {i}",
                        Type = "International",
                        CountryId = country.Id
                    });
                }

                await dbContext.Hotels.AddRangeAsync(hotels);
                await dbContext.Restaurants.AddRangeAsync(restaurants);
            }
        }
    }
}
