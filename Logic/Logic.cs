using System;
using Player;
using Heroes;
using Environment;

namespace Logic;


public class FightRequest
{
    public Players P1 { get; set; }
    public Players P2 { get; set; }
    public string P1HeroType { get; set; }
    public string P2HeroType { get; set; }
    public string BackgroundEnvironment { get; set; }
}

public class Game
{
    public Players player1 { get; protected set; }
    public Players player2 { get; protected set; }
    public bool IsPlayer1Turn { get; protected set; }
    public Hero hero1 { get; protected set; }
    public Hero hero2 { get; protected set; }
    public Environments environment { get; protected set; }
    public int LastDamage { get; protected set; }
    public bool IsGameOver { get; protected set; }
    public Game(Players p1, Players p2, Hero h1, Hero h2, Environments env, bool isTurnPlayer1, int lastDamage)
    {
        player1 = p1;
        player2 = p2;
        hero1 = h1;
        hero2 = h2;
        environment = env;
        IsPlayer1Turn = isTurnPlayer1;
        LastDamage = lastDamage;
        IsGameOver = false;
    }

    public void GamePlay()
    {
        environment.BackgroundDisplay();

        if (IsPlayer1Turn == true)
        {

            LastDamage = hero1.Attack(hero2);
            IsPlayer1Turn = false;
            if (hero2.Health <= 0)
            {
                IsGameOver = true;
            }
        }
        else
        {
            LastDamage = hero2.Attack(hero1);
            IsPlayer1Turn = true;
            if (hero1.Health <= 0)
            {
                IsGameOver = true;
            }
        }
    }
}