function inputNumber(button) {
    let input = document.getElementById("input-field")

    if (input.classList.contains("money-field")) {
        if (input.value.length === 0 && button.value === "0") {
            return
        }
        input.value += button.value
    }
    else if (input.value.length < input.maxLength) {
        if (input.value.length > 0 && input.value.replace(/-/g, '').length % 4 == 0) {
            input.value += "-" + button.value
        }
        else {
            input.value += button.value
        }
    }
}

function clearInput() {
    document.getElementById("input-field").value = ""
}
