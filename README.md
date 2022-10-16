# ShopsRUs


Getting Started

 This application include  a set of APIs to be built that provide capabilities to calculate discounts, 
 generate the total costs and generate the invoices for customers.
 
 It follows the rules listed below.
 
1. If the user is an employee of the store, he gets a 30% discount
2. If the user is an affiliate of the store, he gets a 10% discount
3. If the user has been a customer for over 2 years, he gets a 5% discount.
4. For every $100 on the bill, there would be a $ 5 discount (e.g. for $ 990, you get $ 45 as a discount).
5. The percentage based discounts do not apply on groceries.
6. A user can get only one of the percentage based discounts on a bill.

## Prerequirements

1. .NET Core 6.0

## How To Run

2. Build the project.
3. Run the application.
4. Open Postman Application
5. Send request "https://localhost:7011/api/bill/calculate-discounts" as in the example in the picture I attached below.
{
    "customerId": 1,
    "products": [
        {
            "name": "Milk",
            "productType": "Other",
            "price": 1000
        },
        {
            "name": "Fish",
            "productType": "Groceries",
            "price": 500
        }
    ]
}



<img width="1440" alt="Screen Shot 2022-10-15 at 23 51 41" src="https://user-images.githubusercontent.com/64587314/196043207-c05792b3-c30e-44ff-9970-b96f37f9db66.png">


## About Test

1. We can run ddiscountServiceTest.cs in ShopsRUs.test and we can see result some discount process.





