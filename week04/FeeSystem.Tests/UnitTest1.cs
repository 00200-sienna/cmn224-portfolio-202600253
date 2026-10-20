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
	public void OutstandingBalance_OnePartialPayment_ReturnsRemainingBalance() //method being tested.
	{
		//Arrange
		var calc = new FeeCalculator();  //Create The object FeeCalculator
    var payments = new List<decimal> { 200m };  //One payment of 200

		//Act
		var result = calc.OutstandingBalance(600m, payments); //The call method with the fee 600 and the payment list.

		//Assert
		Assert.That(result, Is.EqualTo(400m)); //Expect 400 remaining

	}
	//Checklist 3
	[Test]
	public void OutstandingBalance_SeveralInstallmentsPayment_ReturnsRemainingBalance()
	{
		//Arrange
		var calc = new FeeCalculator();
		var payments = new List<decimal> { 200m, 200m, 100m }; //Three payments made in installments.

		//Act
		var result = calc.OutstandingBalance(600m, payments); //call method.

		//Assert
		Assert.That(result, Is.EqualTo(100m)); //100 expected remaining.

	}
	//Checklist 4
	[Test]
	public void OutstandingBalance_FullyPaid_ReturnsZero()
	{
		//Arrange
		var calc = new FeeCalculator();
		var payments = new List<decimal>{600m}; //one payment made equals to full fee.

		//Act
		var result = calc.OutstandingBalance(600m, payments);

		//Assert
		Assert.That(result, Is.EqualTo(0m)); //zero balance expected.

	}
	//Checklist 5
	[Test]
	public void OutstandingBalance_OverPayment_ReturnsNegativeBalance()
	{
		//Arrange
		var calc = new FeeCalculator();
		var payments = new List<decimal>{700m}; //Payment is greater than the fee.

		//Act
		var result = calc.OutstandingBalance(600m, payments);

		//Assert
		Assert.That(result, Is.EqualTo(-100m)); //Expected negative balance (-100).

	}
	//Checklist 6
	[Test]
	public void OutstandingBalance_NegativeFee_ThrowsArgumentException()
	{
		//Arrange
		var calc = new FeeCalculator();
		var payments = new List<decimal>(); //List of empty payments

		//Assert
		Assert.That(() => calc.OutstandingBalance(-1m, payments), Throws.ArgumentException); //Expect an exception when the fee is -tive.

	}
	//Checklist 7
	[Test]
	public void IsClearedForExams_ExactlyHalfPaid_ReturnsTrue()
	{
		//Arrange
		var calc = new FeeCalculator();
		var payments = new List<decimal>{300m}; //Payment is equal to half of the fee.

		//Act
		var result = calc.IsClearedForExams(600m, payments); //calls the exam clearance method.

		//Assert
		Assert.That(result, Is.True); //Expect true (half paid is enough)

	}
	//Checklist 8
	[Test]
	public void IsClearedForExams_OneToeaUnderHalf_ReturnsFalse()
	{
		//Arrange
		var calc = new FeeCalculator();
		var payments = new List<decimal> { 299.99m }; //Payment is just under a half.

		//Act
		var result = calc.IsClearedForExams(600m, payments); //calls the exam clearance method.

		//Assert
		Assert.That(result, Is.False); //Expect falls when not enough is paid.

	}
}

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
