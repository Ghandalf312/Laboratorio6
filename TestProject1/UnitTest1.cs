using Moq;
using System;
using System.Diagnostics.CodeAnalysis;
using Laboratorio6;
using Xunit;

namespace TestProject1
{
    [ExcludeFromCodeCoverage]
    public class UnitTest1
    {
        [Fact]
        // Atributo para metodos de prueba
        public void BankAccount_CustomerName_GetTheSameNameSentToTheConstructor()
        {
            //Arr -> Preparacion, datos o declaraciones
            string TestCustomer = It.IsAny<string>();
            //Act -> Mandar a llamar el metodo
            BankAccount bankAccount = new BankAccount(TestCustomer, It.IsAny<double>());
            string result = bankAccount.CustomerName;
            //Assert -> validar
            Assert.Equal(TestCustomer, result);
        }

        [Fact]
        public void BankAccount_Balance_GetTheSameAmountSentToTheConstructor()
        {
            //Arr
            var TestBalance = It.IsAny<double>();
            //Act
            BankAccount bankAccount = new BankAccount(It.IsAny<string>(), TestBalance);
            var result = bankAccount.Balance;
            //Assert
            Assert.Equal(TestBalance, result);
        }

        [Fact]
        public void BankAccount_Credit_AddMoneyAndUpdatesBalance()
        {
            // Arr
            BankAccount bankAccount = new BankAccount(It.IsAny<string>(), 11.99);
            // Act
            bankAccount.Credit(5.89);
            // Assert
            Assert.Equal(17.88, bankAccount.Balance, 2);
        }

        [Fact]
        public void BankAccount_Credit_AddZeroAndNoChangeInBalance()
        {
            // Arr
            BankAccount bankAccount = new BankAccount(It.IsAny<string>(), 11.99);
            var initialBalance = bankAccount.Balance;
            // Act
            bankAccount.Credit(0);
            // Assert
            Assert.Equal(initialBalance, bankAccount.Balance);
        }

        [Fact]
        public void BankAccount_Debit_SubMoneyAndUpdatesBalance()
        {
            // Arr
            BankAccount bankAccount = new BankAccount(It.IsAny<string>(), 11.99);
            // Act
            bankAccount.Debit(5.89);
            // Assert
            Assert.Equal(6.10, bankAccount.Balance, 2);
        }
    }
}
