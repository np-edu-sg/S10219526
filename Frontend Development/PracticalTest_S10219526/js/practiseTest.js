(function () {
    document.getElementById("form").addEventListener("submit", submit)
})()

function submit(e) {
    e.preventDefault()

    const name = document.getElementById("name").value
    const days = Array.from(document.querySelectorAll("input[type=checkbox]")).filter(e => e.checked).map(e => `Day ${e.value}`).join(", ")
    document.getElementById("m").innerHTML = "<br/><br/><br/>" + `Thanks ${name}. You will be attending , ${days} Open House.` + "<br/><br/>"
}