# Sample.CnbCurrencyRest
aplikace na načtení menového kurzu z api CNB

# Example 

## curl

```
curl -X 'GET' \
  'https://localhost:7115/ExchangeRate?CurrencyTableDate=2024-01-01' \
  -H 'accept: text/plain'
```

## Result 

```json
[
  {
    "country": "Austrálie",
    "currencyName": "dolar",
    "amount": 1,
    "code": "AUD",
    "exchangeRate": 15.193
  },

    //................

  {
    "country": "USA",
    "currencyName": "dolar",
    "amount": 1,
    "code": "USD",
    "exchangeRate": 22.376
  },
  {
    "country": "Velká Británie",
    "currencyName": "libra",
    "amount": 1,
    "code": "GBP",
    "exchangeRate": 28.447
  }
]
```