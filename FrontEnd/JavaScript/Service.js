export const createGameFromApi = async (
    player1Name,
    player2Name,
    p1HeroType, 
    p2HeroType,
    backgroundEnvironment
  ) => {
    console.log("We are here");
  
    const url = "http://localhost:5188/fightRequest";
    const fightRequest = {
      p1: { name: player1Name },
      p2: { name: player2Name },
      p1HeroType: p1HeroType,
      p2HeroType: p2HeroType,
      BackgroundEnvironment: backgroundEnvironment,
    };
  
    try {
      const response = await fetch(url, {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(fightRequest),
      });
  
      if (!response.ok) {
        throw new Error("Network response was not ok");
      }
  
      const data = await response.json();
      return data; // Return the hero data
    } catch (error) {
      console.error("Error:", error);
      throw error; // Rethrow the error to handle it in the calling code
    }
    return await response.json();
  };
  