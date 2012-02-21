module main

open firefox
open register
 
describe "h1 should have John"
url @"C:\projects\floak\floak\BasicPage.html"
"#welcome" == "Welcome"

describe "textbox should have John"
url @"C:\projects\floak\floak\BasicPage.html"
"#firstName" == "John"

describe "textbox should have Doe"
url @"C:\projects\floak\floak\BasicPage.html"
"#lastName" == "Doe"

describe "ajax label should have ajax loaded"
url @"C:\projects\floak\floak\BasicPage.html"
"#ajax" == "ajax loaded"

quit ()

System.Console.ReadKey()