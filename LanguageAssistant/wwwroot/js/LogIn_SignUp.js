function switchPasswordVisibility(imageId, inputId) {
    let icon = document.getElementById(imageId);
    let input = document.getElementById(inputId);

    if (input.type == "password") {
        input.type = "text";
        icon.src = "icons/eye.svg";
    }
    else {
        input.type = "password";
        icon.src = "icons/hidden-eye.svg";
    } 
}

function switchLogInSignUp() {
    let confirmPasswordDiv = document.getElementById('confirmPasswordDivId');
    let logInSignUpLbl = document.getElementById('logInSignUpLblId');
    let btnSubmitDiv = document.getElementById('submitBtnId');
    let logInSignUpBtnDiv = document.getElementById('logInSignUpBtnId');
    let confirmPasswordInput = document.getElementById('confirmPasswordId');
    
    if (confirmPasswordDiv.style.display != "block") {
        confirmPasswordDiv.style.display = "block";
        logInSignUpLbl.innerHTML = "SIGN UP";
        btnSubmitDiv.value = "SIGN UP";
        logInSignUpBtnDiv.innerHTML = "LOG IN";
        confirmPasswordInput.value = '';
    }
    else {
        confirmPasswordDiv.style.display = "none";
        logInSignUpLbl.innerHTML = "LOG IN";
        btnSubmitDiv.value = "LOG IN";
        logInSignUpBtnDiv.innerHTML = "SIGN UP";
    }
}

function submitBtn() {
    let btn = document.getElementById('submitBtnId');
    //btn.type = "submit";
    console.log(btn);
}