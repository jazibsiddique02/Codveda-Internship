# Task 3 – Bank Account Management with Exception Handling

## Overview

This C# console application was developed as part of my internship at **Codveda Tech**. The project simulates a basic **bank account system** and focuses on mastering **robust error handling**, **custom exceptions**, and **logging**.

---

## Task Objectives

> ✔ Use `try-catch-finally` blocks for error handling  
> ✔ Implement **custom exceptions** for better error reporting  
> ✔ Debug applications using **breakpoints** and **watch variables** in Visual Studio  
> ✔ Use logging frameworks like **Serilog** or **NLog** for error tracking

---

## Technologies Used

- **Language:** C# (.NET)
- **IDE:** Visual Studio 2022
- **Logging:** Serilog (`logs/*.log`)
- **Type:** Console Application

---

## Project Structure

### `BankAccount` Class

Encapsulates account holder information and balance. Includes:

- `Deposit(double amount)`
- `Withdraw(double amount)`  
  Each method validates inputs and throws **custom exceptions** if invalid.

### Custom Exceptions

- `InvalidAmountException`: Thrown for deposits/withdrawals ≤ 0
- `InsufficientFundsException`: Thrown if withdrawal exceeds balance

### Main Program

- Creates an account instance
- Executes deposit and withdrawal inside `try-catch-finally` blocks
- Logs all exceptions to file and console using **Serilog**

---

## Sample Output

```txt
Welcome Jazib
Attempting to Deposit 200$.....
Deposit Successful.200$ added to balance. your current balance is now 700$

Transaction Completed.....

Welcome Jazib
Attempting to Withdraw 200$.....
Withdraw successful.200$ credited from your bank account.

Transaction Completed....
```

├── BankAccount.cs
├── InvalidAmountException.cs
├── InsufficientFundsException.cs
├── MainClass.cs
├── logs/
│ └── \*.log
