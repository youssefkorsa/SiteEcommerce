
var QuantitiesElement = document.querySelectorAll(".Quantity")
var totals = document.getElementsByClassName("totalspan");
var prices = document.getElementsByClassName("price");
var TotalsCart1 = document.getElementById("TotalCart1");
var TotalsCart2 = document.getElementById("TotalCart2");
var somme = 0;
for (var i = 0; i < prices.length; i++) {
    totals[i].textContent = parseFloat(prices[i].textContent) * parseFloat(QuantitiesElement[i].value) + "$";
}

for (var i = 0; i < totals.length; i++) {
    somme = parseFloat(somme) + parseFloat(totals[i].textContent);
}

TotalCart1.textContent = somme + "$";


TotalCart2.textContent = somme + "$";


QuantitiesElement.forEach(function (QuantityElement) {
    QuantityElement.addEventListener("change", function () {
        // Appeler la fonction lorsque la valeur change
        mafonction();
    });
});

mafonction = function () {
    var QuantitiesElement = document.querySelectorAll(".Quantity");
    var totals = document.getElementsByClassName("totalspan");
    var prices = document.getElementsByClassName("price");
    var TotalsCart1 = document.getElementById("TotalCart1");
    var TotalsCart2 = document.getElementById("TotalCart2");
    var somme = 0;

    for (var i = 0; i < prices.length; i++) {
        totals[i].textContent = parseFloat(prices[i].textContent) * parseFloat(QuantitiesElement[i].value) + "$";
    }

    for (var i = 0; i < totals.length; i++) {
        somme = parseFloat(somme) + parseFloat(totals[i].textContent);
    }
    console.log(somme);
    TotalCart1.textContent = somme + "$";
    TotalCart2.textContent = somme + "$";

}

