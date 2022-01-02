(function () {
    const [now, future] = [new Date, new Date()]
    const date = document.getElementById("date")

    future.setFullYear(now.getFullYear() + 1)

    date.setAttribute("min", now.toISOString().split("T")[0])
    date.setAttribute("max", future.toISOString().split("T")[0])

    // Prevent any number input from having NaN
    document.querySelectorAll("input[type=number]").forEach(elm => elm.addEventListener("input", e => {
        if (e.target.value === "") {
            e.target.value = 0
        }
    }))

    document.getElementById("form").addEventListener("input", compute)
    document.getElementById("form").addEventListener("submit", submit)
    document.getElementById("form").addEventListener("reset", reset)
})()

const prices = {
    sentosa: 80,
    halfDayTour: 36,
    cruise: 30,
    christmasTour: 20
}

function reset() {
    document.querySelectorAll("#form input:not(input[type=reset]), select").forEach(elm => elm.disabled = false)
    document.getElementById("detail").innerText = "No tour selected"
}

function submit(e) {
    e.preventDefault()

    const name = document.getElementById("customer-name").value
    document.getElementById("detail").innerText += `\nThank you for your booking, ${name}`
    document.querySelectorAll("#form input:not(input[type=reset]), select").forEach(elm => elm.disabled = true)
}

function compute() {
    const [{value: tour}] = Array.from(document.getElementById("tour-name").options).filter(o => o.selected)
    const [adult, child] = [
        parseInt(document.getElementById("adult").value),
        parseInt(document.getElementById("child").value)
    ]
    const date = document.getElementById("date").value

    if (!prices[tour]) {
        document.getElementById("detail").innerText = "No tour selected"
        return
    }

    document.getElementById("detail").innerText =
        (tour && `Price of tour per adult is $${prices[tour]}\n`) +
        `Total price for ${adult} adults and ${child} children is $${adult * prices[tour] + child * (prices[tour] / 2)}\n` +
        (date && `Date selected is ${date}`)
}