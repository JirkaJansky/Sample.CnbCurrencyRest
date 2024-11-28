# Sample.CnbCurrencyRest
Aplikace na načtení měnového kurzu z api ČNB

# Example 

## curl

```
curl -X 'POST' \
  'https://localhost:7115/ExchangeRate/ListExchangeRateCurrencies' \
  -H 'accept: text/plain' \
  -H 'Content-Type: application/json' \
  -d '{
  "getAllInOnePage": true,
  "exchangeDataFromDate": "2024-11-28T21:55:51.872Z",
  "exchangeRateFrom": 1,
  "exchangeRateTo": 100,
  "codeSearch": "a",
  "currencyNameSearch": "",
  "countryCodeSearch": ""
}'
```

## Result 

```json
{
  "items": [
    {
      "country": "Austrálie",
      "currencyName": "dolar",
      "amount": 1,
      "code": "AUD",
      "exchangeRate": 15.569
    },
    {
      "country": "Jižní Afrika",
      "currencyName": "rand",
      "amount": 1,
      "code": "ZAR",
      "exchangeRate": 1.32
    },
    {
      "country": "Kanada",
      "currencyName": "dolar",
      "amount": 1,
      "code": "CAD",
      "exchangeRate": 17.103
    }
  ],
  "pageIndex": 0,
  "totalPages": 1,
  "totalCount": 3,
  "hasPreviousPage": false,
  "hasNextPage": false
}
```