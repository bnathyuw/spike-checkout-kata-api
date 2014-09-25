# Spike Checkout Kata API

## Setup

1. Clone it.
2. Create a new site in IIS pointing to the .Web project and a binding to spike-checkout-kata-api.local.
3. Ensure the application pool for this site uses .NET 4.x.
4. Ensure that the application pool identity and IUSR have read access to the .Web project folder.
5. Create an entry in your hosts file pointing spike-checkout-kata-api.local to 127.0.0.1.