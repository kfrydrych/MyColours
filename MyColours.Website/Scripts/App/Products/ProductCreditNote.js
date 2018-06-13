$(document).ready(function () {

    let transactionId = $("#TransactionId").val();
    let invoiceValueDisplay = $("#InvoiceValue");
    let creditNoteValueDisplay = $("#CreditNoteValue");
    let balanceDisplay = $("#Balance");
    let quantityInput = $(".js-quantity");
    let priceInput = $(".js-price");

    let invoiceValue = invoiceValueDisplay.html();
    let creditNoteValue = creditNoteValueDisplay.val();
    let balance = balanceDisplay.val();

    init();

    function init() {

        $(document).delegate(quantityInput, "change", calculateInvoiceValue);

        $(document).delegate(priceInput, "change", calculateInvoiceValue);

        $("form").on('submit', function (e) {

            e.preventDefault();

            if ($(this).valid()) {
                const transaction = {};
                const basket = [];

                addDataToBasket(basket);

                transaction.transactionId = transactionId;
                transaction.products = basket;

                postTransaction(transaction);
            }
        });

    }

    function calculateInvoiceValue() {
        let creditNoteValue = 0;

        $('#tbl-creditNote-products tbody tr').each(function () {

            let quantity = parseInt($(this).find(".js-quantity").val());
            let price = parseFloat($(this).find(".js-price").val());

            creditNoteValue -= (quantity * price);
        });

        balance = parseFloat(invoiceValue) + creditNoteValue;

        $(creditNoteValueDisplay).val(creditNoteValue);
        $(balanceDisplay).val(balance);
    }

    function addDataToBasket(basket) {
        $('#tbl-creditNote-products tbody tr').each(function () {

            let productId = parseInt($(this).find(".js-productId").html());
            let quantity = parseInt($(this).find(".js-quantity").val());
            let price = parseFloat($(this).find(".js-price").val());

            if (productId > 0 && quantity > 0) {
                let basketLine = { productId, quantity, price };
                basket.push(basketLine);
            }
        });
    }

    function postTransaction(transaction) {

        if (isBasketEmpty(transaction)) {
            bootbox.alert("There are no products to credit!"); return;
        }

        if (isCreditNoteValueInvalid()) {
            bootbox.alert("Invalid Credit Note Value!"); return;
        }

        console.log(transaction);

        $.post("/ProductTransactions/Credit", transaction)
            .done(function (data) {
                window.location.href = data;
            })
            .fail(function (jqxhr, status, error) {
                alert("Fail");
            });
    }

    function isBasketEmpty(transaction) {
        return transaction.products.length === 0;
    }

    function isCreditNoteValueInvalid() {
        return $(creditNoteValueDisplay).val() >= 0;
    }
});