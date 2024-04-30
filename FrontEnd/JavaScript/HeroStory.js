function filterHeroes() {
    const searchInput = document
      .getElementById("searchInput")
      .value.toLowerCase();
    const heroCards = document.querySelectorAll(".hero-card");
  
    heroCards.forEach((card) => {
      const heroName = card.querySelector(".hero-name").innerText.toLowerCase();
      const heroDescription = card
        .querySelector(".hero-description")
        .innerText.toLowerCase();
  
      if (
        heroName.includes(searchInput) ||
        heroDescription.includes(searchInput)
      ) {
        card.style.display = "block";
      } else {
        card.style.display = "none";
      }
    });
  }
  
  document.getElementById("searchInput").addEventListener("input", filterHeroes);
  
    // Get the return button element
    const returnBtn = document.getElementById("returnBtn");
  
    // Add click event listener to the return button
    returnBtn.addEventListener("click", () => {
      // Navigate back to the main menu page
      window.location.href = "mainMenu.html";
    });