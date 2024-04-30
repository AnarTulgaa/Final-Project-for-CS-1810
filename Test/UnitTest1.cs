using Logic;
using Heroes;
using Player;
using Environment;

namespace Test
{
    public class UnitTest1
    {
        [Fact]
        public void TestPlayers()
        {
            // Arrange
            string playersName = "John";

            // Act
            Players players = new Players(playersName);

            // Assert
            Assert.Equal(playersName, players.Name);
        }

        [Fact]
        public void TestAttack()
        {
            // Arrange
            Hero heroes = new Viking();
            Hero heroes1 = new AssasinOfPersia();
            int startHealth = heroes1.Health;
            // Act
            heroes.Attack(heroes1);
            // Assert
            Assert.True(heroes1.Health < startHealth);
        }

        [Fact]
        public void TestViking()
        {
            // Arrange & Act
            Hero hero = new Viking();

            // Assert
            Assert.Equal(1, hero.Damage);
            Assert.Equal(20, hero.Health);
            Assert.Equal(4, hero.Armor);
        }

        [Fact]
        public void TestSpartan()
        {
            // Arrange & Act
            Hero hero = new Spartan();

            // Assert
            Assert.Equal(3, hero.Damage);
            Assert.Equal(18, hero.Health);
            Assert.Equal(1, hero.Armor);
        }

        [Fact]
        public void TestMongolWarrior()
        {
            // Arrange & Act
            Hero hero = new MongolWarrior();

            // Assert
            Assert.Equal(2, hero.Damage);
            Assert.Equal(16, hero.Health);
            Assert.Equal(2, hero.Armor);
        }

        [Fact]
        public void TestSamurai()
        {
            // Arrange & Act
            Hero hero = new Samurai();

            // Assert
            Assert.Equal(4, hero.Damage);
            Assert.Equal(14, hero.Health);
            Assert.Equal(2, hero.Armor);
        }

        [Fact]
        public void TestAssasinOfPersia()
        {
            // Arrange & Act
            Hero hero = new AssasinOfPersia();

            // Assert
            Assert.Equal(5, hero.Damage);
            Assert.Equal(13, hero.Health);
            Assert.Equal(0, hero.Armor);
        }

        [Fact]
        public void TestEnvironment()
        {
            // Arrange & Act
            Environments darkEnvironment = new DarkEnvironment("night");
            Environments sunnyEnvironment = new SunnyEnvironment("day");
            Environments castleEnvironment = new CastleEnvironment("inside");

            // Assert
            Assert.Equal("night", darkEnvironment.Description);
            Assert.Equal("day", sunnyEnvironment.Description);
            Assert.Equal("inside", castleEnvironment.Description);
        }

        [Fact]
        public void TestGame()
        {
            // Arrange
            Players players1 = new Players("Player 1");
            Players players2 = new Players("Player 2");
            Hero hero1 = new Viking();
            Hero hero2 = new Samurai();
            Environments environment = new DarkEnvironment("sunny");


            // Act
            Game gameInstance = new Game(players1, players2, hero1, hero2, environment, true, 0);

            // Assert
            Assert.NotNull(gameInstance);
            Assert.Equal(players1, gameInstance.player1);
            Assert.Equal(players2, gameInstance.player2);
            Assert.Equal(hero1, gameInstance.hero1);
            Assert.Equal(hero2, gameInstance.hero2);
            Assert.Equal(environment, gameInstance.environment);
            Assert.Equal(true, gameInstance.IsPlayer1Turn);
        }

        [Fact]
        public void TestChangingTurn()
        {
            // Arrange
            Players players1 = new Players("Player 1");
            Players players2 = new Players("Player 2");
            Hero hero1 = new Viking();
            Hero hero2 = new Samurai();
            Environments environment = new DarkEnvironment("sunny");
            Game gameInstance = new Game(players1, players2, hero1, hero2, environment, true, 0);


            // Act
            gameInstance.GamePlay();

            // Assert
            Assert.Equal(false, gameInstance.IsPlayer1Turn);
        }

        [Fact]
        public void TestLastHit()
        {
            // Arrange
            Players players1 = new Players("Player 1");
            Players players2 = new Players("Player 2");
            Hero hero1 = new Viking();
            Hero hero2 = new Samurai();
            Environments environment = new DarkEnvironment("night");
            Game gameInstance = new Game(players1, players2, hero1, hero2, environment, true, 0);


            // Act
            gameInstance.GamePlay();

            // Assert
            Assert.NotEqual(0, gameInstance.LastDamage);
        }

        [Fact]
        public void TestIsGameOver()
        {
            // Arrange
            Players players1 = new Players("Player 1");
            Players players2 = new Players("Player 2");
            Hero hero1 = new Viking();
            Hero hero2 = new Samurai();
            Environments environment = new DarkEnvironment("night");
            Game gameInstance = new Game(players1, players2, hero1, hero2, environment, true, 0);


            // Act
            for (int i = 0; i < 40; i++)
            {
                gameInstance.GamePlay();
            }


            // Assert
            Assert.Equal(true, gameInstance.IsGameOver);
        }
    }
}