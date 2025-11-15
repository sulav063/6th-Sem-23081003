from flask import Flask, request, render_template_string, jsonify
import stripe
import logging

app = Flask(__name__)
logging.basicConfig(level=logging.DEBUG)

# Stripe test keys (replace with your own test keys)
stripe.api_key = "sk_test_51SSbLc41vcinSutnOg19tiWNvOKdwGcW71UJz0DZwG7ibd4hy6r3JLsBC5Tm5W4Ka0JK7v9jYwsk84gxMORFBdMG00aYCnwEaT"
DOMAIN = "http://127.0.0.1:5000"

@app.route('/')
def home():
    return render_template_string('''
    <!DOCTYPE html>
    <html lang="en">
    <head>
        <meta charset="UTF-8">
        <meta name="viewport" content="width=device-width, initial-scale=1.0">
        <title>TechTime - Buy Watch</title>
        <script src="https://js.stripe.com/v3/"></script>
        <style>
            body {
                font-family: Arial, sans-serif;
                background-color: #f0f4f8;
                margin: 0;
                padding: 0;
                display: flex;
                flex-direction: column;
                align-items: center;
            }
            header {
                background-color: #007bff;
                color: white;
                width: 100%;
                padding: 1em 0;
                text-align: center;
                font-size: 2em;
                font-weight: bold;
            }
            .container {
                display: flex;
                flex-wrap: wrap;
                justify-content: center;
                margin-top: 2em;
                gap: 2em;
            }
            .box {
                background-color: white;
                border: 1px solid #ddd;
                border-radius: 8px;
                padding: 1.5em;
                width: 260px;
                box-shadow: 0 2px 6px rgba(0,0,0,0.1);
            }
            .btn {
                background-color: #007bff;
                color: white;
                padding: 0.75em;
                width: 100%;
                border: none;
                border-radius: 5px;
                cursor: pointer;
                font-size: 1em;
                margin-top: 1em;
            }
            .btn:hover {
                background-color: #0056b3;
            }
            input[type="number"] {
                width: 60px;
                padding: 0.3em;
                margin-left: 0.5em;
                border-radius: 4px;
                border: 1px solid #ccc;
                text-align: center;
            }
            #cart-items {
                margin-bottom: 1em;
                font-size: 0.95em;
            }
            #cart-total {
                font-weight: bold;
                margin-bottom: 1em;
            }
        </style>
    </head>
    <body>
        <header>TechTime</header>
        <div class="container">
            <!-- Product Box -->
            <div class="box product">
                <h3>Redmi Smart Band Pro</h3>
                <p>Price: $25</p>
                <div>
                    <label>Quantity:</label>
                    <input type="number" id="quantity" value="1" min="1">
                </div>
                <button class="btn" onclick="addToCart()">Add to Cart</button>
            </div>

            <!-- Cart Box -->
            <div class="box cart">
                <h2>Your Cart</h2>
                <div id="cart-items">Cart is empty.</div>
                <div id="cart-total">Total: $0</div>
                <button id="checkout-button" class="btn" style="display:none;">Pay Now</button>
            </div>
        </div>

        <script>
            const stripe = Stripe("pk_test_51SSbLc41vcinSutncDskvE9huVcmSgqvkaN9DZTiI89U8VQtN3l5htao3304afDcT3MfUrkk5QwELC80vx3p9PPv002CFzB8CR");
            let cart = [];

            function addToCart() {
                const qty = parseInt(document.getElementById('quantity').value);
                cart = [{ name: "Redmi Smart Band Pro", price: 25, quantity: qty }];
                updateCart();
                document.getElementById('checkout-button').style.display = 'inline-block';
            }

            function updateCart() {
                const cartItems = document.getElementById('cart-items');
                if(cart.length === 0){
                    cartItems.innerHTML = "Cart is empty.";
                    document.getElementById('cart-total').innerText = "Total: $0";
                    document.getElementById('checkout-button').style.display = 'none';
                    return;
                }
                cartItems.innerHTML = cart.map(item => `${item.name} - $${item.price} x ${item.quantity}`).join('<br>');
                const total = cart.reduce((sum, item) => sum + item.price * item.quantity, 0);
                document.getElementById('cart-total').innerText = 'Total: $' + total;
            }

            document.getElementById("checkout-button").addEventListener("click", async () => {
                const quantity = cart[0].quantity;
                const response = await fetch("/create-checkout-session", {
                    method: "POST",
                    headers: {"Content-Type": "application/json"},
                    body: JSON.stringify({quantity: quantity})
                });
                const session = await response.json();
                window.location.href = session.url;
            });
        </script>
    </body>
    </html>
    ''')

@app.route("/create-checkout-session", methods=["POST"])
def create_checkout_session():
    try:
        data = request.get_json()
        quantity = data.get("quantity", 1)

        session = stripe.checkout.Session.create(
            payment_method_types=["card"],
            line_items=[{
                "price_data": {
                    "currency": "usd",
                    "product_data": {"name": "Redmi Smart Band Pro"},
                    "unit_amount": 2500,  # $25
                },
                "quantity": quantity,
            }],
            mode="payment",
            success_url=DOMAIN + "/success",
            cancel_url=DOMAIN + "/cancel",
        )
        return jsonify({"url": session.url})
    except Exception as e:
        return jsonify(error=str(e)), 400


@app.route("/success")
def success():
    return "<h1>✅ Payment Successful!</h1><p>Thank you for purchasing the Redmi Smart Band Pro.</p>"


@app.route("/cancel")
def cancel():
    return "<h1>❌ Payment Cancelled</h1><p>Your order was not completed.</p>"


if __name__ == "__main__":
    app.run(debug=True)
