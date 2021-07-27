
  $(document).ready(function () {

    if ('@Model.IsGameOver' == 'True') {
    GameOver();
    }

    if (Number(document.getElementById("bet").value) !=0) {
    $("#balance").attr("readonly", true);
    }
  });

  $("#spinBtn").on("click", function (e) {
    let bet = parseFloat(document.getElementById("bet").value);
    let balance = parseFloat(document.getElementById("balance").value);

    if (isNaN(bet)) {
    document.getElementById("bet").value = 0;
      e.preventDefault();
      return false;
    } else if (balance == 0 || bet == 0 || bet > balance) {
    e.preventDefault();
      if (bet > balance) {
    document.getElementById("bet").value = document.getElementById("balance").value;
      } else {
    document.getElementById("bet").value = 0;
      }
      return false;
    }

    document.getElementById('IsGameRunning').value = true;
    document.getElementById('won').value = '0';
  });

  // Validate input to numbers only and prevent Enter key to submit the form

  $('#balance').on('keyup keypress', function (e) {
    let keyCode = e.keyCode || e.which;
    if (keyCode === 13) {
    e.preventDefault();
      return false;
    }

    let balance = document.getElementById("balance").value;
    if ('@Model.IsGameRunning' != 'True') {
      if (isNaN(balance)) {
    document.getElementById("balance").value = 0;
        document.getElementById("bet").value = 0;
      } else {
    document.getElementById("balance").value = parseFloat(document.getElementById("balance").value);
      }
    } else {
    $("#balance").attr("readonly", true);
    }
  });

  $('#bet').on('keyup keypress', function (e) {
    let keyCode = e.keyCode || e.which;
    if (keyCode === 13) {
    e.preventDefault();
      return false;
    }

    validateInput();
    compareValues();
  });

  function compareValues() {
    let balance = document.getElementById("bet").value;
    if (Number(balance) >= Number(document.getElementById("balance").value)) {
    document.getElementById("bet").value = parseFloat(document.getElementById("balance").value);
    }
  }

  function validateInput() {
    let balance = document.getElementById("bet").value;
    if (isNaN(balance)) {
    document.getElementById("bet").value = 0;
    } else {
    document.getElementById("bet").value = parseFloat(document.getElementById("bet").value);
      }
  }

  function GameOver() {
    document.getElementById("balance").value = 0;
    document.getElementById("bet").value = 0;
    $("#balance").attr("readonly", false);
    document.getElementById('IsGameRunning').value = false;
    document.getElementById('IsGameOver').value = false;
    $("#gameOver").css("visibility", "visible");
  }

  $("#gameOver").on("click", function () {
    $("#gameOver").css("visibility", "hidden");
  });
