const prices = {
    blackBeanPurses: 3.95,
    southwesternNapoleons: 7.95,
    baguette: 0.10,
    bread: 0.10,
    cheesecake: 0.10,
    scones: 0.10
}

const names = {
    blackBeanPurses: "Black bean purses",
    southwesternNapoleons: "Southwestern Napoleons",
    baguette: "Baguette",
    bread: "Bread",
    cheesecake: "Cheesecake",
    scones: "Scones"
}

window.onload = function () {
    const [now, future] = [new Date(), new Date()]
    future.setMonth(now.getMonth() + 1)
    document.getElementById("date").setAttribute("min", now.toISOString().split("T")[0])
    document.getElementById("date").setAttribute("max", future.toISOString().split("T")[0])
    showIntermediateMessage()
}

function showFinalMessage() {
    const {value: name = ""} = document.getElementById("name")
    document.getElementById("acknowledgement").innerText = `Thank you for your order, ${name}`
}

function showIntermediateMessage() {
    const {value: item = ""} = document.getElementById("item")
    const {value: quantity = 1} = document.getElementById("quantity")
    
    if (!item || !quantity) return

    document.getElementById("item-price").innerText = `You ordered ${quantity} ${names[item]}. Price = $${prices[item].toFixed(2)} x ${quantity} = $${(prices[item] * quantity).toFixed(2)}`
}

function showCollectionDate() {
    const {value: date} = document.getElementById("date")
    document.getElementById("collection-date").innerText = `Collection date: ${date}`
}

function clearMessage() {
    document.getElementById("acknowledgement").innerText = ""
    document.getElementById("item-price").innerText = ""
    document.getElementById("collection-date").innerText = ""
}