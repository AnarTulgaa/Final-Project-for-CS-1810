using System.Text.Json;
using Environment;
using Heroes;
using Logic;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors();

var app = builder.Build();
app.UseCors(x => x.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());

app.MapGet("/", () => "Hello World!");

app.MapPost("/fightRequest", (FightRequest startGame) =>
{
    Hero player1Hero = startGame.P1HeroType switch
    {
        "Spartan" => new Spartan(),
        "MongolWarrior" => new MongolWarrior(),
        "Samurai" => new Samurai(),
        "AssasinOfPersia" => new AssasinOfPersia(),
        _=> new Viking(),
    };
    Console.WriteLine(startGame.P2HeroType);
    Hero player2Hero = startGame.P2HeroType switch
    {

        "Spartan" => new Spartan(),
        "MongolWarrior" => new MongolWarrior(),
        "Samurai" => new Samurai(),
        "AssasinOfPersia" => new AssasinOfPersia(),
        _=> new Viking(),
    };

    Environment.Environments backgroundEnvi = startGame.BackgroundEnvironment switch
    {
        "Dark" => new DarkEnvironment(),
        "Castle" => new CastleEnvironment(),
        _=> new SunnyEnvironment(),
    };

    Game game = new Game(startGame.P1, startGame.P2, player1Hero, player2Hero, backgroundEnvi, true, 0);
    return game;
});

app.Run();