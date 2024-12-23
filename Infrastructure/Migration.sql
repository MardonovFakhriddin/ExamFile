create table Products
(
    productId serial primary key,
    name varchar,
    description varchar,
    price decimal,
    StockQuantity int,
    CategoryName varchar,
    CreatedDate timestamp
);

INSERT INTO Products (Name, Description, Price, StockQuantity, CategoryName, CreatedDate)
VALUES
    ('Laptop Pro', 'High-performance laptop with 16GB RAM and 1TB SSD.', 1200.00, 10, 'Electronics', '2024-01-01 10:00:00'),
    ('Smartphone X', 'Latest smartphone with advanced camera features.', 900.00, 25, 'Electronics', '2024-01-02 15:30:00'),
    ('Wireless Headphones', 'Noise-cancelling headphones with Bluetooth.', 150.00, 50, 'Accessories', '2024-01-03 09:45:00'),
    ('Gaming Chair', 'Ergonomic chair designed for gamers.', 300.00, 20, 'Furniture', '2024-01-04 13:00:00'),
    ('Electric Kettle', '1.7L kettle with auto shut-off.', 40.00, 100, 'Appliances', '2024-01-05 11:15:00'),
    ('Desk Lamp', 'Adjustable LED desk lamp with USB charging.', 25.00, 75, 'Furniture', '2024-01-06 18:45:00'),
    ('Coffee Maker', 'Automatic coffee maker with timer.', 80.00, 30, 'Appliances', '2024-01-07 07:30:00'),
    ('Bluetooth Speaker', 'Portable speaker with rich bass sound.', 60.00, 45, 'Accessories', '2024-01-08 14:10:00'),
    ('Smartwatch Z', 'Smartwatch with fitness tracking and notifications.', 200.00, 15, 'Electronics', '2024-01-09 12:50:00'),
    ('Electric Scooter', 'Foldable scooter with a range of 30km.', 450.00, 10, 'Transport', '2024-01-10 16:25:00'),
    ('Yoga Mat', 'Non-slip yoga mat with carrying strap.', 20.00, 120, 'Sports', '2024-01-11 08:40:00'),
    ('Dumbbell Set', 'Adjustable dumbbells for home workouts.', 100.00, 50, 'Sports', '2024-01-12 19:20:00'),
    ('Tablet Pro', 'High-performance tablet for work and entertainment.', 700.00, 12, 'Electronics', '2024-01-13 10:05:00'),
    ('Refrigerator XL', 'Large refrigerator with energy-saving features.', 1200.00, 5, 'Appliances', '2024-01-14 17:30:00'),
    ('Microwave Oven', 'Compact microwave with grill feature.', 100.00, 25, 'Appliances', '2024-01-15 13:45:00'),
    ('Office Desk', 'Spacious desk with cable management.', 150.00, 20, 'Furniture', '2024-01-16 09:10:00'),
    ('Tennis Racket', 'Professional tennis racket with cover.', 120.00, 40, 'Sports', '2024-01-17 15:55:00'),
    ('Air Purifier', 'Air purifier with HEPA filter.', 250.00, 18, 'Appliances', '2024-01-18 20:30:00'),
    ('Backpack Pro', 'Water-resistant backpack with laptop compartment.', 80.00, 60, 'Accessories', '2024-01-19 11:45:00'),
    ('E-book Reader', 'E-reader with adjustable backlight.', 150.00, 30, 'Electronics', '2024-01-20 14:15:00');