// See https://aka.ms/new-console-template for more information
using System.Linq;

List<string> dbRoles = new(){"Admin", "User"};
List<string> roles = new(){"SuperAdmin"};

bool result = dbRoles.Any(role=> roles.Contains(role));

Console.WriteLine(result);
