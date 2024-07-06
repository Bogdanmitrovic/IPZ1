var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

var surnames = new[]
{
    "Mohammad", "Abdul", "Bibi", "Gul", "Sayed", "Ghulam", "Fatima", "Ahmad", "Noor", "Shah", "Ali", "Zahra",
    "Abdullah", "Maryam", "Muhammad", "Shir", "Amina", "Jamila", "Najiba", "Siddiqa", "Khan", "Juma", "Habibullah",
    "Khadija", "Haji", "Rahmatullah", "Zainab", "Najibullah", "Sayyid", "Sharifa", "Sakina", "Masooma", "Marzieh",
    "Farzana", "Zarmina", "Lal", "Raazyaah", "Farashthaah", "Hamidullah", "Halima", "Mir", "Fawzia", "Norie", "Shukria",
    "Amir"
};
var names = new[]
{
    "Fatemah", "Habib", "KaramUllah", "Kasir", "Nasrat", "Nazgul", "Mahboob", "Nursultan", "Borat", "Obaidullah",
    "Sayed", "Omid", "Parwiz", "Rahmat", "Rahmatullah", "Rahim"
};
var organizations = new[]
{
    "Al Qaeda", "Taliban", "ISIS", "ISIL", "Boko Haram", "Al Shabaab", "Hamas", "Hezbollah", "PKK", "FARC", "IRA"
};
var americanNames = new[]
{
    "John", "James", "Robert", "Michael", "William", "David", "Richard", "Joseph", "Thomas", "Charles", "Daniel",
    "Matthew"
};
var americanSurnames = new[]
{
    "Smith", "Johnson", "Williams", "Jones", "Brown", "Davis", "Miller", "Wilson", "Moore", "Taylor", "Anderson"
};
var americanMilitaryUnits = new[]
{
    "1st Infantry Division", "1st Cavalry Division", "1st Armored Division", "1st Marine Division",
    "1st Marine Expeditionary Force",
    "2nd Infantry Division", "2nd Marine Division", "2nd Marine Expeditionary Force", "3rd Infantry Division",
    "3rd Marine Division",
    "3rd Marine Expeditionary Force", "4th Infantry Division", "4th Marine Division", "4th Marine Expeditionary Force",
    "5th Marine Division",
    "5th Marine Expeditionary Force", "6th Marine Division", "6th Marine Expeditionary Force", "7th Infantry Division",
    "7th Marine Division",
    "7th Marine Expeditionary Force", "8th Infantry Division", "8th Marine Division", "8th Marine Expeditionary Force",
    "9th Infantry Division"
};
var americanMilitaryRanks = new[]
{
    "Private", "Private First Class", "Corporal", "Sergeant", "Staff Sergeant", "Sergeant First Class",
    "Master Sergeant", "First Sergeant", "Sergeant Major", "Command Sergeant Major"
};
var afghanEncounterLocations = new[]
{
    "Kabul", "Kandahar", "Herat", "Mazar-i-Sharif", "Kunduz", "Jalalabad", "Lashkar Gah", "Taloqan", "Puli Khumri"
};
var afghanRegions = new[]
{
    "Badakhshan", "Badghis", "Baghlan", "Balkh", "Bamyan", "Daykundi", "Farah", "Faryab", "Ghazni", "Ghor", "Helmand",
    "Herat", "Jowzjan", "Kabul", "Kandahar", "Kapisa", "Khost", "Kunar", "Kunduz", "Laghman", "Logar", "Nangarhar",
    "Nimroz", "Nuristan", "Paktia", "Paktika", "Panjshir", "Parwan", "Samangan", "Sar-e Pol", "Takhar", "Urozgan",
    "Zabul"
};

app.MapGet("/weatherforecast", () =>
    {
        var forecast = Enumerable.Range(1, 5).Select(index =>
                new WeatherForecast
                (
                    DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    Random.Shared.Next(-20, 55),
                    summaries[Random.Shared.Next(summaries.Length)]
                ))
            .ToArray();
        return forecast;
    })
    .WithName("GetWeatherForecast")
    .WithOpenApi();

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}