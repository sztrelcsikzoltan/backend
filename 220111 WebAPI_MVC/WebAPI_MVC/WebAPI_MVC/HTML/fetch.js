
fetch('http://localhost:5000/Users?id=1',{method: 'GET'})
    .then(response => response.json())
    .then(data =>console.log("Fetch info: ",  data));


    fetch('http://localhost:5000/Users?id=1',{method: 'GET'})
    .then(response => response.json())
    .then(data => fetchInfo(data));
    
    function fetchInfo(data){
        let fetchResult = 
        document.getElementById("fetch").innerHTML = "Fetch info: BNev: " + data[0].BNev + "  Jelszo: " + data[0].Jelszo + "  ";
    }

    
    






