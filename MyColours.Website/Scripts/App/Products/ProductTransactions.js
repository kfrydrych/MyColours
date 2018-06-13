$(document).ready(function () {

    let invoiceValueDisplay = $("#InvoiceValue");
    let quantityInput = $(".js-quantity");
    let priceInput = $(".js-price");


    let basketCounter = 0;
    let invoiceValue = 0;

    init();

    function init() {

        displayBasketCount();

        $(document).delegate(".js-addToBasket", "click", moveToBasketTable);

        $(document).delegate(".js-removeFromBasket", "click", removeFromBasketTable);

        $(document).delegate(quantityInput, "change", calculateInvoiceValue);

        $(document).delegate(priceInput, "change", calculateInvoiceValue);

        $("form").on('submit', function (e) {

            e.preventDefault();

            if ($(this).valid()) {
                const transaction = {};
                const basket = [];

                let purchaseDate = $("#PurchaseDate").val();
                let invoiceNumber = $("#InvoiceNumber").val();
                let invoiceValue = $("#InvoiceValue").val();

                addDataToBasket(basket);

                transaction.purchaseDate = purchaseDate;
                transaction.invoiceNumber = invoiceNumber;
                transaction.invoiceValue = invoiceValue;
                transaction.basket = basket;

                postTransaction(transaction);
            }
        });
    }

    function postTransaction(transaction) {

        if (isBasketEmpty(transaction)) {
            bootbox.alert("There are no products in basket!"); return;
        }

        if (isInvoiceValueZero()) {
            bootbox.alert("Transaction value cannot be zero!"); return;
        }

        $.post("/ProductTransactions/Create", transaction)
            .done(function (data) {
                window.location.href = data;
            })
            .fail(function (jqxhr, status, error) {
                alert("Fail");
            });
    }

    function isBasketEmpty(transaction) {
        return transaction.basket.length === 0;
    }

    function isInvoiceValueZero()
    {
        return $(invoiceValueDisplay).val() == 0;
    }

    function displayBasketCount() {
        $("#basket-counter-display").html(basketCounter);
    }

    function calculateInvoiceValue()
    {
        let invoiceValue = 0;

        $('#tbl-basket tbody tr').each(function () {

            let quantity = parseInt($(this).find(".js-quantity").val());
            let price = parseFloat($(this).find(".js-price").val());

            invoiceValue += (quantity * price);
        });

        $(invoiceValueDisplay).val(invoiceValue);
    }

    function addDataToBasket(basket) {
        $('#tbl-basket tbody tr').each(function () {

            let id = parseInt($(this).find(".js-productId").html());
            let quantity = parseInt($(this).find(".js-quantity").val());
            let price = parseFloat($(this).find(".js-price").val());

            if (id > 0 && quantity > 0) {
                let basketLine = { id, quantity, price };
                basket.push(basketLine);
            }
        });
    }

    function moveToBasketTable() {
        let button = $(this);
        renameAndToggleClasses(button, "Remove");
        let row = button.closest("tr").remove().clone();
        $("#tbl-basket tbody").append(row);
        basketCounter++;
        displayBasketCount();
        calculateInvoiceValue();
    }

    function removeFromBasketTable() {
        let button = $(this);
        renameAndToggleClasses(button, "Add");
        button.closest("tr").find(".js-quantity").val("");
        let row = button.closest("tr").remove().clone();
        $("#tbl-products tbody").append(row);
        basketCounter--;
        displayBasketCount();
        calculateInvoiceValue();
    }

    function renameAndToggleClasses(button, buttonText) {
        button.text(buttonText)
            .toggleClass("btn-danger")
            .toggleClass("btn-info")
            .toggleClass("js-addToBasket")
            .toggleClass("js-removeFromBasket");
    }

});