
CREATE DATABASE car_rental;
USE car_rental;

CREATE TABLE users (
    id INT AUTO_INCREMENT PRIMARY KEY,
    username VARCHAR(50) NOT NULL UNIQUE,
    password VARCHAR(255) NOT NULL
);

CREATE TABLE cars (
    id INT AUTO_INCREMENT PRIMARY KEY,
    marka VARCHAR(50) NOT NULL,       
    model VARCHAR(50) NOT NULL,      
    rok INT NOT NULL,               
    is_available BOOLEAN NOT NULL DEFAULT TRUE
);

CREATE TABLE rentals (
    id INT AUTO_INCREMENT PRIMARY KEY,
    user_id INT NOT NULL,            
    car_id INT NOT NULL,             
    rental_date DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    return_date DATETIME DEFAULT NULL,
    FOREIGN KEY (user_id) REFERENCES users(id) ON DELETE CASCADE,
    FOREIGN KEY (car_id) REFERENCES cars(id) ON DELETE CASCADE
);


INSERT INTO users (username, password) VALUES
('Piotr', '123'), 
('Jakub', 'aaa'); 

INSERT INTO cars (make, model, year, is_available) VALUES
('Toyota', 'Corolla', 2020, TRUE),
('Ford', 'Focus', 2018, TRUE),
('Tesla', 'Model 3', 2022, TRUE);



SELECT * FROM users;
