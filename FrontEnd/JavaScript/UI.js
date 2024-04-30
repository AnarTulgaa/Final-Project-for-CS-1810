const startBtn = document.getElementById("startBtn");

startBtn.addEventListener("click", () => {
  // Redirect to the menu page or perform other actions
  window.location.href = "mainMenu.html";
});

// Optionally, add event listener for spacebar press
document.addEventListener("keydown", (event) => {
  if (event.code === "Space") {
    const privacyCheckbox = document.getElementById("privacyCheckbox");
    if (!privacyCheckbox.checked) {
      // Prevent the default action of the spacebar key event
      event.preventDefault();
      // Display an alert message to prompt the user to accept the privacy policy
      alert(
        "Please accept the privacy policy by checking the checkbox before proceeding."
      );
    } else {
      // Redirect to the menu page or perform other actions
      window.location.href = "mainMenu.html";
    }
  }
});

document.addEventListener("DOMContentLoaded", () => {
  const startBtn = document.getElementById("startBtn");
  const privacyCheckbox = document.getElementById("privacyCheckbox");

  // Disable the start button by default
  startBtn.disabled = true;

  // Add event listener to the privacy checkbox
  privacyCheckbox.addEventListener("change", () => {
    // Enable the start button only if the checkbox is checked
    startBtn.disabled = !privacyCheckbox.checked;
  });

  // Add event listener to the start button
  startBtn.addEventListener("click", () => {
    // Redirect to the next page only if the privacy policy checkbox is checked
    if (!privacyCheckbox.checked) {
      alert(
        "Please accept the privacy policy by checking the checkbox before proceeding."
      );
    } else {
      window.location.href = "mainMenu.html";
    }
  });
});
