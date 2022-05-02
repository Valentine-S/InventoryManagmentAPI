# InventoryManagmentAPI

## API ENDPOINTS:
- /inventory -- GET -- POST -- DELETE
- /inventory/{id] -- GET -- DELETE
- /sales     -- GET -- POST -- DELETE
- /sales/{id} -- GET -- DELETE

### POST -- /inventory -- Request Body
```
{
    "itemName": "Yeezy Boost 350 V2 Zebra",
    "size": "12",
    "color": "Black/White",
    "sku": "DD1211-202",
    "condition": "Brand New",
    "brand": "Yeezy"
}
```
### POST -- /sales -- Request Body
```
{          
    "inventoryId": 1,
    "datePurchased": "2022-04-25",
    "retailPrice": 100,
    "taxAndFee": 10,
    "fullPurchasePrice": 110,
    "dateSold": "2022-04-29",
    "salePrice": 200,
    "salePriceAfterFee": 185,
    "profit": 75
}
```
### Sample Response Body
```
{
    "inventoryData": [
        {
            "inventoryId": 1,
            "itemName": "Nike Dunk Low",
            "size": "10",
            "color": "BLack/White",
            "sku": "DD1391-100",
            "condition": "Brand New",
            "brand": "Nike"
        }
    ],
    "statusCode": 200,
    "statusDescription": "FOUND"
}
```
## or  

```
"saleData": [
        {
            "saleId": 1,
            "inventoryId": 1,
            "datePurchased": "2022-04-25",
            "retailPrice": 100,
            "taxAndFee": 10,
            "fullPurchasePrice": 110,
            "dateSold": "2022-04-29",
            "salePrice": 200,
            "salePriceAfterFee": 185,
            "profit": 75
        }
    ],
    "statusCode": 200,
    "statusDescription": "FOUND"
}
```
### Changes From Initial API Idea
- Added CHECK >= 0 Constraint to Retail Price
