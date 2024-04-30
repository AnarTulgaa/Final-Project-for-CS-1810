import {
    GetPlayer1Hero,
    GetPlayer2Hero,
    SetPlayer1Hero,
    SetPlayer2Hero,
  } from "./Domain.js";
  import { createGameFromApi } from "./Service.js";
  
  const startGameBtn = document.getElementById("startGameBtn");
  
  startGameBtn.addEventListener("click", async () => {
    // Get player names and hero types
    const player1Name = document.getElementById("player1Name").value;
    const player2Name = document.getElementById("player2Name").value;
    const hero1Select = GetPlayer1Hero();
    const hero2Select = GetPlayer2Hero();
    const environmentSelect = document.getElementById("environmentSelect");
  
    console.log(hero1Select);
    console.log(hero2Select);
    const p1HeroType = GetPlayer1Hero();
    const p2HeroType = GetPlayer2Hero();
  
    // Ensure hero1Select and hero2Select are defined
    if (hero1Select && hero2Select) {
      // Get the selected hero types
  
      // Get the selected environment
      const backgroundEnvironment =
        environmentSelect.options[environmentSelect.selectedIndex].value;
  
      // Call createGameFromApi function with the retrieved data
      const game = await createGameFromApi(
        player1Name,
        player2Name,
        p1HeroType,
        p2HeroType,
        backgroundEnvironment
      );
      console.log(game);
    }
  
    // Store the selected hero names in local storage
    // window.location.href = `gamePlay.html?p1Hero=${encodeURIComponent(p1HeroType)}&p2Hero=${encodeURIComponent(p2HeroType)}`;
    // console.log();
  });
  
  const heroCards = document.querySelectorAll(".hero-card");
  const playerCards = document.querySelectorAll(".player-card");
  const player1Card = document.getElementById("player1Card");
  const player2Card = document.getElementById("player2Card");
  
  const player1HeroContainer = document.getElementById("player1Hero");
  const player2HeroContainer = document.getElementById("player2Hero");
  
  // Add event listeners for drag and drop to the hero containers
  player1HeroContainer.addEventListener("dragover", dragOver);
  player1HeroContainer.addEventListener("dragenter", dragEnter);
  player1HeroContainer.addEventListener("dragleave", dragLeave);
  player1HeroContainer.addEventListener("drop", dragDropPlayer1 );
  
  player2HeroContainer.addEventListener("dragover", dragOver);
  player2HeroContainer.addEventListener("dragenter", dragEnter);
  player2HeroContainer.addEventListener("dragleave", dragLeave);
  player2HeroContainer.addEventListener("drop", dragDropPlayer2 );
  
  heroCards.forEach((heroCard) => {
    heroCard.addEventListener("dragstart", dragStart);
    heroCard.addEventListener("dragend", dragEnd);
    heroCard.draggable = true;
  });
  
  playerCards.forEach((playerCard) => {
    playerCard.addEventListener("dragover", dragOver);
    playerCard.addEventListener("dragenter", dragEnter);
    playerCard.addEventListener("dragleave", dragLeave);
  });
  
  playerCards[0].addEventListener("drop", dragDropPlayer1);
  playerCards[1].addEventListener("drop", dragDropPlayer2);
  
  function dragStart(event) {
    console.log("Drag start event fired");
    event.dataTransfer.setData("text/plain", event.target.id);
    event.currentTarget.style.opacity = "0.5"; // Reduce opacity while dragging
  }
  
  function dragEnd(event) {
    event.currentTarget.style.opacity = "1"; // Restore opacity after dragging
  }
  
  function dragOver(event) {
    event.preventDefault();
  }
  
  function dragEnter(event) {
    event.preventDefault();
    event.currentTarget.style.border = "2px dashed #007bff";
  }
  
  function dragLeave(event) {
    event.currentTarget.style.border = "none";
  }
  
  function dragDropPlayer1(event) {
    event.preventDefault();
    const draggedItemId = event.dataTransfer.getData("text/plain");
    const draggedItem = document.getElementById(draggedItemId);
    const dropZone = event.currentTarget;
    console.log(draggedItemId);
  
    if (draggedItem && draggedItem.nodeType === Node.ELEMENT_NODE) {
      // Check if the drop zone is empty
      if (!dropZone.querySelector(".hero-card")) {
        dropZone.style.border = "none"; // Change border style to none when dropping
        dropZone.appendChild(draggedItem);
        SetPlayer1Hero(draggedItemId);
      }
    }
  }
  
  function dragDropPlayer2(event) {
    event.preventDefault();
    const draggedItemId = event.dataTransfer.getData("text/plain");
    const draggedItem = document.getElementById(draggedItemId);
    const dropZone = event.currentTarget;
    console.log(draggedItemId);
  
    if (draggedItem && draggedItem.nodeType === Node.ELEMENT_NODE) {
      // Check if the drop zone is empty
      if (!dropZone.querySelector(".hero-card")) {
        dropZone.style.border = "none"; // Change border style to none when dropping
        dropZone.appendChild(draggedItem);
        SetPlayer2Hero(draggedItemId);
      }
    }
  }
  
  const resetBtn = document.getElementById("resetBtn");
  
  resetBtn.addEventListener("click", () => {
    // Clear player names
    document.getElementById("player1Name").value = "";
    document.getElementById("player2Name").value = "";
  
    // Reset border styles
    const playerCards = document.querySelectorAll(".player-card");
    playerCards.forEach((playerCard) => {
      playerCard.style.border = "none";
    });
  
    // Move selected heroes back to the hero list
    const player1HeroContainer = document.getElementById("player1Hero");
    const player2HeroContainer = document.getElementById("player2Hero");
  
    // Get the selected hero elements
    const selectedHero1 = player1HeroContainer.querySelector(".hero-card");
    const selectedHero2 = player2HeroContainer.querySelector(".hero-card");
  
    // Append selected heroes back to the hero list
    const heroList = document.getElementById("heroList");
    if (selectedHero1) {
      heroList.appendChild(selectedHero1);
    }
    if (selectedHero2) {
      heroList.appendChild(selectedHero2);
    }
  });
  
  // Get the return button element
  const returnBtn = document.getElementById("returnBtn");
  
  // Add click event listener to the return button
  returnBtn.addEventListener("click", () => {
    // Navigate back to the main menu page
    window.location.href = "mainMenu.html";
  });
  