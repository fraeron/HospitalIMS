// Define the coronavirus.net API URL
const apiUrl = 'https://coronavirus.m.pipedream.net/';

// Init. function to handle number appearance.
function numberWithCommas(x) {
    return x.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",");
}

// Make a GET request for coronavirus API once file loads.
fetch(apiUrl)
    .then(response => {
        if (!response.ok) {
            throw new Error('Network response was not ok');
        }
        return response.json();
    })
    .then(data => {
        const globalData = data.summaryStats.global;
        const philData = data.rawData[513];
        const globalConfirmed = numberWithCommas(globalData.confirmed);
        const globalDeaths = numberWithCommas(globalData.deaths);
        const philConfirmed = numberWithCommas(philData.Confirmed);
        const philDeaths = numberWithCommas(philData.Deaths);

        document.getElementById("coronavirus-tracker-p").innerText =
            `Confirmed cases globally: ${globalConfirmed}
                 Deaths globally: ${globalDeaths}
                 Confirmed cases in Philippines: ${philConfirmed}
                 Deaths in Philippines: ${philDeaths}
            `;
        console.log(data);
    })
    .catch(error => {
        console.error('Error:', error);
    });


// Init. function to activate MailTrap API.
//function sendEmail() {
//    console.log(document.getElementById("email-address").value)
//    console.log(document.getElementById("email-body").value)
//    Email.send({
//        Host: "sandbox.smtp.mailtrap.io",
//        Username: "USERNAME", // Insert username here.
//        Password: "PASSWORD", // Insert password here.
//        To: 'sampleadmin@example.com',
//        From: document.getElementById("email-address").value,
//        Subject: "Contact Us - MailTrap API",
//        Body: document.getElementById("email-body").value
//    }).then(function (message) {
//        alert("Mail sent successfully!") // Alert message on successful email delivery.
//    });