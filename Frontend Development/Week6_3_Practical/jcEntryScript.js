const data = {
    ACJC: 8,
    NJC: 7,
    AJC: 11,
    NYJC: 7,
    CJC: 10,
    SAJC: 10,
    EJC: 9,
    TJC: 9,
    HCI: 4,
    VJC: 7,
}

function onChange() {
    const {value: jc} = document.getElementById("s")
    document.getElementById("t").innerText = data[jc] ? `Entry Point for ${jc} is ${data[jc]}` : "Select a JC"
}