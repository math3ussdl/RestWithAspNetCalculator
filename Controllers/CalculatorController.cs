using System.Globalization;
using Microsoft.AspNetCore.Mvc;

namespace RestWithAspNetCalculator.Controllers;

[ApiController]
[Route("[controller]")]
public class CalculatorController : ControllerBase
{
	[HttpGet("sum/{firstNumber}/{secondNumber}")]
	public IActionResult Sum(string firstNumber, string secondNumber)
	{
		if (!IsNumeric(firstNumber) || !IsNumeric(secondNumber)) return BadRequest("Invalid Input.");
		var sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);
		
		return Ok(sum.ToString(CultureInfo.InvariantCulture));
	}

	[HttpGet("sub/{firstNumber}/{secondNumber}")]
	public IActionResult Sub(string firstNumber, string secondNumber)
	{
		if (!IsNumeric(firstNumber) || !IsNumeric(secondNumber)) return BadRequest("Invalid Input.");
		var sub = ConvertToDecimal(firstNumber) - ConvertToDecimal(secondNumber);
		
		return Ok(sub.ToString(CultureInfo.InvariantCulture));
	}
	
	[HttpGet("mult/{firstNumber}/{secondNumber}")]
	public IActionResult Mult(string firstNumber, string secondNumber)
	{
		if (!IsNumeric(firstNumber) || !IsNumeric(secondNumber)) return BadRequest("Invalid Input.");
		var mult = ConvertToDecimal(firstNumber) * ConvertToDecimal(secondNumber);
		
		return Ok(mult.ToString(CultureInfo.InvariantCulture));
	}
	
	[HttpGet("div/{firstNumber}/{secondNumber}")]
	public IActionResult Div(string firstNumber, string secondNumber)
	{
		if (!IsNumeric(firstNumber) || !IsNumeric(secondNumber)) return BadRequest("Invalid Input.");
		var div = ConvertToDecimal(firstNumber) / ConvertToDecimal(secondNumber);
		
		return Ok(div.ToString(CultureInfo.InvariantCulture));
	}
	
	[HttpGet("mean/{firstNumber}/{secondNumber}")]
	public IActionResult Mean(string firstNumber, string secondNumber)
	{
		if (!IsNumeric(firstNumber) || !IsNumeric(secondNumber)) return BadRequest("Invalid Input.");
		var mean = (ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber)) / 2;
		
		return Ok(mean.ToString(CultureInfo.InvariantCulture));
	}
	
	[HttpGet("sqrt/{number}")]
	public IActionResult SquareRoot(string number)
	{
		if (!IsNumeric(number)) return BadRequest("Invalid Input.");
		var mean = Math.Sqrt((double)ConvertToDecimal(number));
		
		return Ok(mean.ToString(CultureInfo.InvariantCulture));
	}
	
	private static decimal ConvertToDecimal(string strNumber)
	{
		return decimal.TryParse(strNumber, out var value) ? value : 0;
	}

	private static bool IsNumeric(string strNumber)
	{
		return double.TryParse(
			strNumber,
			NumberStyles.Any,
			NumberFormatInfo.InvariantInfo,
			out _
		);
	}
}