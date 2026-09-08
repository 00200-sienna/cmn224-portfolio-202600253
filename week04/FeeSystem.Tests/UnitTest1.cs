using NUnit.Framework;   //this brings in the NUnit tool to be able to test the file.
using FeeSystem;         //allows us to access the class in the FeeSystem project

[TestFixture]            //is an attribute that tells the NUnit that this class contains unit tests.
public class FeeCalculatorTests   //FeeCalculatorTests is the class
{
	// Checklist 1
	[Test]
	public void OutstandingBalance_NoPayments_ReturnsFullFee() //method being tested
	{
		//Arrange
		var calc = new FeeCalculator();        //object
		var payments = new List<decimal>();    //this creates an empty list of payments, meaning the student has nt made any payments.

		//Act
		var result = calc.OutstandingBalance(600m, payments);   //method calling the parameters 600m ad payments

		//Assert
		Assert.That(result, Is.EqualTo(600m));      //this checks whether the result is what we expected.
													//In this case, we expect the outstanding balance to be equal to the full fee of 600m
													//since no payments have been made.

	}
	//Checklist 2
	[Test]
	public void OutstandingBalance_OnePartialPayment_ReturnsRemainingBalance()
	{
		//Arrange
		var calc = new FeeCalculator();
		var payments = new List<decimal>(200m);

		//Act
		var result = calc.OutstandingBalance(600m, payments);

		//Assert
		Assert.That(result, Is.EqualTo(400m));

	}
	//Checklist 3
	[Test]
	public void OutstandingBalance_SeveralInstallmentsPayment_ReturnsRemainingBalance()
	{
		//Arrange
		var calc = new FeeCalculator();
		var payments = new List<decimal>(200m, 200m, 100m);

		//Act
		var result = calc.OutstandingBalance(600m, payments);

		//Assert
		Assert.That(result, Is.EqualTo(100m));

	}
	//Checklist 4
	[Test]
	public void OutstandingBalance_FullyPaid_ReturnsZero()
	{
		//Arrange
		var calc = new FeeCalculator();
		var payments = new List<decimal>(600m);

		//Act
		var result = calc.OutstandingBalance(600m, payments);

		//Assert
		Assert.That(result, Is.EqualTo(0m));

	}
	//Checklist 5
	[Test]
	public void OutstandingBalance_OverPayment_ReturnsNegativeBalance()
	{
		//Arrange
		var calc = new FeeCalculator();
		var payments = new List<decimal>(700m);

		//Act
		var result = calc.OutstandingBalance(600m, payments);

		//Assert
		Assert.That(result, Is.EqualTo(-100m));

	}
	//Checklist 6
	[Test]
	public void OutstandingBalance_NegativeFee_ThrowsArgumentException()
	{
		//Arrange
		var calc = new FeeCalculator();
		var payments = new List<decimal>();

		//Assert
		Assert.That(() var result => calc.OutstandingBalance(-1m, payments), Throws.ArgumentException);

	}
	//Checklist 7
	[Test]
	public void IsClearedForExams_ExactlyHalfPaid_ReturnsTrue()
	{
		//Arrange
		var calc = new FeeCalculator();
		var payments = new List<decimal>(300m);

		//Act
		var result = calc.OutstandingBalance(600m, payments);

		//Assert
		Assert.That(result, Is.True);

	}
	//Checklist 8
	[Test]
	public void IsClearedForExams_OneToeaUnderHalf_ReturnsFalse()
	{
		//Arrange
		var calc = new FeeCalculator();
		var payments = new List<decimal> { 299.99m };

		//Act
		var result = calc.OutstandingBalance(600m, payments);

		//Assert
		Assert.That(result, Is.False);

	}
}
namespace FeeSystem.Tests;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test1()
    {
        Assert.Pass();
    }
}
