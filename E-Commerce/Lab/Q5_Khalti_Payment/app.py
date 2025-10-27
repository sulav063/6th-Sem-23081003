from flask import Flask, request, render_template_string
import requests
import json
import logging

app = Flask(__name__)

# Configure logging
logging.basicConfig(level=logging.DEBUG)

# Khalti test secret key
KHALTI_SECRET_KEY = 'bcef79032e0946e79bcc85c099f4ebee'
KHALTI_URL = 'https://dev.khalti.com/api/v2/epayment/'


@app.route('/')
def home():
    return render_template_string('''
    <!DOCTYPE html>
    <html lang="en">
    <head>
        <meta charset="UTF-8">
        <meta name="viewport" content="width=device-width, initial-scale=1.0">
        <title>SneakPeak - Buy Shoes</title>
        <style>
            body {
                background: #f0f4f8;
                font-family: Arial, sans-serif;
                margin: 0;
                padding: 0;
                height: 100vh;
                display: flex;
                flex-direction: column;
                text-align: center;
            }
            .header {
                background: #28a745;
                color: white;
                padding: 8px;
                font-size: 20px;
                text-align: center;
            }
            .content {
                flex: 1;
                display: flex;
                justify-content: center;
                align-items: center;
                gap: 15px;
                padding: 10px;
                text-align: center;
            }
            .product, .cart {
                background: white;
                width: 220px;
                padding: 10px;
                border: 1px solid #ddd;
                border-radius: 5px;
                box-shadow: 0 2px 4px rgba(0,0,0,0.1);
                text-align: center;
            }
            .product img {
                width: 100%;
                height: 140px;
                object-fit: cover;
                border-radius: 3px;
            }
            .product h3 {
                color: #28a745;
                margin: 5px 0;
                font-size: 18px;
            }
            select, input {
                padding: 5px;
                margin: 5px 0;
                width: 100%;
                border: 1px solid #ccc;
                border-radius: 3px;
                text-align: center;
            }
            .btn {
                background: #28a745;
                color: white;
                padding: 8px;
                border: none;
                border-radius: 3px;
                cursor: pointer;
                width: 100%;
                text-align: center;
            }
            .btn:hover {
                background: #218838;
            }
            .cart-item {
                margin: 5px 0;
                font-size: 14px;
                text-align: center;
            }
            #cart-total {
                color: #28a745;
                margin: 5px 0;
        font-weight: bold;
                text-align: center;
            }
            #message {
                color: red;
                margin: 5px 0;
                font-size: 14px;
                text-align: center;
            }
            #pay-now-btn {
                display: none;
                margin: 5px 0;
                text-align: center;
            }
        </style>
    </head>
    <body>
        <div class="header">SneakPeak</div>
        <div class="content">
            <div class="product">
                <img src="/static/shoes.png" alt="TBL 300 Shoes">
                <h3>TBL 300 Shoes</h3>
                <p>Price: Rs. 3500</p>
                <div><label>Size:</label>
                    <select id="size">
                        <option value="6">6</option>
                        <option value="7">7</option>
                        <option value="8">8</option>
                        <option value="9">9</option>
                    </select>
                </div>
                <div><label>Quantity:</label>
                    <input type="number" id="quantity" min="1" value="1" style="width: 60px;">
                </div>
                <button class="btn" onclick="addToCart()">Add to Cart</button>
            </div>
            <div class="cart">
                <h2>Your Cart</h2>
                <div id="cart-items"></div>
                <div id="cart-total">Total: Rs. 0</div>
                <button id="pay-now-btn" class="btn" onclick="payWithKhalti()">Pay Now</button>
                <div id="message"></div>
            </div>
        </div>
        <script>
            let cart = [];

            function addToCart() {
                const size = document.getElementById('size').value;
                const quantity = parseInt(document.getElementById('quantity').value);
                cart.push({ name: "TBL 300 Shoes", size, price: 3500, quantity });
                updateCart();
                document.getElementById('pay-now-btn').style.display = 'block';
                document.getElementById('message').textContent = '';
            }

            function updateCart() {
                const cartItems = document.getElementById('cart-items');
                cartItems.innerHTML = cart.map(item => `<div class="cart-item">${item.name} (Size: ${item.size}) - Rs. ${item.price} x ${item.quantity}</div>`).join('');
                document.getElementById('cart-total').textContent = `Total: Rs. ${cart.reduce((sum, item) => sum + item.price * item.quantity, 0)}`;
            }

            async function payWithKhalti() {
                const message = document.getElementById('message');
                message.textContent = 'Starting payment...';
                const total = cart.reduce((sum, item) => sum + item.price * item.quantity, 0) * 100;
                let response = await fetch('/start-payment', {
                    method: 'POST',
                    headers: { 'Content-Type': 'application/json' },
                    body: JSON.stringify({ amount: total, order_id: 'order_' + Math.random(), product: cart.map(item => `${item.name} (Size: ${item.size}) x ${item.quantity}`).join(', ') })
                });
                let data = await response.json();
                if (data.payment_url) {
                    window.location.href = data.payment_url;
                } else {
                    message.textContent = 'Error: ' + JSON.stringify(data);
                }
            }

            window.addEventListener('message', function(event) {
                if (event.origin === 'https://dev.khalti.com') {
                    const data = event.data;
                    if (data.status === 'completed') {
                        alert('Payment Successful! Thank you for shopping at SneakPeak!');
                        cart = [];
                        updateCart();
                        document.getElementById('pay-now-btn').style.display = 'none';
                        document.getElementById('message').textContent = '';
                    } else if (data.status === 'failed') {
                        alert('Payment Failed. Please try again.');
                    }
                }
            });
        </script>
    </body>
    </html>
    ''')


@app.route('/start-payment', methods=['POST'])
def start_payment():
    data = request.json
    payload = {
        'return_url': 'http://127.0.0.1:5000/',
        'website_url': 'http://127.0.0.1:5000/',
        'amount': data['amount'],
        'purchase_order_id': data['order_id'],
        'purchase_order_name': data['product'],
        'customer_info': {'name': 'Test Customer', 'email': 'test@example.com', 'phone': '9800000001'}
    }
    headers = {'Authorization': f'Key {KHALTI_SECRET_KEY}',
               'Content-Type': 'application/json'}
    response = requests.post(KHALTI_URL + 'initiate/',
                             headers=headers, data=json.dumps(payload))
    if response.status_code == 200:
        return response.json()
    return {'error': f'Status: {response.status_code}, Message: {response.text}'}, 400


if __name__ == '__main__':
    app.run(debug=True)

# https://test-admin.khalti.com/#/
