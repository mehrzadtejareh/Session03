using System.Text.RegularExpressions;

namespace Session03.RouteConstraint;

public class IranNationalCodeConstraint : IRouteConstraint
{
    public bool Match(HttpContext httpContext, IRouter route, string parameterName,
        RouteValueDictionary values, RouteDirection routeDirection)
    {
        if (!values.TryGetValue(parameterName, out var value))
            return false;

        var input = Convert.ToString(value);

        if (string.IsNullOrEmpty(input) || !Regex.IsMatch(input, @"^\d{10}$"))
            return false;

        return IsValidIranianNationalCode(input);
    }

    private bool IsValidIranianNationalCode(string code)
    {
        if (string.IsNullOrEmpty(code) || code.Length != 10)
            return false;

        var check = int.Parse(code.Substring(9, 1));
        var sum = 0;

        for (int i = 0; i < 9; i++)
        {
            sum += int.Parse(code[i].ToString()) * (10 - i);
        }

        var remainder = sum % 11;

        return (remainder < 2 && check == remainder) ||
               (remainder >= 2 && check == (11 - remainder));
    }
}