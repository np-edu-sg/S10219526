function calculateBMI() {
    const {value: weight} = document.getElementById("w")
    const {value: height} = document.getElementById("h")

    const bmi = (weight / (height * height)).toFixed(2)

    let category;
    if (bmi < 18.5) {
        category = "under weight"
    } else if (bmi < 23) {
        category = "normal weight"
    } else if (bmi < 27.5) {
        category = "over weight"
    } else {
        category = "obese"
    }

    if (isFinite(bmi)) document.getElementById("t").innerText = `Your BMI is ${bmi}. You are ${category}`
    else document.getElementById("t").innerText = "Please put a valid weight and height"
}