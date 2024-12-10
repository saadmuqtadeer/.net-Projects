async function clicked() {
    var response = await fetch("http://localhost:5211/weatherforecast");
    var items = await response.json();

    // var body = document.getElementById('body');
    // body.innerHTML = `<pre>${JSON.stringify(items, null, 2)}</pre>`
    updateTable(items)
}

function updateTable(items){
    const tableBody = document.getElementById("table-body");
    tableBody.innerHTML='';
    items.forEach(item => {
        const row = document.createElement("tr");
        const date = document.createElement("td");
        const tempC = document.createElement("td");
        const tempF = document.createElement("td");
        const summary = document.createElement("td");

        date.textContent = item.date;
        tempC.textContent = item.temperatureC;
        tempF.textContent = item.temperatureF;
        summary.textContent = item.summary;

        row.appendChild(date);
        row.appendChild(tempC);
        row.appendChild(tempF);
        row.appendChild(summary);

        tableBody.appendChild(row);
    });
}