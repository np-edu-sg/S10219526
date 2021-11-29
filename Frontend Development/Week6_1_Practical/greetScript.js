(function() {
    const name = prompt("Enter your name:")
    const now = new Date(Date.now())
    
    const word = now.getHours() < 12 ? "morning" : "afternoon"
    console.log(now.getHours())
    alert(`Good ${word}, ${name}!`)
})()