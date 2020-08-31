# ApiTest

Склад.

Реализовать Api склад, позволяющее учитывать поставки товара (Product) на склад.
Имеется два поставщика товаров (Provider), использующие разные протоколы взаимодействия с Api.
Каждый поставщик доставляет товары от разных фирм (Company). Каждый товар характерезуется именем (Name/Value) и кол-ом (Amount/Number).
Методы работы с товаром:
- Просмотреть товар по Id
- Просмотреть товар по Name
- Просмотреть товар поставщика (Provider) за диапазон дат
- Просмотреть товар фирмы (Company) за диапазон дат
- Добавить товар на склад
- Изъять необходимое кол-во товара со склада по Id

Поставщики используют следующие протоколы для взаимодействия с Api:

ProviderA:

{
  "MessageId": "07fa8a54-88e6-492c-8db8-2c0ad42ac787",
  "LoadTime": "11/22/2009 12:00:00",
  "Companies": {
    "eeda82d6-3ac1-46d7-908d-35a9016d5c8e": [
      {
        "Value": "Product_new",
        "Number": 2
      },
      {
        "Value": "Product_1",
        "Number": 2
      }
    ],
    "3235de33-cf8e-412b-9178-0238ac3879f2": [
      {
        "Value": "Product_1_New_Company",
        "Number": 2
      }
    ]
  }
}

ProviderB:

<?xml version="1.0" encoding="utf-8"?>
<LoadItems>
  <Item Company="583f668b-db80-4894-8f7b-8da1525f0397">
    <Name>Product_new</Name>
    <Amount>2</Amount>
  </Item>
  <Item Company="583f668b-db80-4894-8f7b-8da1525f0397">
    <Name>Product_1</Name>
    <Amount>2</Amount>
  </Item>
  <Item Company="644d8d9c-4231-44af-b1a5-135c10b1d6b8">
    <Name>Product_1_New_Company</Name>
    <Amount>2</Amount>
  </Item>
</LoadItems>
