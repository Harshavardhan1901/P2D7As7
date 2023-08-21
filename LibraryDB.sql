CREATE DATABASE LibraryDB
USE LibraryDB;

CREATE TABLE Books (
    BookId INT PRIMARY KEY,
    Title NVARCHAR(100),
    Author NVARCHAR(100),
    Genre NVARCHAR(50),
    Quantity INT
);

INSERT INTO Books (BookId, Title, Author, Genre, Quantity) VALUES 
(1, 'The Great Gatsby', 'F. Scott Fitzgerald', 'Fiction', 10),
(2, 'To Kill a Mockingbird', 'Harper Lee', 'Fiction', 15),
(3, '1984', 'George Orwell', 'Science Fiction', 8),
(4, 'Pride and Prejudice', 'Jane Austen', 'Romance', 12),
(5, 'The Hobbit', 'J.R.R. Tolkien', 'Fantasy', 20);

SELECT * FROM Books