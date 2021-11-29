const prices = {
    sizes: {
        small: 22,
        medium: 28,
        large: 35
    },
    toppings: 2,
    addons: {
        buffaloWings: 5,
        garlicBread: 3
    }
}

function onChange() {
    const sizeElm = Array.from(document.getElementsByName("size")).find(s => s.checked)
    const toppingElms = Array.from(document.getElementsByName("topping")).filter(t => t.checked)
    const addonElms = Array.from(document.getElementById("pizza-addons").options).filter(a => a.selected)

    const price = (sizeElm ? prices.sizes[sizeElm.value] : 0) + toppingElms.length * prices.toppings + addonElms.reduce((a, v) => a += prices.addons[v.value], 0)

    document.getElementById("t").innerText = `Total price for your order is $${price}`
}

window.onload = function() {
    const now = new Date(Date.now())
    const future = new Date()
    
    future.setDate(now.getDate() + 7)
    const elm = document.getElementById("deliver-date")
    
    elm.setAttribute("min", now.toISOString().split("T")[0])
    elm.setAttribute("max", future.toISOString().split("T")[0])
}