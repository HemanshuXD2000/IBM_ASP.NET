// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
var current = null;
document.querySelector('#username').addEventListener('focus', function (e) {
    if (current) current.pause();
    current = anime({
        targets: 'path',
        strokeDashoffset: {
            value: 0,
            duration: 700,
            easing: 'easeOutQuart'
        },

        strokeDasharray: {
            value: '240 1386',
            duration: 700,
            easing: 'easeOutQuart'
        }
    });


});
document.querySelector('#password').addEventListener('focus', function (e) {
    if (current) current.pause();
    current = anime({
        targets: 'path',
        strokeDashoffset: {
            value: -336,
            duration: 700,
            easing: 'easeOutQuart'
        },

        strokeDasharray: {
            value: '240 1386',
            duration: 700,
            easing: 'easeOutQuart'
        }
    });


});
document.querySelector('#submit').addEventListener('focus', function (e) {
    if (current) current.pause();
    current = anime({
        targets: 'path',
        strokeDashoffset: {
            value: -730,
            duration: 700,
            easing: 'easeOutQuart'
        },

        strokeDasharray: {
            value: '530 1386',
            duration: 700,
            easing: 'easeOutQuart'
        }
    });


});


/*let products = [
    // ... existing products ...
];*/

/*function addToCart(productId) {
    alert("Added to cart!!!");
    const productToAdd = products.find(p => p.id === productId);
    if (productToAdd) {
        products.push({ ...productToAdd, quantity: 1 });
        renderCart();
    }
}

function renderCart() {
    const cartContainer = document.getElementById('cart-container');
    cartContainer.innerHTML = '';

    let grandTotal = 0;

    products.forEach(product => {
        // ... existing code ...

        grandTotal += product.price * product.quantity;
    });

    document.getElementById('grand-total').innerText = `Grand Total: ₹ ${grandTotal.toFixed(2)}`;
}
*/



    



